using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Domain
{
    public class CustomeJsonModel
    {
        public long Id { get; set; }
        public string StringValue { get; set; }
        public string Note { get; set; }
        public string Error { get; set; }
        public bool IsSuccess { get; set; }
    }
}
