﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageServiceWPF.Model;

namespace ImageServiceWPF.VModel
{
    class SettingsViewModel : ViewModel
    {
        private IModel model;

        public SettingsViewModel()
        {
            this.model = new SettingsModel();
        }
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
    }
}
