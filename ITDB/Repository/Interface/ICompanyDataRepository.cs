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
        Company GetCompanyDetails(string userUuid);
        /// <summary>
        /// Save Company Record and upload and save image
        /// </summary>
        string Save(string userUuid, Company company, out int comapanyDetailsId);
    }
}
