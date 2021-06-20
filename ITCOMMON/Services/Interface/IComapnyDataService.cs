using ITDB.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Interface
{
    public interface IComapnyDataService
    {
        /// <summary>
        /// Get Comapny Details using userUuid
        /// </summary>
        CompanyDom GetCompanyDetails(string userUuid);

        /// <summary>
        /// Get  Company Details by Company Id
        /// </summary>
        /// <param name="userUuid"></param>
        /// <returns></returns>
        CompanyDom GetCompanyDetailsByCompanyId(long companyId);

        /// <summary>
        /// Save Company Record and upload and save image
        /// </summary>
        string Save(string userUuid, CompanyDom company, HttpPostedFileBase uploadFile, out int comapanyDetailsId);
        /// <summary>
        /// Update Company Details
        /// </summary>
        /// <returns></returns>
        string Update(string userUuid, CompanyDom company, HttpPostedFileBase uploadFile);
    }
}