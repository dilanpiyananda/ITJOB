using ITCOMMON.Services.Interface;
using ITDB.Domain.Document;
using ITDB.Domain.Enum;
using ITDB.Repository.Class;
using ITDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Class
{
    public class GlobleNoteService: IGlobleNoteService
    {
        private readonly IGlobleNoteRepository _globleNoteRepo = new GlobleNoteRepository();
        private readonly IDocumentDbRepository _documentDbRepo = new DocumentDbRepository();
        /// <summary>
        /// Save GlobleNote
        /// </summary>
        public string SaveGlobleNote(Section section, long[] docIdArray, string userUuid, long parentId)
        {
            List<GlobleNote> GlobleNoteList = new List<GlobleNote>();

            GlobleNoteList = docIdArray.ToList().Select(d => new GlobleNote
            {
                GlobleNoteId =0,
                DocumentId = d,
                ParentId = parentId,
                SectionId = (int)section,
            }).ToList();

            var globleNotepast = _globleNoteRepo.RetriveGlobleNote((int)section,parentId);

            if(globleNotepast.Count() > 0)
            {
                string error = _globleNoteRepo.DeleteGlobleNote(globleNotepast.Select(d=>d.GlobleNoteId).ToArray());
                if (error != null)
                    return error;
                error = _documentDbRepo.DeleteDocument(globleNotepast.Select(d => d.DocumentId).ToArray());
                if (error != null)
                    return error;
            }

            return _globleNoteRepo.SaveGlobleNote(GlobleNoteList,userUuid);

        }

        /// <summary>
        /// Delete Globle Note
        /// </summary>
        public string DeleteGlobleNote(Section section, long parentId)
        {
            var globleNotepast = _globleNoteRepo.RetriveGlobleNote((int)section, parentId);

            if (globleNotepast.Count() > 0)
            {
                string error = _globleNoteRepo.DeleteGlobleNote(globleNotepast.Select(d => d.GlobleNoteId).ToArray());
                if (error != null)
                    return error;
                error = _documentDbRepo.DeleteDocument(globleNotepast.Select(d => d.DocumentId).ToArray());
                if (error != null)
                    return error;
            }
            return null;
        }
    }
}