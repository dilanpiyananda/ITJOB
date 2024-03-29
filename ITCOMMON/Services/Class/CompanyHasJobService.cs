﻿using ITCOMMON.Services.Interface;
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

        /// <summary>
        /// Get ComapnyHasJob
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public long[] GetComapnyHasJob(long companyId)
        {
            return _companyHasJobRepo.GetComapnyHasJob(companyId);
        }

        /// <summary>
        /// Delete company has job
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public string deleteCompanyHasJobByJobId(long jobId)
        {
            return _companyHasJobRepo.deleteCompanyHasJobByJobId(jobId);
        }

        /// <summary>
        /// Get Company
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public long GetCompanyId(long jobId)
        {
           return _companyHasJobRepo.GetCompanyId(jobId);
        }
    }
}