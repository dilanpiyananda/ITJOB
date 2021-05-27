using ITDB.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Repository.Interface
{
    public interface IAcceptEmailRepository
    {
        /// <summary>
        /// Get All Email
        /// </summary>
        /// <returns></returns>
        List<AcceptEmail> GetEmail(long CompanyId);
        /// <summary>
        /// Get Single Email
        /// </summary>
        /// <returns></returns>
        AcceptEmail GetSingleEmail(long emailId);

        /// <summary>
        /// Save Email
        /// </summary>
        /// <returns></returns>
        string SaveEmail(AcceptEmail email, string userUuid, out long emailId);
        /// <summary>
        /// Save Email
        /// </summary>
        /// <returns></returns>
        string EditEmail(AcceptEmail email, string userUuid);
        /// <summary>
        /// Delete Email
        /// </summary>
        /// <returns></returns>
        string DeleteEmail(long emailId, string userUuid);
    }
}
