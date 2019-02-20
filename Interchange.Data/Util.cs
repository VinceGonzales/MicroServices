using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Interchange.Data
{
    public enum Department : int
    {
        [Description("08")]
        LADBS = 8,
        [Description("30")]
        DCA = 30,
        [Description("38")]
        LAFD = 38,
        [Description("43")]
        HCIDLA = 43,
        [Description("50")]
        DPWOS = 50,
        [Description("62")]
        OOF = 62,
        [Description("68")]
        DCP = 68,
        [Description("74")]
        DPWPW = 74,
        [Description("78")]
        BOE = 78,
        [Description("88")]
        RAP = 88,
        [Description("94")]
        DOT = 94
    }
    public enum ResponseType
    {
        Failure, Success
    }
    public static class Util
    {
        public static async Task<T> ApiCall<T>(string uri, string username, string password)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    string authInfo = string.Format("{0}:{1}", username, password);
                    authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
                }

                System.Net.Http.HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                using (System.Net.Http.HttpContent content = response.Content)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    T messages = JsonConvert.DeserializeObject<T>(responseBody);
                    return messages;
                }
            }
        }
        public static string GetDeptId(Department dept)
        {
            string id = Util.StringToEnum<Department>(dept.ToString()).ToDescriptionString();
            return id;
        }
        private static T StringToEnum<T>(string name)
        {
            return (T)Enum.Parse(typeof(T), name);
        }
        private static string ToDescriptionString(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
