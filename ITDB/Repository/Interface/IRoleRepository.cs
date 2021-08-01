using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Repository.Interface
{
    public interface IRoleRepository
    {
        /// <summary>
        /// Save Role in User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        string SaveRole(string userId, string RoleName);

        /// <summary>
        /// Get Role using email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        string GetRolebyEmail(string email);
        /// <summary>
        /// Get Role using userId
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        string GetRolebyUserId(string userId);
    }
}
