using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ImageServiceWPF.Model
{
    class SettingsModel : ISettingsModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string outputDirectory;
        private string sourceName;
        private string logName;
        private string toSend;
        private int thumbnailSize;


        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }
        public string OutputDirectory
        {
            set
            {
                this.outputDirectory = value;
                this.NotifyPropertyChanged("OutputDirectory");
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
                this.NotifyPropertyChanged("SourceName");
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
                this.NotifyPropertyChanged("LogName");
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
                this.NotifyPropertyChanged("ThumbnailSize");
            }
            get
            {
                return this.thumbnailSize;
            }
        }
    }
}
    
