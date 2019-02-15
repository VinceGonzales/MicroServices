using System;
using System.Collections.Generic;

namespace Interchange.Entity
{
    public class DataContainer
    {
        public IXHeader Header { get; set; }
        public List<IXDetail> Details { get; set; }
        public IXAddress Address { get; set; }
        public IXName Information { get; set; }
        public string ErrorMessage { get; set; }

        public DataContainer()
        {
            Header = new IXHeader();
            Details = new List<IXDetail>();
            Address = new IXAddress();
            Information = new IXName();
            ErrorMessage = "";
        }
    }
}
