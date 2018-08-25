using System;
using System.Collections.Generic;
using System.Text;

namespace virshlib.Models
{
    public class SystemInfoModel
    {
        public Dictionary<string, string> bios;
        public Dictionary<string, string> system;
        public Dictionary<string, string> baseboard;
        public List<Dictionary<string, string>> processor;
        public List<Dictionary<string, string>> memory;
        public string SuccessMessage;

        public SystemInfoModel()
        {
            bios = new Dictionary<string, string>();
            system = new Dictionary<string, string>();
            baseboard = new Dictionary<string, string>();
            processor = new List<Dictionary<string, string>>();
            memory = new List<Dictionary<string, string>>();

        }
    }
}
