using System;

namespace Interchange.Entity
{
    public class IXAddress
    {
        public string Address_AddressType { get; set; }
        public string Address_NbrRangeStart { get; set; }
        public string Address_NbrRangeEnd { get; set; }
        public string Address_FracRangeStart { get; set; }
        public string Address_FracRangeEnd { get; set; }
        public string Address_UnitRangeStart { get; set; }
        public string Address_UnitRangeEnd { get; set; }
        public string Address_StrDir { get; set; }
        public string Address_StrName { get; set; }
        public string Address_StrSuff { get; set; }
        public string Address_StrSuffDir { get; set; }
        public string Address_CityName { get; set; }
        public string Address_StateCode { get; set; }
        public string Address_Zipcode { get; set; }
        public string Address_PoBox { get; set; }
    }
}
