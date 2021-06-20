using ITDB.Domain.DocumentDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Repository.Interface
{
    public interface IGlobleNoteRepository
    {
        /// <summary>
        /// Save GlobleNote
        /// </summary>
        /// <returns></returns>
        string SaveGlobleNote(List<GlobleNote> globleNote,string userUuid);
        /// <summary>
        /// Retrive GlobleNote
        /// </summary>
        /// <returns></returns>
        List<GlobleNote> RetriveGlobleNote(int sectionId, long parentId);
        /// <summary>
        /// Delete GlobleNote
        /// </summary>
        /// <returns></returns>
        string DeleteGlobleNote(long[] globleNoteId);
    }
}
