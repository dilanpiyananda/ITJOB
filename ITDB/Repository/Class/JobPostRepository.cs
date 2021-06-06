using ITDB.Domain.Enum;
using ITDB.Domain.Job;
using ITDB.Model.Main_AdoNet;
using ITDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Repository.Class
{
    public class JobPostRepository: IJobPostRepository
    {
        /// <summary>
        /// Get Job using job id
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public JobMain GetJob(long JobId)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                IQueryable found = db.tbl_job_main.Where(d => d.id == JobId);

                if (found != null)
                    return MakeComDetails(found, db).FirstOrDefault();
                else
                    return null;

            }
        }
        /// <summary>
        /// Get Job using job id
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public List<JobMain> GetJobbyCompanyId(long[] jobId)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                IQueryable found = db.tbl_job_main.Where(d => jobId.Contains(d.id));

                if (found != null)
                    return MakeComDetails(found, db);
                else
                    return null;

            }
        }

        /// <summary>
        /// Get Job using job id
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public List<JobMain> GetJobbyCompanyId(long [] jobIds, Approval aproval)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                IQueryable found = db.tbl_job_main.Where(d => jobIds.Contains(d.id) && d.web_approval == (int)aproval);

                if (found != null)
                    return MakeComDetails(found, db);
                else
                    return null;

            }
        }
        /// <summary>
        /// company Details Add Domain Model
        /// </summary>
        /// <param name="found"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<JobMain> MakeComDetails(IQueryable found, itjob_mainEntities db)
        {
            var result = (from tbl_job_main uc in found
                          from pt in db.tbl_company_has_accept_email.Where(x => x.id == uc.cv_accept_email_id).DefaultIfEmpty()
                          from ca in db.tbl_category.Where(x => x.id == uc.category_id).DefaultIfEmpty()
                          select new JobMain
                          {
                              JobMainId = uc.id,
                              JobTypeId = uc.job_type_id,
                              CategoryId = uc.category_id,
                              Category = ca.category,
                              CloseDate = uc.close_date,
                              OpenDate = uc.open_date,
                              CvAcceptEmailId = uc.cv_accept_email_id,
                              CvAcceptEmail = pt.accept_email,
                              Description = uc.description,
                              NumberOfVacancy = uc.number_of_vacancy,
                              Title = uc.title,
                              AddedBy = uc.added_by,
                              UpdatedBy = uc.updated_by,
                              AddedDate = uc.added_date,
                              UpdatedDate = uc.updated_date,
                              IsActive = uc.is_active,
                              JobTypes=(JobType)uc.job_type_id,
                              WebApproval = uc.web_approval,
                              WebApprovaltype=(Approval)uc.web_approval,
                          }).ToList();

            return result;
        }
        /// <summary>
        /// Save job
        /// </summary>
        /// <returns></returns>
        public string JobSave(JobMain job, string userUuid, out long jobId)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                tbl_job_main tblModel = new tbl_job_main()
                {
                    id = 0,
                    job_type_id =(int) job.JobTypes,
                    category_id = job.CategoryId,
                    title = job.Title,
                    description = job.Description,
                    cv_accept_email_id = job.CvAcceptEmailId,
                    close_date = job.CloseDate,
                    open_date = job.OpenDate,
                    number_of_vacancy = job.NumberOfVacancy,                   
                    added_by = userUuid,
                    updated_by = userUuid,
                    added_date = DateTime.Now,
                    updated_date = DateTime.Now,
                    is_active = true,
                    web_approval=(int)Approval.pending,

                };
                db.tbl_job_main.Add(tblModel);


                try
                {
                    db.SaveChanges();
                    jobId = tblModel.id;
                    return null;
                }
                catch (Exception ex)
                {
                    jobId = 0;
                    return ex.Message.ToString();
                }
            }
        }

        /// <summary>
        /// Update job
        /// </summary>
        /// <returns></returns>
        public string Update(JobMain job, string userUuid)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                var dbobj = db.tbl_job_main.Where(d => d.id == job.JobMainId).FirstOrDefault();
                if (dbobj == null)
                    return "Table is empty";


                dbobj.job_type_id = (int)job.JobTypes;
                dbobj.category_id = job.CategoryId;
                dbobj.title = job.Title;
                dbobj.description = job.Description;
                dbobj.cv_accept_email_id = job.CvAcceptEmailId;
                dbobj.close_date = job.CloseDate;
                dbobj.open_date = job.OpenDate;
                dbobj.number_of_vacancy = job.NumberOfVacancy;
                dbobj.updated_by = userUuid;
                dbobj.updated_date = DateTime.Now;

                db.Entry(dbobj).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();

                    return null;
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();
                }
            }
        }
    }
}
