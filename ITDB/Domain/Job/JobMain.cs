using ITDB.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Domain.Job
{
    public class JobMain:SystemData
    {
        public long JobMainId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? NumberOfVacancy { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public int? JobTypeId { get; set; }
        public int CvAcceptEmailId { get; set; }
        public string CvAcceptEmail { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int WebApproval { get; set; }
        public Approval WebApprovaltype { get; set; }

        public JobType JobTypes { get; set; }
    }
}
