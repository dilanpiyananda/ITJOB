using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Domain
{
    /// <summary>
    /// System Data
    /// </summary>
    public class SystemData
    {
        public string SystemComment { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
       
    }
}
