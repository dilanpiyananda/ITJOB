using ITDB.Domain;
using ITDB.Domain.Enum;
using ITDB.Model.Main_AdoNet;
using ITDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Repository.Class
{
    public class CompanyDataRepository : ICompanyDataRepository
    {
        /// <summary>
        /// Get Comapny Details using userUuid
        /// </summary>
        public CompanyDom GetCompanyDetails(string userUuid)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                IQueryable company = db.tbl_user_company_details.Where(d => d.user_id == userUuid);
               
                if (company != null)
                    return MakeComDetails(company, db).FirstOrDefault();
                else
                    return null;

            }
        }
        /// <summary>
        /// Get  Company Details by Company Id
        /// </summary>
        /// <param name="userUuid"></param>
        /// <returns></returns>
        public CompanyDom GetCompanyDetailsByCompanyId(long companyId)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                IQueryable company = db.tbl_user_company_details.Where(d => d.id == companyId);

                if (company != null)
                    return MakeComDetails(company, db).FirstOrDefault();
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
        public List<CompanyDom> MakeComDetails(IQueryable found, itjob_mainEntities db)
        {
            var result = (from tbl_user_company_details uc in found
                          select new CompanyDom
                          {
                              CompanyDetailsId = uc.id,
                              CompanyLogoId = uc.company_logo_Id,
                              CompanyName = uc.company_name,
                              ContactNo = uc.contact_number,
                              WebLink = uc.company_web_link,
                              TrustedId = uc.trust_id,
                              UserId = uc.user_id,
                              SystemComment = uc.system_comment,
                              AddedBy = uc.added_by,
                              UpdatedBy = uc.updated_by,
                              AddedDate = uc.added_date,
                              UpdatedDate = uc.updated_date,
                              IsActive = uc.is_active
                          }).ToList();

            return result;
        }
        /// <summary>
        /// Save Company Record and upload and save image
        /// </summary>
        public string Save(string userUuid, CompanyDom company,out int comapanyDetailsId)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                tbl_user_company_details tblModel = new tbl_user_company_details()
                {
                    id = 0,
                    company_logo_Id = company.CompanyLogoId == null ? 0 : company.CompanyLogoId,
                    company_name = company.CompanyName,
                    company_web_link = company.WebLink,
                    trust_id = (int)TrustEnum.NotDeside,
                    user_id = userUuid,
                    added_by = userUuid,
                    updated_by = userUuid,
                    added_date = DateTime.Now,
                    updated_date = DateTime.Now,
                    is_active = true,
                    contact_number =company.ContactNo,

                };
                db.tbl_user_company_details.Add(tblModel);


                try
                {
                    db.SaveChanges();
                    comapanyDetailsId = tblModel.id;
                    return null;
                }
                catch (Exception ex)
                {
                    comapanyDetailsId = 0;
                    return ex.Message.ToString();
                }
            }
        }

        /// <summary>
        /// Update Company Details
        /// </summary>
        /// <returns></returns>
        public string Update(string userUuid, CompanyDom company)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                var dbobj = db.tbl_user_company_details.Where(d => d.id == company.CompanyDetailsId).FirstOrDefault();
                if (dbobj == null)
                    return "Table is empty";

                dbobj.company_logo_Id =company.CompanyLogoId==null?0: company.CompanyLogoId;
                dbobj.company_name = company.CompanyName;
                dbobj.company_web_link = company.WebLink;
                dbobj.updated_by = userUuid;
                dbobj.contact_number = company.ContactNo;
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
