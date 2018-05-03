using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ImageServiceWPF.Model;
using Newtonsoft.Json;
using Prism.Commands;

namespace ImageServiceWPF.VModel
{
    class SettingsViewModel : ISettingsViewModel
    {
        private ISettingsModel model;
        private ObservableCollection<string> handlers;
        public event PropertyChangedEventHandler PropertyChanged;
        private string selectedHandler;
        
        //public ICommand RemoveCommand;

        public SettingsViewModel()
        {
            this.RemoveCommand = new DelegateCommand<object>(this.OnRemove, this.CanRemove);
            this.model = new SettingsModel();
            handlers = new ObservableCollection<string>();
            this.model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                this.NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        private void PropertyChangedRemove(object sender, PropertyChangedEventArgs e)
        {
            var command = this.RemoveCommand as DelegateCommand<object>;
            command.RaiseCanExecuteChanged();
        }

        private void OnRemove(object obj)
        {
            //get from view what was clicked
            this.handlers.Remove(selectedHandler);
            string[] args = { this.selectedHandler };
            string toSend = JsonConvert.SerializeObject(args);
            
            //send to sender
        }

        private bool CanRemove(object arg)
        {
            bool result = this.selectedHandler != null ? true : false;
            return result;
        }

        public ICommand RemoveCommand
        {
            get; private set;
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
                var command = this.RemoveCommand as DelegateCommand<object>;
                command.RaiseCanExecuteChanged();
            }
        }

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

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
