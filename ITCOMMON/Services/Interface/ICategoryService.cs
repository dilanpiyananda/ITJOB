using ITDB.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Interface
{
    public interface ICategoryService
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