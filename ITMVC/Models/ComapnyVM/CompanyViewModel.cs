using ITDB.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMVC.Models.ComapnyVM
{
    public class CompanyViewModel
    {
        public CompanyDom Company { get; set; }
        public HttpPostedFileBase CompanyLogo { get; set; }
        public long companyId { get; set; }
    }
}