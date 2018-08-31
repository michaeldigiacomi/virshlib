using System;
using System.Collections.Generic;
using System.Text;

namespace virshlib.Parsers
{
    public class DomInfo
    {
        public Dictionary<string, string> Parse (string commandText)
        {

            if (commandText.Contains("error"))
            {
                throw new Exception("Error Getting VM Details");
            }

            string[] commandTextSplit = commandText.Split(Environment.NewLine);
            
	    Dictionary<string, string> DomInfo = new Dictionary<string, string>();

            foreach (string line in commandTextSplit)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] keyval = line.Split(':');
                    DomInfo.Add(keyval[0].Trim().Replace(" ","-"), keyval[1].Trim());
                }
            }

            return DomInfo;
        }
    }
}
