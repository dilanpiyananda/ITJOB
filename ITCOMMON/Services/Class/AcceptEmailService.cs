using ITCOMMON.Services.Interface;
using ITDB.Domain;
using ITDB.Repository.Class;
using ITDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Class
{
    public class AcceptEmailService: IAcceptEmailService
    {
        private readonly IAcceptEmailRepository _emailRepo = new AcceptEmailRepository();
        /// <summary>
        /// Get All Email
        /// </summary>
        /// <returns></returns>
        public List<AcceptEmail> GetEmail(long CompanyId)
        {
            return _emailRepo.GetEmail(CompanyId);
        }
        /// <summary>
        /// Get Single Email
        /// </summary>
        /// <returns></returns>
        public AcceptEmail GetSingleEmail(long emailId)
        {
            return _emailRepo.GetSingleEmail(emailId);
        }
        /// <summary>
        /// Save Email
        /// </summary>
        /// <returns></returns>
        public string SaveEmail(AcceptEmail email, string userUuid, out long emailIds)
        {
            var error = _emailRepo.SaveEmail(email, userUuid, out long emailId);
            emailIds = emailId;
            return error;
        }

        /// <summary>
        /// Save Email
        /// </summary>
        /// <returns></returns>
        public string EditEmail(AcceptEmail email, string userUuid)
        {
            return _emailRepo.EditEmail(email, userUuid);
        }
        /// <summary>
        /// Delete Email
        /// </summary>
        /// <returns></returns>
        public string DeleteEmail(long emailId, string userUuid)
        {
            return _emailRepo.DeleteEmail(emailId, userUuid);
        }
    }
}