using ITDB.Domain.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Interface
{
    public interface ICompanyHasJobService
    {
        /// <summary>
        /// Save company Has Job
        /// </summary>
        /// <returns></returns>
        string Save(CompanyHasJob job,string userUuid);
    }
}