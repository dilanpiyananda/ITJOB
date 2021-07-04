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
        /// <summary>
        /// Get All Category
        /// </summary>
        /// <returns></returns>
        public List<CategoryDom> GetAllCategory()
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                IQueryable found = db.tbl_category;

                if (found != null)
                    return MakeComDetails(found, db);
                else
                    return null;

            }
        }

        public List<CategoryDom> MakeComDetails(IQueryable found, itjob_mainEntities db)
        {
            var result = (from tbl_category uc in found                          
                          select new CategoryDom
                          {
                              Id = uc.id,
                              Category = uc.category,
                              AddedBy = uc.added_by,
                              UpdatedBy = uc.update_by,
                              AddedDate = uc.added_date,
                              UpdatedDate = uc.update_date,
                              IsActive = uc.is_active,
                          }).ToList();

            return result;
        }
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
