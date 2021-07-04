using ITDB.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Repository.Interface
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Get All Category
        /// </summary>
        /// <returns></returns>
        List<CategoryDom> GetAllCategory();

        //-------------------------------dropdown--------------------
        /// <summary>
        /// Dropdown
        /// </summary>
        /// <returns></returns>
        List<NewSelectList> DropDown();
    }
}
