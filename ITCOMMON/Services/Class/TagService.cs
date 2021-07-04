using ITCOMMON.Services.Interface;
using ITDB.Domain;
using ITDB.Repository.Class;
using ITDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Class
{
    public class TagService: ITagService
    {
        private readonly ITagRepository _tagRepo = new TagRepository();
        /// <summary>
        /// save Tag
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public string SaveTag(string[] tagName, long jobId, string userId)
        {
           string error= _tagRepo.SaveTag(tagName, jobId, userId, out long[] TagIds);
            if (error != null)
                return error;
            return _tagRepo.SavejobhasTag(TagIds, jobId, userId);

        }

        /// <summary>
        /// Delete Tag
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public string DeleteTag(long jobId)
        {
            return _tagRepo.DeleteTag(jobId);
        }

        /// <summary>
        /// UpdateTag
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public string UpdateTag(string[] tagName, long jobId,string userId)
        {
            string error = _tagRepo.DeleteTag(jobId);
            if (error != null)
                return error;

            error= _tagRepo.SaveTag(tagName, jobId, userId, out long[] TagIds);
            if (error != null)
                return error;
            return _tagRepo.SavejobhasTag(TagIds, jobId, userId);
        }

        /// <summary>
        /// Get Tag
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public List<Tag> GetTags(long jobId)
        {
            return _tagRepo.GetTags(jobId);
        }
    }
}