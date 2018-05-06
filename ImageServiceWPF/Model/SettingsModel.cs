using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ImageService.Infrastructure;
using ImageService.Infrastructure.Enums;
using ImageServiceWPF.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ImageServiceWPF.Model
{
    class SettingsModel : ISettingsModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<string> handlers;
        private string outputDirectory;
        private string sourceName;
        private string logName;
        private string toSend;
        private int thumbnailSize;
        private string selectedHandler;
        private IClientConnection connection;
        private bool isConnected;

        public SettingsModel()
        {
            handlers = new ObservableCollection<string>();
            this.Connection.DataReceived += OnDataReceived;
            isConnected = this.Connection.Connect();
            this.Connection.Read();
        }

        public bool IsConnected
        {
            get
            {
                return this.isConnected;
            }
            set
            {
                this.isConnected = value;
            }
        }

        public IClientConnection Connection
        {
            get
            {
                return ClientConnection.Instance;
            }
        }

        public ObservableCollection<string> Handlers
        {
            get
            {
                return this.handlers;
            }
            set
            {
                this.handlers = value;
            }
        }

        public void OnDataReceived(object sender, CommandMessage message)
        {
            //if (message.CommandID.Equals(CommandEnum.GetConfigCommand.ToString()))
            {
                this.OutputDirectory = (string) message.CommandArgs["OutputDirectory"];
                this.SourceName = (string) message.CommandArgs["SourceName"];
                this.LogName = (string) message.CommandArgs["LogName"];
                this.ThumbnailSize = (int) message.CommandArgs["ThumbnailSize"];
                JArray arr = (JArray) message.CommandArgs["Handlers"];
                string[] array = arr.Select(c => (string)c).ToArray();
                foreach (var item in array)
                {
                    this.Handlers.Add(item);
                }
                
            }
        }   
        
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

        public string SelectedHandler
        {
            get
            {
                return this.selectedHandler;
            }
            set
            {
                selectedHandler = value;
                this.NotifyPropertyChanged("SelectedHandler");
            }
        }
    }
}
    
