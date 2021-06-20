using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDB.Domain.DocumentDom
{
    public class Document:SystemData
    {
        public long DocumentId { get; set; }
        public string virtualPath { get; set; }
        public int ResolutionType { get; set; }
    }
}
