using ITDB.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Interface
{
    public interface ITagService
    {
        /// <summary>
        /// save Tag
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        string SaveTag(string [] tagName,long jobId, string userId);

        /// <summary>
        /// Delete Tag
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        string DeleteTag(long jobId);

        /// <summary>
        /// UpdateTag
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        string UpdateTag(string[] tagName,long jobId, string userId);

        /// <summary>
        /// Get Tag
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        List<Tag> GetTags(long jobId);
    }
}