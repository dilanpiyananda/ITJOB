using ITCOMMON.Services.Interface;
using ITDB.Domain.Enum;
using ITDB.Domain.Job;
using ITDB.Repository.Class;
using ITDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Class
{
    public class JobPostService: IJobPostService
    {
        private readonly IJobPostRepository _jobPostRepo = new JobPostRepository();
        private readonly ICompanyHasJobService _compnyHasJobService = new CompanyHasJobService();
        private readonly IDocumentService _documentService = new DocumentService();
        private readonly IGlobleNoteService _globleNoteService = new GlobleNoteService();
        /// <summary>
        /// Get Job using job id
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public JobMain GetJob(long JobId)
        {
            return _jobPostRepo.GetJob(JobId);
        }

        /// <summary>
        /// Save job
        /// </summary>
        /// <returns></returns>
        public string JobSave(JobMain job, string userUuid, HttpPostedFileBase JobImage, long companyId, out long JobsId)
        {
            string error = _jobPostRepo.JobSave(job, userUuid, out long jobId);
            if (error != null)
            {
                JobsId = 0;
                return error;
            }

            JobsId = jobId;

            CompanyHasJob cojob = new CompanyHasJob()
            {
                JobMainId = jobId,
                CompanyId = companyId,
            };

            error = _compnyHasJobService.Save(cojob,userUuid);
            if(error != null)
            {
                return error;
            }

            if(JobImage != null)
            {
                error = _documentService.UploadImage(JobImage, Section.Job, userUuid, jobId);
            }

            return error;
        }
        /// <summary>
        /// Update job
        /// </summary>
        /// <returns></returns>
        public string Update(JobMain job, string userUuid, HttpPostedFileBase JobImage, long companyId)
        {
            string error = _jobPostRepo.Update(job, userUuid);
            if (error != null)
                return error;

            if (JobImage != null)
            {
                error = _documentService.UploadImage(JobImage, Section.Job, userUuid, job.JobMainId);
            }

            return error;
        }

        /// <summary>
        /// Get Job using job id
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public List<JobMain> GetJobbyCompanyId(long comapnyId)
        {
            long[] jobId = _compnyHasJobService.GetComapnyHasJob(comapnyId);

            if (jobId == null)
                return null;
            else
                return _jobPostRepo.GetJobbyCompanyId(jobId);
        }

        /// <summary>
        /// Get Job using job id
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public List<JobMain> GetJobbyCompanyId(long comapnyId, Approval aproval)
        {
            long[] jobId = _compnyHasJobService.GetComapnyHasJob(comapnyId);

            if (jobId == null)
                return null;
            else
                return _jobPostRepo.GetJobbyCompanyId(jobId, aproval);
        }

        /// <summary>
        /// Delete job
        /// </summary>
        /// <returns></returns>
        public string Delete(long jobId)
        {
            string error = _jobPostRepo.Delete(jobId);

            if (error == null)
                return error;

            error = _globleNoteService.DeleteGlobleNote(Section.Job, jobId);
            error = _compnyHasJobService.deleteCompanyHasJobByJobId(jobId);

            return error;
        }

    }
}