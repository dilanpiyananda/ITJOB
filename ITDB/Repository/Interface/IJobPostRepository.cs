using ITDB.Domain.Enum;
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
        /// Get All Job
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        List<JobMain> GetAllJob();

        /// <summary>
        /// Get All Job
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        List<JobMain> GetAllJob(DateTime startTime, long skipCount);

        /// <summary>
        /// Get Job using job id
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        List<JobMain> GetJobbyCompanyId(long[] jobId);

        /// <summary>
        /// Get All Job
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        List<JobMain> GetAllJob(DateTime startTime, long skipCount, string serchKey, long categoryId);

        /// <summary>
        /// Get All Job
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        List<JobMain> GetAllJob(DateTime startTime, long skipCount, long categoryId);

        /// <summary>
        /// Get Job using job id
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        List<JobMain> GetJobbyCompanyId(long[] jobIds, Approval aproval);

        /// <summary>
        /// Save job
        /// </summary>
        /// <returns></returns>
        string JobSave(JobMain job, string userUuid,out long jobId);

        /// <summary>
        /// Update job
        /// </summary>
        /// <returns></returns>
        string Update(JobMain job, string userUuid);

        /// <summary>
        /// Delete job
        /// </summary>
        /// <returns></returns>
        string Delete(long jobId);
    }
}
