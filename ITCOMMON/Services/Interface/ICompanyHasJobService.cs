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

        /// <summary>
        /// Get ComapnyHasJob
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        long[] GetComapnyHasJob(long companyId);

        /// <summary>
        /// Delete company has job
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        string deleteCompanyHasJobByJobId(long jobId);
    }
}