using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageServiceWPF.JSonTypes
{
    class SettingsInfo
    {
        private string outputDirectory;
        private string logName;
        private string sourceName;
        private int thumbnailSize;

        public string OutputDirectory
        {
            set
            {
                this.outputDirectory = value;
            }
            get
            {
                return this.outputDirectory;
            }
        }
        public string SourceName
        {
            set
            {
                this.sourceName = value;
            }
            get
            {
                return this.sourceName;
            }
        }
        public string LogName
        {
            set
            {
                this.logName = value;
            }
            get
            {
                return this.logName;
            }
        }
        public int ThumbnailSize
        {
            set
            {
                this.thumbnailSize = value;
            }
            get
            {
                return this.thumbnailSize;
            }
        }
    }
}
