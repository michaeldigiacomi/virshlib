using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using virshlib.Models;

namespace virshlib.Parsers
{
    public class SystemInfo
    {
        public SystemInfoModel ParseModels(string commandText)
        {

            SystemInfoModel SysInfo = new SystemInfoModel();

            XDocument SysInfoDoc = XDocument.Parse(commandText);

            List<Dictionary<string, string>> Processors = new List<Dictionary<string, string>>();
            List<Dictionary<string, string>> MemoryList = new List<Dictionary<string, string>>();


            foreach (XElement nodegroups in SysInfoDoc.Descendants("sysinfo").Nodes())
            {
                switch(nodegroups.Name.LocalName)
                {
                    case "bios":
                        Dictionary<string, string> biosdic = new Dictionary<string, string>();
                        foreach (var desc in nodegroups.Elements())
                        {
                            biosdic.Add(desc.Attribute("name").Value, desc.Value);
                        }
                        SysInfo.bios = biosdic;
                        break;
                    case "system":
                        Dictionary<string, string> systemdic = new Dictionary<string, string>();
                        foreach (var desc in nodegroups.Elements())
                        {
                            systemdic.Add(desc.Attribute("name").Value, desc.Value);
                        }
                        SysInfo.system = systemdic;
                        break;
                    case "processor":
                        Dictionary<string, string> processordic = new Dictionary<string, string>();
                        foreach (var desc in nodegroups.Elements())
                        {
                            processordic.Add(desc.Attribute("name").Value, desc.Value);
                        }
                        Processors.Add(processordic);

                        break;
                    case "baseBoard":
                        Dictionary<string, string> baseboarddic = new Dictionary<string, string>();
                        foreach (var desc in nodegroups.Elements())
                        {
                            baseboarddic.Add(desc.Attribute("name").Value, desc.Value);
                        }
                        SysInfo.baseboard = baseboarddic;
                        break;
                    case "memory_device":
                        Dictionary<string, string> memorydic = new Dictionary<string, string>();
                        foreach (var desc in nodegroups.Elements())
                        {
                            memorydic.Add(desc.Attribute("name").Value, desc.Value);
                        }
                        MemoryList.Add(memorydic);

                        break;
                    default:
                        break;
                }

            }

            SysInfo.processor = Processors;
            SysInfo.memory = MemoryList;

            return SysInfo;
        }
    }
}
