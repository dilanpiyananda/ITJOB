using ITDB.Domain;
using ITDB.Domain.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMVC.Models.JOBVM
{
    public class JobMM: JobMain
    {
    }

    public class JobViewModel
    {
        public JobMM Job { get; set; }
        public long CompanyId { get; set; }
        public HttpPostedFileBase JobImage { get; set; }
        //Dorpdown list
        public List<NewSelectList> AcceptEmail { get; set; }
        public List<NewSelectList> Category { get; set; }
    }
}