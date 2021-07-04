using ITDB.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Repository.Interface
{
    public interface ITagRepository
    {
        /// <summary>
        /// save Tag
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        string SaveTag(string[] tagName, long jobId, string userId, out long[] TagIds);

        /// <summary>
        /// Save job has Tag
        /// </summary>
        /// <param name="TagIds"></param>
        /// <param name="jobId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        string SavejobhasTag(long[] TagIds, long jobId, string userId);

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
        string UpdateTag(string[] tagName, long jobId);

        /// <summary>
        /// Get Tag
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        List<Tag> GetTags(long jobId);
    }
}
