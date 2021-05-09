using ITDB.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMVC.Models.ComapnyVM
{
    public class CompanyViewModel
    {
        public Company Company { get; set; }
        public HttpPostedFile CompanyLogo { get; set; }
    }
}