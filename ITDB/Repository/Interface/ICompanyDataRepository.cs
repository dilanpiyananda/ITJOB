using ITDB.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Repository.Interface
{
    public interface ICompanyDataRepository
    {
        /// <summary>
        /// Get Comapny Details using userUuid
        /// </summary>
        CompanyDom GetCompanyDetails(string userUuid);
        /// <summary>
        /// Save Company Record and upload and save image
        /// </summary>
        string Save(string userUuid, CompanyDom company, out int comapanyDetailsId);

        /// <summary>
        /// Update Company Details
        /// </summary>
        /// <returns></returns>
        string Update(string userUuid, CompanyDom company);
    }
}
