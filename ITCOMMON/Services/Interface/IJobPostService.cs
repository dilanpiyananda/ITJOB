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
        /// Save job
        /// </summary>
        /// <returns></returns>
        string JobSave(JobMain job, string userUuid, HttpPostedFileBase JobImage,long companyId,out long JobsId);
    }
}