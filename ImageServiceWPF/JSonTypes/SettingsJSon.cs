using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageServiceWPF.JSonTypes
{
    class SettingsJSon : JSonParse
    {
        public string FromObjToString(object toParse)
        {
            JObject settingsObj = new JObject();
            //settingsObj["OutputDirectory] = 
        }

        public object FromStringToObj(string toParse)
        {
            //SettingsInfo info = new SettingsInfo
            JObject settingsObj = JObject.Parse(toParse);
            SettingsInfo info = new SettingsInfo();
            string outputDirec = (string)settingsObj["OutputDirectory"];
            string sourceName = (string)settingsObj["SourceName"];
            string logName = (string)settingsObj["LogName"];
            int thumbSize = (int)settingsObj["ThumbnailSize"];            
        }
    }
}
