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
        private readonly IComapnyDataService _compnyDataService = new ComapnyDataService();
        private readonly IDocumentService _documentService = new DocumentService();
        private readonly IDocumentDbService _documentDbService = new DocumentDbService();
        private readonly IGlobleNoteService _globleNoteService = new GlobleNoteService();
        private readonly ITagService _tagService = new TagService();
        /// <summary>
        /// Get Job using job id
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public JobMain GetJob(long JobId)
        {
            var job= _jobPostRepo.GetJob(JobId);
            job.DocumentData = _documentDbService.GetDocument(job.JobMainId);
            long companyId = _compnyHasJobService.GetCompanyId(job.JobMainId);
            job.CompanyDetails = _compnyDataService.GetCompanyDetailsByCompanyId(companyId);
            job.CompanyLogo = _documentDbService.GetDocument(companyId);
            job.TagsList = _tagService.GetTags(job.JobMainId);
            job.TagName = _tagService.GetTags(job.JobMainId).Count() > 0 ? string.Join(",", _tagService.GetTags(job.JobMainId).Select(d => d.TagName).ToList()) : null;
            return job;
        }
        /// <summary>
        /// Get All Job
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public List<JobMain> GetAllJob()
        {
            var job = _jobPostRepo.GetAllJob();
            foreach(var a in job)
            {
                a.DocumentData = _documentDbService.GetDocument(a.JobMainId);
                long companyId = _compnyHasJobService.GetCompanyId(a.JobMainId);
                a.CompanyDetails = _compnyDataService.GetCompanyDetailsByCompanyId(companyId);
                a.CompanyLogo = _documentDbService.GetDocument(companyId);
                a.TagsList = _tagService.GetTags(a.JobMainId);
                a.TagName= _tagService.GetTags(a.JobMainId).Count()>0? string.Join(",", _tagService.GetTags(a.JobMainId).Select(d=>d.TagName).ToList()):null;
            }
            return job;
        }
        /// <summary>
        /// Get All Job
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public List<JobMain> GetAllJob(DateTime startTime, long skipCount)
        {
            var jobs= _jobPostRepo.GetAllJob(startTime,skipCount);
            if (jobs == null)
                return null;

            foreach (var a in jobs)
            {
                a.DocumentData = _documentDbService.GetDocument(a.JobMainId);
                long companyId = _compnyHasJobService.GetCompanyId(a.JobMainId);
                a.CompanyDetails = _compnyDataService.GetCompanyDetailsByCompanyId(companyId);
                a.CompanyLogo = _documentDbService.GetDocument(companyId);
                a.TagsList = _tagService.GetTags(a.JobMainId);
                a.TagName = _tagService.GetTags(a.JobMainId).Count() > 0 ? string.Join(",", _tagService.GetTags(a.JobMainId).Select(d => d.TagName).ToList()) : null;
            }
            return jobs;
        }

        /// <summary>
        /// Get All Job
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public List<JobMain> GetAllJob(DateTime startTime, long skipCount, string serchKey, long categoryId){
            var jobs = _jobPostRepo.GetAllJob(startTime, skipCount, serchKey, categoryId);
            if (jobs == null)
                return null;

            foreach (var a in jobs)
            {
                a.DocumentData = _documentDbService.GetDocument(a.JobMainId);
                long companyId = _compnyHasJobService.GetCompanyId(a.JobMainId);
                a.CompanyDetails = _compnyDataService.GetCompanyDetailsByCompanyId(companyId);
                a.CompanyLogo = _documentDbService.GetDocument(companyId);
                a.TagsList = _tagService.GetTags(a.JobMainId);
                a.TagName = _tagService.GetTags(a.JobMainId).Count() > 0 ? string.Join(",", _tagService.GetTags(a.JobMainId).Select(d => d.TagName).ToList()) : null;
            }
            return jobs;
        }

        /// <summary>
        /// Get All Job
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public List<JobMain> GetAllJob(DateTime startTime, long skipCount, long categoryId)
        {
            var jobs = _jobPostRepo.GetAllJob(startTime, skipCount,categoryId);
            if (jobs == null)
                return null;

            foreach (var a in jobs)
            {
                a.DocumentData = _documentDbService.GetDocument(a.JobMainId);
                long companyId = _compnyHasJobService.GetCompanyId(a.JobMainId);
                a.CompanyDetails = _compnyDataService.GetCompanyDetailsByCompanyId(companyId);
                a.CompanyLogo = _documentDbService.GetDocument(companyId);
                a.TagsList = _tagService.GetTags(a.JobMainId);
                a.TagName = _tagService.GetTags(a.JobMainId).Count() > 0 ? string.Join(",", _tagService.GetTags(a.JobMainId).Select(d => d.TagName).ToList()) : null;
            }
            return jobs;
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
            if(job.TagName != null && job.TagName != "")
            {
                string[] tagsList = job.TagName.Split(',');
               error= _tagService.SaveTag(tagsList, JobsId, userUuid);
                if (error != null)
                    return error;

            }
            

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

            if (job.TagName != null && job.TagName != "")
            {
                string[] tagsList = job.TagName.Split(',');
                error = _tagService.UpdateTag(tagsList, job.JobMainId, userUuid);
                if (error != null)
                    return error;

            }
            else
            {
                error = _tagService.DeleteTag(job.JobMainId);
            }

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
            {
                var jobs = _jobPostRepo.GetJobbyCompanyId(jobId);
                foreach (var a in jobs)
                {
                    a.DocumentData = _documentDbService.GetDocument(a.JobMainId);
                    long companyId = _compnyHasJobService.GetCompanyId(a.JobMainId);
                    a.CompanyDetails = _compnyDataService.GetCompanyDetailsByCompanyId(companyId);
                    a.CompanyLogo = _documentDbService.GetDocument(companyId);
                    a.TagsList = _tagService.GetTags(a.JobMainId);
                    a.TagName = _tagService.GetTags(a.JobMainId).Count() > 0 ? string.Join(",", _tagService.GetTags(a.JobMainId).Select(d => d.TagName).ToList()) : null;
                }
                return jobs;
            }
                
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
            {
                var jobs = _jobPostRepo.GetJobbyCompanyId(jobId, aproval);
                foreach (var a in jobs)
                {
                    a.DocumentData = _documentDbService.GetDocument(a.JobMainId);
                    long companyId = _compnyHasJobService.GetCompanyId(a.JobMainId);
                    a.CompanyDetails = _compnyDataService.GetCompanyDetailsByCompanyId(companyId);
                    a.CompanyLogo = _documentDbService.GetDocument(companyId);
                    a.TagsList = _tagService.GetTags(a.JobMainId);
                    a.TagName = _tagService.GetTags(a.JobMainId).Count() > 0 ? string.Join(",", _tagService.GetTags(a.JobMainId).Select(d => d.TagName).ToList()) : null;
                }
                return jobs;
            }
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