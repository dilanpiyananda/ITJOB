using ITDB.Domain.Enum;
using ITDB.Model.Login_AdoNet;
using ITDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Repository.Class
{
    public class RoleRepository: IRoleRepository
    {
        /// <summary>
        /// Save Role in User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        public string SaveRole(string userId, string RoleName)
        {
            SaveNewGUIDRole();
            using (LoginEntities db = new LoginEntities())
            {
                tbl_user_has_role userRole = new tbl_user_has_role()
                {
                    userId = userId,
                    roleId = db.AspNetRoles.Where(d=>d.Name==RoleName).FirstOrDefault().Id,                    
                };
                db.tbl_user_has_role.Add(userRole);


                try
                {
                    db.SaveChanges();
                    return null;
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();
                }
            }
        }

        private string SaveNewGUIDRole()
        {
            using (LoginEntities db = new LoginEntities())
            {
                List<AspNetRole> _Roles = new List<AspNetRole>();
                
                for (int i = 0; i < 4; i++)
                {
                    Guid obj = Guid.NewGuid();
                    AspNetRole role = new AspNetRole()
                    {
                        Id = obj.ToString(),
                        Name = ((RoleDetails)i).ToString(),
                    };
                    _Roles.Add(role);
                }

                db.AspNetRoles.AddRange(_Roles);


                try
                {
                    db.SaveChanges();
                    return null;
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();
                }
            }
              
        }
        /// <summary>
        /// Get Role using email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string GetRolebyEmail(string email)
        {
            using (LoginEntities db = new LoginEntities())
            {
                var user = db.AspNetUsers.Where(d => d.Email == email).FirstOrDefault();
                if(user != null)
                {
                    return getRoleNameUsingRoleID(user.Id);
                }
                else
                {
                    return null;
                }
            }
            
        }
        /// <summary>
        /// Get Role using userId
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string GetRolebyUserId(string userId)
        {
           return getRoleNameUsingRoleID(userId);
        }

        private string getRoleNameUsingRoleID(string userId)
        {
            using (LoginEntities db = new LoginEntities())
            {
                var roles = db.tbl_user_has_role.Where(d => d.userId == userId).FirstOrDefault();
                string roleName = null;
                if (roles != null)
                {
                    var roleData = db.AspNetRoles.Where(d => d.Id == roles.roleId).FirstOrDefault();
                    if (roleData != null)
                    {
                        roleName = roleData.Name;
                    }
                }

                return roleName;
            }
        }
    }
}
