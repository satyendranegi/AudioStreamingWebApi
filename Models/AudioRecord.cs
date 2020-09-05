using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudioStreaming.Models
{
    public class AudioRecord
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public Nullable<System.DateTime> DateAddedd { get; set; }
    }
}