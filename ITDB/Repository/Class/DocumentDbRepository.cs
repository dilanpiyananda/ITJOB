using ITDB.Domain.DocumentDom;
using ITDB.Model.Main_AdoNet;
using ITDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITDB.Repository.Class
{
    public class DocumentDbRepository: IDocumentDbRepository
    {
        /// <summary>
        ///Save document
        /// </summary>

        public long[] SaveDocument(List<Document> doc, string userId, out string error)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                List<tbl_document> document = new List<tbl_document>();
                document = doc.Select(d => new tbl_document
                {
                    id = Convert.ToInt32(d.DocumentId),
                    path = d.virtualPath,
                    ResolutionType = d.ResolutionType,
                    added_by = userId,
                    updated_by = userId,
                    added_date = DateTime.Now,
                    updated_date =DateTime.Now,
                    is_active = true,
                }).ToList();

                db.tbl_document.AddRange(document);
                try
                {
                    db.SaveChanges();
                    error = null;
                    return document.Select(d => (long)d.id).ToArray();
                }
                catch (Exception ex)
                {
                    error = ex.Message.ToString();
                    return null;
                }
            }
        }

        /// <summary>
        /// Delete Document
        /// </summary>
        /// <param name="documentIds"></param>
        /// <returns></returns>
        public string DeleteDocument(long[] documentIds)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                var found = db.tbl_document.Where(d => documentIds.Contains(d.id)).ToList();
                if (found.Count() == 0)
                    return "Cant Delete not found Document";

                DeleteServerDocumentFiles(found.Select(x=>x.path).ToArray());

                db.tbl_document.RemoveRange(found);
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

        private void DeleteServerDocumentFiles(string [] filenames)
        {
            foreach(var a in filenames)
            {
                string Directory = HttpContext.Current.Server.MapPath(a);
                FileInfo fileInfo = new FileInfo(Directory);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
            }
            
        }

        /// <summary>
        /// Get Document using Parent Id
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<Document> GetDocument(long parentId)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                IQueryable found = db.tbl_globle_note.Where(d => d.related_id == parentId);

                if (found != null)
                    return MakeComDetails(found, db);
                else
                    return null;

            }
        }

        /// <summary>
        /// DOcument Details Add Domain Model
        /// </summary>
        /// <param name="found"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<Document> MakeComDetails(IQueryable found, itjob_mainEntities db)
        {
            var result = (from tbl_globle_note uc in found
                          from doc in db.tbl_document.Where(x => x.id == uc.document_id).DefaultIfEmpty()
                          select new Document
                          {
                              DocumentId = doc.id,
                              ResolutionType = doc.ResolutionType,
                              virtualPath = doc.path,
                              AddedBy = uc.added_by,
                              UpdatedBy = uc.updated_by,
                              AddedDate = uc.added_date,
                              UpdatedDate = uc.updated_date,
                              IsActive = uc.is_Active,
                          }).ToList();

            return result;
        }
    }
}
