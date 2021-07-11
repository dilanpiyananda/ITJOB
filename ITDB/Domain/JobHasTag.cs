using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Domain
{
    public class JobHasTag: SystemData
    {
        public long JobHasTagId { get; set; }
        public long JobId { get; set; }
        public long TagId { get; set; }
    }
}
