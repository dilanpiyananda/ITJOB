using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Domain
{
    /// <summary>
    /// Company Details
    /// </summary>
    public class Company:SystemData
    {
        public long CompanyDetailsId { get; set; }
        public string UserId { get; set; }
        public string CompanyName { get; set; }
        public int? CompanyLogoId { get; set; }
        public string WebLink { get; set; }
        public int TrustedId { get; set; }
        public string ContactNo { get; set; }
  
        //Extra
        public string LogoPath { get; set; }
    }
}
