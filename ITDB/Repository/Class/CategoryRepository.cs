using ITDB.Domain;
using ITDB.Model.Main_AdoNet;
using ITDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Repository.Class
{
    public class CategoryRepository: ICategoryRepository
    {
        //-------------------------------dropdown--------------------
        /// <summary>
        /// Dropdown
        /// </summary>
        /// <returns></returns>
        public List<NewSelectList> DropDown()
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                var result = (from tbl_category c in db.tbl_category.Where(d => d.is_active == true)
                              select new NewSelectList
                              {
                                  Id = c.id,
                                  value = c.category,
                              }).ToList();
                return result;
            }
                
        }
    }
}
