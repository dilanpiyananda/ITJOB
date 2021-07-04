using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Domain
{
    public class Tag: SystemData
    {
        public long TagId { get; set; }
        public string TagName { get; set; }
    }
}
