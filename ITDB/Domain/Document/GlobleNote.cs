using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Domain.Document
{
    public class GlobleNote:SystemData
    {
        public long GlobleNoteId { get; set; }
        public long ParentId { get; set; }
        public long DocumentId { get; set; }
        public int SectionId { get; set; }
    }
}
