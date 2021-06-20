using ITDB.Domain.DocumentDom;
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
        /// <summary>
        /// Get Document using Parent Id
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        List<Document> GetDocument(long parentId);
    }
}