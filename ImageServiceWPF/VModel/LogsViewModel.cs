using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageServiceWPF.Model;

namespace ImageServiceWPF.VModel
{
    class LogsViewModel : ViewModel
    {
        private IModel model;
        public LogsViewModel()
        {
            model = new LogsModel();
        }
    }
}
