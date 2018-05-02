using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageServiceWPF.Model;

namespace ImageServiceWPF.VModel
{
    class SettingsViewModel : ISettingsViewModel
    {
        private ISettingsModel model;
        //public ICommand RemoveCommand;

        public SettingsViewModel()
        {
            this.model = new SettingsModel();
            this.model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                this.NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<string> handlers = new ObservableCollection<string>();
        private string selectedHandler;

        public string VM_OutputDirectory
        {
            get { return this.model.OutputDirectory; }
        }

        public string VM_SourceName
        {
            get { return this.model.SourceName; }
        }

        public string VM_LogName
        {
            get { return this.model.LogName; }
        }

        public int VM_ThumbnailSize
        {
            get { return this.model.ThumbnailSize; }
        }

        public string SelectedHandler
        {
            set
            {
                this.selectedHandler = value;
                this.NotifyPropertyChanged("SelectedHandler");
            }
            get
            {
                return this.selectedHandler;
            }
        }

        private void OnRemove(object obj)
        {
            //send to server that the handler was removed
            this.handlers.Remove(selectedHandler);
            //tell view somehow
        }

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }



        /*
        public string ServerIP
        {
            get { return model.ServerIP; }
            set
            {
                model.ServerIP = value;
                NotifyPropertyChanged("ServerIP");
            }
        }

        public int ServerPort
        {
            get { return model.ServerPort; }
            set
            {
                model.ServerPort = value;
                NotifyPropertyChanged("ServerPort");
            }
        }
        */
    }
}
