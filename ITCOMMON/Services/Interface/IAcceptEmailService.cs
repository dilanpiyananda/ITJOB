using ITDB.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Interface
{
    public interface IAcceptEmailService
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
        string SaveEmail(AcceptEmail email, string userUuid, out long emailIds);
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

        //-------------------------Drop Down---------------------------
        /// <summary>
        /// Get drop down
        /// </summary>
        /// <returns></returns>
        List<NewSelectList> DropDown(long CompanyId);

    }
}