using ITDB.Domain.Job;
using ITDB.Model.Main_AdoNet;
using ITDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Repository.Class
{
    public class CompanyHasJobRepository: ICompanyHasJobRepository
    {
        /// <summary>
        /// Save company Has Job
        /// </summary>
        /// <returns></returns>
        public string Save(CompanyHasJob job, string userUuid)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                tbl_company_has_job tblModel = new tbl_company_has_job()
                {
                    id = 0,
                    company_id = job.CompanyId,
                    job_main_id = job.JobMainId,
                    
                    added_by = userUuid,
                    update_by = userUuid,
                    added_date = DateTime.Now,
                    update_date = DateTime.Now,
                    is_active = true,
                };
                db.tbl_company_has_job.Add(tblModel);

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
        /// <summary>
        /// Get ComapnyHasJob
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public long[] GetComapnyHasJob(long companyId)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                IQueryable found = db.tbl_company_has_job.Where(d => d.company_id == companyId);

                if (found != null)
                    return MakeComDetails(found, db).Select(d=>d.JobMainId).ToArray();
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
        public List<CompanyHasJob> MakeComDetails(IQueryable found, itjob_mainEntities db)
        {
            var result = (from tbl_company_has_job uc in found                         
                          select new CompanyHasJob
                          {
                              CompanyHasJobId = uc.id,
                              CompanyId = uc.company_id,
                              JobMainId = uc.job_main_id,                           
                              AddedBy = uc.added_by,
                              UpdatedBy = uc.update_by,
                              AddedDate = uc.added_date,
                              UpdatedDate = uc.update_date,
                              IsActive = uc.is_active,
                          }).ToList();

            return result;
        }
    }
}
