using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Domain
{
    public class AcceptEmail:SystemData
    {
        public long AcceptEmailId { get; set; }
        public long CompanyId { get; set; }
        public string EmailAddress { get; set; }
    }
}
