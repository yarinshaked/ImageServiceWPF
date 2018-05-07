﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ImageServiceWPF.VModel;

namespace ImageServiceWPF.Controls
{
    /// <summary>
    /// Interaction logic for SettingsControl.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        private ISettingsViewModel vm;

        public SettingsView()
        {
            InitializeComponent();
            this.DataContext = new SettingsViewModel();
        }

    }
}
