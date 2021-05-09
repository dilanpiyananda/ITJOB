using ITDB.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Repository
{
    public interface IComapnyDataService
    {
        /// <summary>
        /// Get Comapny Details using userUuid
        /// </summary>
        Company GetCompanyDetails(string userUuid);

        /// <summary>
        /// Save Company Record and upload and save image
        /// </summary>
        string Save(string userUuid, Company company, HttpPostedFile uploadFile, out int comapanyDetailsId);
    }
}