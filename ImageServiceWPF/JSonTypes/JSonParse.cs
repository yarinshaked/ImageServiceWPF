using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageServiceWPF.JSonTypes
{
    interface JSonParse
    {
        object FromStringToObj(string toParse);
        string FromObjToString(object toParse);
    }
}
