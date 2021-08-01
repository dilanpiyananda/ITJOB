using ITCOMMON.Services.Interface;
using ITDB.Repository.Class;
using ITDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Class
{
    public class RoleMenualService:IRoleMenualService
    {
        private readonly IRoleRepository _roleRepository = new RoleRepository();
        /// <summary>
        /// Save Role in User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        public string SaveRole(string userId, string RoleName)
        {
            return _roleRepository.SaveRole(userId, RoleName);
        }

        /// <summary>
        /// Get Role using email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string GetRolebyEmail(string email)
        {
            return _roleRepository.GetRolebyEmail(email);
        }

        /// <summary>
        /// Get Role using userId
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string GetRolebyUserId(string userId)
        {
            return _roleRepository.GetRolebyUserId(userId);
        }
    }
}