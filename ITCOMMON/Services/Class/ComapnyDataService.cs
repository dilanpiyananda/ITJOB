using ITCOMMON.Services.Repository;
using ITDB.Domain;
using ITDB.Repository.Class;
using ITDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Class
{
    public class ComapnyDataService: IComapnyDataService
    {
        private readonly ICompanyDataRepository _CompanyRepo = new CompanyDataRepository();
        /// <summary>
        /// Get Comapny Details using userUuid
        /// </summary>
        public Company GetCompanyDetails(string userUuid)
        {
            return _CompanyRepo.GetCompanyDetails(userUuid);
            var companyDetails = _CompanyRepo.GetCompanyDetails(userUuid);
        }

        /// <summary>
        /// Save Company Record and upload and save image
        /// </summary>
        public string Save(string userUuid, Company company, HttpPostedFile uploadFile, out int comapanyDetailsId)
        {
            string error = _CompanyRepo.Save(userUuid,company, out int comapanyDetailsIdvalue);
            comapanyDetailsId = comapanyDetailsIdvalue;
            return error;
        }
    }
}