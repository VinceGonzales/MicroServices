using System;
using System.ComponentModel;
using System.Reflection;

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
    public static class Util
    {
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
