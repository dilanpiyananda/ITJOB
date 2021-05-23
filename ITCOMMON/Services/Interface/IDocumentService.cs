using ITDB.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Interface
{
    public interface IDocumentService
    {
        /// <summary>
        /// Upload Images
        /// </summary>
        /// <returns></returns>
        string UploadImage(HttpPostedFileBase file, Section section,string userId, long parentId);
    }
}