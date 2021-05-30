using ITCOMMON.Services.Interface;
using ITDB.Domain.Job;
using ITDB.Repository.Class;
using ITDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Class
{
    public class CompanyHasJobService: ICompanyHasJobService
    {
        private readonly ICompanyHasJobRepository _companyHasJobRepo = new CompanyHasJobRepository();
        /// <summary>
        /// Save company Has Job
        /// </summary>
        /// <returns></returns>
        public string Save(CompanyHasJob job, string userUuid)
        {
            return _companyHasJobRepo.Save(job, userUuid);
        }
    }
}