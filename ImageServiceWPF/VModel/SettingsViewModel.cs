using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ImageService.Infrastructure.Enums;
using ImageService.Model;
using ImageServiceWPF.Model;
using Newtonsoft.Json;
using Prism.Commands;

namespace ImageServiceWPF.VModel
{
    class SettingsViewModel : ISettingsViewModel
    {
        private ISettingsModel model;
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        public SettingsViewModel()
        {
            this.RemoveCommand = new DelegateCommand<object>(this.OnRemove, this.CanRemove);
            this.model = new SettingsModel();
           
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
            this.model.Handlers.Remove(this.model.SelectedHandler);
            string[] args = { this.model.SelectedHandler };
            CommandReceivedEventArgs eventArgs = new CommandReceivedEventArgs((int) CommandEnum.CloseCommand, args, "" );

            this.model.Connection.Write(eventArgs);
            
            //send to sender
        }

        private bool CanRemove(object arg)
        {
            bool result = this.model.SelectedHandler != null ? true : false;
            return result;
        }

        public ICommand RemoveCommand
        {
            get; private set;
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
