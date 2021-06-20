using ITDB.Domain.DocumentDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Repository.Interface
{
    public interface IDocumentDbRepository
    {
        long[] SaveDocument(List<Document> doc, string userId, out string error);

        /// <summary>
        /// Delete Document
        /// </summary>
        /// <param name="documentIds"></param>
        /// <returns></returns>
        string DeleteDocument(long[] documentIds);

        /// <summary>
        /// Get Document using Parent Id
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        List<Document> GetDocument(long parentId);
    }
}
