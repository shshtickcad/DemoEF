using System;
using System.Collections.Generic;
using System.Text;

namespace DemoEF.Core.Entity
{
    public class FileMaster
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ClientFilePath { get; set; }
        public DateTime DateUploaded { get; set; }
        public DateTime DateUpdated { get; set; }
        //       public string ServerFilePath { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public long Size { get; set; }
        //        public string CreatedBy { get; set; }
    }
}
