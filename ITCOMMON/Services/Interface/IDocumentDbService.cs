using ITDB.Domain.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Interface
{
    public interface IDocumentDbService
    {
        /// <summary>
        /// Save document db table
        /// </summary>
        long[] SaveDocument(List<DocumentImageList> documentList,string userUuid,out string errordoc);
    }
}