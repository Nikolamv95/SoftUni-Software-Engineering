using System;
using System.Collections.Generic;
using System.Text;

namespace MappingObjectsNew.ViewModels
{
    public class SongViewModel
    {
        public string Name { get; set; }
        public string SourceName { get; set; }
        public string Artists { get; set; }
        public DateTime LastModified { get; set; }
    }
}
