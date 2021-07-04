using ITDB.Domain;
using ITDB.Model.Main_AdoNet;
using ITDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Repository.Class
{
    public class TagRepository : ITagRepository
    {
        /// <summary>
        /// save Tag
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public string SaveTag(string[] tagName, long jobId, string userId,out long[] TagIds)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                var dbModel = tagName.Select(d => new tbl_tag
                {
                    TagId = 0,
                    TagName = d.ToString(),
                    added_by = userId.ToString(),
                    added_date = DateTime.Now,
                    is_active = true,
                }).ToList();

                db.tbl_tag.AddRange(dbModel);
                try
                {
                    db.SaveChanges();
                    TagIds = dbModel.Select(d => d.TagId).ToArray();
                    return null;
                }
                catch (Exception ex)
                {
                    TagIds = null;
                    return ex.Message.ToString();
                }

            }
        }

        public string SavejobhasTag( long[] TagIds,long jobId,string userId)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                var dbModel = TagIds.Select(d => new tbl_tag_has_Job
                {
                    tagId = d,
                    jobmainId = jobId,
                    added_by = userId.ToString(),
                    added_date = DateTime.Now,
                    is_active = true,
                });

                db.tbl_tag_has_Job.AddRange(dbModel);
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
        /// Delete Tag
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public string DeleteTag(long jobId)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                var found = db.tbl_tag_has_Job.Where(d => d.jobmainId == jobId).ToList();

                if (found.Count() == 0)
                    return null;
                long[] tagIdArray = found.Select(k => k.tagId).ToArray();
                db.tbl_tag_has_Job.RemoveRange(found);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();
                }

                var foundTag = db.tbl_tag.Where(d => tagIdArray.Contains(d.TagId)).ToList();

                db.tbl_tag.RemoveRange(foundTag);
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
        /// UpdateTag
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public string UpdateTag(string[] tagName, long jobId)
        {
            return null;
        }
        /// <summary>
        /// Get Tag
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public List<Tag> GetTags(long jobId)
        {
            using (itjob_mainEntities db = new itjob_mainEntities())
            {
                IQueryable tags = db.tbl_tag_has_Job.Where(d => d.jobmainId == jobId);

                if (tags != null)
                    return MakeComDetails(tags, db);
                else
                    return null;

            }
        }

        /// <summary>
        /// company Details Add Domain Model
        /// </summary>
        /// <param name="found"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<Tag> MakeComDetails(IQueryable found, itjob_mainEntities db)
        {
            var result = (from tbl_tag_has_Job thj in found
                          from t in db.tbl_tag.Where(x => x.TagId == thj.tagId).DefaultIfEmpty()
                          select new Tag
                          {
                              TagId = t.TagId,
                              TagName = t.TagName,
                              AddedBy = t.added_by,
                              UpdatedBy = t.updated_by,
                              AddedDate = t.added_date,
                              UpdatedDate = t.updated_date,
                              IsActive = t.is_active
                          }).ToList();

            return result;
        }
    }
}
