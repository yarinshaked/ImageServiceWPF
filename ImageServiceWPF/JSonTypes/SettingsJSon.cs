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
        private SettingsInfo info;

        public SettingsJSon()
        {
            info = new SettingsInfo();
        }
        /*
        public string FromObjToString(object toParse)
        {
            JObject settingsObj = new JObject();
            settingsObj["OutputDirectory"] = info.OutputDirectory;
            settingsObj["SourceName"] = info.SourceName;
            settingsObj["LogName"] = info.LogName;
            settingsObj["ThumbnailSize"] = info.ThumbnailSize;
            return settingsObj.ToString();
        }
        */

        public object FromStringToObj(string toParse)
        {
            //SettingsInfo info = new SettingsInfo
            JObject settingsObj = JObject.Parse(toParse);
            info.OutputDirectory = (string)settingsObj["OutputDirectory"];
            info.SourceName = (string)settingsObj["SourceName"];
            info.LogName = (string)settingsObj["LogName"];
            info.ThumbnailSize = (int)settingsObj["ThumbnailSize"];
            return this.info;
        }
    }
}
