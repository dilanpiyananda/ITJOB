﻿using ITCOMMON.Services.Interface;
using ITDB.Domain;
using ITDB.Repository.Class;
using ITDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Class
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo = new CategoryRepository();
        //-------------------------------dropdown--------------------
        /// <summary>
        /// Dropdown
        /// </summary>
        /// <returns></returns>
        public List<NewSelectList> DropDown()
        {
            return _categoryRepo.DropDown();
        }
    }
}