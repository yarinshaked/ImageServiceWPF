﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageServiceWPF
{
    interface ISettingsModel
    {
        string ServerIP { get; set; }
        int ServerPort { get; set; }
        
    }
}
