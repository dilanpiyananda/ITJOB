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
    }
}
