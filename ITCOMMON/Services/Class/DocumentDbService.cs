using ITCOMMON.Services.Interface;
using ITDB.Domain.Document;
using ITDB.Repository.Class;
using ITDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Class
{
    public class DocumentDbService: IDocumentDbService
    {
        private readonly IDocumentDbRepository _docdbRepo = new DocumentDbRepository();
        /// <summary>
        /// Save document db table
        /// </summary>
        public long[] SaveDocument(List<DocumentImageList> documentList, string userUuid, out string errordoc)
        {
            List<Document> document = new List<Document>();
            document = documentList.Select(d => new Document
            {
                DocumentId = 0,
                virtualPath = d.path,
                ResolutionType = (int)d.fileType,
            }).ToList();

            var docarray = _docdbRepo.SaveDocument(document, userUuid, out string error);
            errordoc = error;
            return docarray;
        }
    }
}