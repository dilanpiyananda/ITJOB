using ITDB.Domain.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Repository.Interface
{
    public interface IJobPostRepository
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
        string JobSave(JobMain job, string userUuid,out long jobId);
    }
}
