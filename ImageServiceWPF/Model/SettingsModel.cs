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

        public void InfoFromService()
        {
            Task task = new Task(() =>
            {
                try
                {
                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
                    TcpClient client = new TcpClient();
                    client.Connect(ep);
                    using (NetworkStream stream = client.GetStream())
                    using (BinaryReader reader = new BinaryReader(stream))
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        writer.Write("GetAppConfig");

                        //change this to JSON
                        this.OutputDirectory = reader.ReadString();
                        this.SourceName = reader.ReadString();
                        this.LogName = reader.ReadString();
                        this.ThumbnailSize = reader.ReadInt32();
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
            task.Start();
        }
    }
}





        /*
        private TcpClient client;

        public string ServerIP { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ServerPort { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void connect(string ip, int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            client = new TcpClient();
            client.Connect(ep);
        }

        public void disconnect()
        {
            try
            {
                client.Close();
            } catch(Exception)
            {
                throw new Exception();
            }
        }

        public string read()
        {
            return "";
            
        }

        public void write(string command)
        {
            NetworkStream stream = client.GetStream();
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(command);
        }
    }
    */
    
