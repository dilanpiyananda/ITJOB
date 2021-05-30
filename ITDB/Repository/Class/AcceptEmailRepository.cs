using ITDB.Domain;
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
    public class AcceptEmailRepository: IAcceptEmailRepository
    {
        /// <summary>
        /// Get All Email
        /// </summary>
        /// <returns></returns>
        public List<AcceptEmail> GetEmail(long CompanyId)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                IQueryable found = db.tbl_company_has_accept_email;

                if (found != null)
                    return MakeComDetails(found, db);
                else
                    return null;

            }
        }

        private List<AcceptEmail> MakeComDetails(IQueryable found, itjob_mainEntities db)
        {
            var result = (from tbl_company_has_accept_email uc in found
                          select new AcceptEmail
                          {
                              AcceptEmailId = uc.id,
                              CompanyId = uc.company_id,
                              EmailAddress = uc.accept_email,
                              SystemComment = uc.system_comment,
                              AddedBy = uc.added_by,
                              UpdatedBy = uc.update_by,
                              AddedDate = uc.added_date,
                              UpdatedDate = uc.update_date,
                              IsActive = uc.is_active
                          }).ToList();

            return result;
        }
        /// <summary>
        /// Get Single Email
        /// </summary>
        /// <returns></returns>
        public AcceptEmail GetSingleEmail(long emailId)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                IQueryable found = db.tbl_company_has_accept_email.Where(d=>d.id == emailId);

                if (found != null)
                    return MakeComDetails(found, db).FirstOrDefault();
                else
                    return null;

            }
        }
        /// <summary>
        /// Save Email
        /// </summary>
        /// <returns></returns>
        public string SaveEmail(AcceptEmail email, string userUuid, out long emailId)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                tbl_company_has_accept_email tblModel = new tbl_company_has_accept_email()
                {
                    id = 0,
                    company_id = email.CompanyId,
                    accept_email = email.EmailAddress,
                    system_comment = "Save",
                    added_by = userUuid,
                    update_by = userUuid,
                    added_date = DateTime.Now,
                    update_date = DateTime.Now,
                    is_active = true,

                };
                db.tbl_company_has_accept_email.Add(tblModel);


                try
                {
                    db.SaveChanges();
                    emailId = tblModel.id;
                    return null;
                }
                catch (Exception ex)
                {
                    emailId = 0;
                    return ex.Message.ToString();
                }
            }
        }

        /// <summary>
        /// Save Email
        /// </summary>
        /// <returns></returns>
        public string EditEmail(AcceptEmail email, string userUuid)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                var dbobj = db.tbl_company_has_accept_email.Where(d => d.id == email.AcceptEmailId).FirstOrDefault();
                if (dbobj == null)
                    return "Table is empty";

               
                dbobj.company_id = email.CompanyId;
                dbobj.accept_email = email.EmailAddress;
                dbobj.update_by = userUuid;
                dbobj.system_comment = "Update";
                dbobj.update_date = DateTime.Now;

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
        /// <summary>
        /// Delete Email
        /// </summary>
        /// <returns></returns>
        public string DeleteEmail(long emailId, string userUuid)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                var found = db.tbl_company_has_accept_email.Where(d => d.id == emailId).FirstOrDefault();
                if (found == null)
                    return "Cant Delete not found Email";

                db.tbl_company_has_accept_email.Remove(found);
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

        //-------------------------Drop Down---------------------------
        /// <summary>
        /// Get drop down
        /// </summary>
        /// <returns></returns>
        public List<NewSelectList> DropDown(long CompanyId)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                var result = (from tbl_company_has_accept_email c in db.tbl_company_has_accept_email.Where(d => d.is_active == true && d.company_id == CompanyId)
                              select new NewSelectList
                              {
                                  Id = c.id,
                                  value = c.accept_email,
                              }).ToList();
                return result;
            }
        }
    }
}
