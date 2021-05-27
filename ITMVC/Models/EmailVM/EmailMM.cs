using ITDB.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMVC.Models.EmailVM
{
    public class EmailMM:AcceptEmail
    {
    }
    public class EmailHandleViewModel
    {
        public List<EmailMM> Emails { get; set; }
    }
}