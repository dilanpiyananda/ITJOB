using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMVC.Models
{
    public class CommonPassData
    {
        public long id { get; set; }
        public string error { get; set; }
        public string value { get; set; }
        public bool IsUse { get; set; }
    }
}