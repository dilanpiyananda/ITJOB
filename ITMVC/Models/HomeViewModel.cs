using ITDB.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMVC.Models
{
    public class HomeViewModel
    {
        public long categoryId { get; set; }
        public List<CategoryMM> Categories { get; set; }
        public string SerchWord { get; set; }
        public List<NewSelectList> CategoryDropDown { get; set; }
    }

    public class CategoryMM : CategoryDom
    {

    }
}