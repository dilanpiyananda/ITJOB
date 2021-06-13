using ITDB.Domain.Enum;
using ITDB.Domain.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Interface
{
    public interface IJobPostService
    {
        /// <summary>
        /// Get Job using job id
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        JobMain GetJob(long JobId);

        /// <summary>
        /// Get Job using job id
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        List<JobMain> GetJobbyCompanyId(long comapnyId);

        /// <summary>
        /// Get Job using job id
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        List<JobMain> GetJobbyCompanyId(long comapnyId,Approval aproval);

        /// <summary>
        /// Save job
        /// </summary>
        /// <returns></returns>
        string JobSave(JobMain job, string userUuid, HttpPostedFileBase JobImage,long companyId,out long JobsId);

        /// <summary>
        /// Update job
        /// </summary>
        /// <returns></returns>
        string Update(JobMain job, string userUuid, HttpPostedFileBase JobImage, long companyId);
        /// <summary>
        /// Delete job
        /// </summary>
        /// <returns></returns>
        string Delete(long jobId);
    }
}