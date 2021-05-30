using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Domain.Job
{
    public class CompanyHasJob:SystemData
    {
        public long CompanyHasJobId { get; set; }
        public long CompanyId { get; set; }
        public long JobMainId { get; set; }
    }
}
