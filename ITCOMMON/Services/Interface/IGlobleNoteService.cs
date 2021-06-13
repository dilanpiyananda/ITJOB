using ITDB.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Interface
{
    public interface IGlobleNoteService
    {
        /// <summary>
        /// Save GlobleNote
        /// </summary>
        string SaveGlobleNote(Section section, long [] docIdArray,string userUuid,long parentId);

        /// <summary>
        /// Delete Globle Note
        /// </summary>
        string DeleteGlobleNote(Section section, long parentId);
    }
}