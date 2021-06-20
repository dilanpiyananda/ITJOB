using ITDB.Domain.DocumentDom;
using ITDB.Model.Main_AdoNet;
using ITDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Repository.Class
{
    public class GlobleNoteRepository : IGlobleNoteRepository
    {
        /// <summary>
        /// Save GlobleNote
        /// </summary>
        /// <returns></returns>
        public string SaveGlobleNote(List<GlobleNote> globleNote, string userUuid)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                List<tbl_globle_note> globleNotes = new List<tbl_globle_note>();
                globleNotes = globleNote.Select(d => new tbl_globle_note
                {
                    id = d.GlobleNoteId,
                    section_id = d.SectionId,
                    related_id = d.ParentId,
                    document_id = d.DocumentId,
                    added_by = userUuid,
                    updated_by=userUuid,
                    added_date = DateTime.Now,
                    updated_date=DateTime.Now,
                    is_Active = true,
                }).ToList();

                db.tbl_globle_note.AddRange(globleNotes);

                try
                {
                    db.SaveChanges();
                    return null;

                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();

                }
            }
        }
        /// <summary>
        /// Retrive GlobleNote
        /// </summary>
        /// <returns></returns>
        public List<GlobleNote> RetriveGlobleNote(int sectionId, long parentId)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                IQueryable found = db.tbl_globle_note.Where(d => d.section_id == sectionId && d.related_id == parentId);

                if (found != null)
                    return MakeGlobleNote(found, db);
                else
                    return null;

            }
        }

        public List<GlobleNote> MakeGlobleNote(IQueryable found, itjob_mainEntities db)
        {
            var result = (from tbl_globle_note gn in found
                          select new GlobleNote
                          {
                              GlobleNoteId = gn.id,
                              ParentId = gn.related_id,
                              DocumentId = gn.document_id,
                              SectionId = gn.section_id,
                              SystemComment = gn.system_comment,
                              AddedBy = gn.added_by,
                              UpdatedBy = gn.updated_by,
                              AddedDate = gn.added_date,
                              UpdatedDate = gn.updated_date,
                              IsActive = gn.is_Active
                          }).ToList();

            return result;
        }
        /// <summary>
        /// Delete GlobleNote
        /// </summary>
        /// <returns></returns>
        public string DeleteGlobleNote(long[] globleNoteId)
        {

            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                var found = db.tbl_globle_note.Where(d => globleNoteId.Contains(d.id)).ToList();
                if (found.Count() == 0)
                    return "Cant Delete not found globleNote";
                db.tbl_globle_note.RemoveRange(found);
                try
                {
                    db.SaveChanges();
                    return null;

                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();

                }
            }


        }
    }
}
