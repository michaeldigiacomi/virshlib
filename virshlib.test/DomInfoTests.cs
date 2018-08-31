using System;
using Xunit;

using virshlib;
using virshlib.Models;
using virshlib.Parsers;

using System.IO;
using System.Reflection;
using System.Collections.Generic;


namespace virshlib.test
{
    public class DomInfoTests
    {
        [Fact]
        public void TestParse()
        {
            DomInfo DomInfoParser = new DomInfo();

            string virshSystemInfo = GetInputFile("..\\..\\..\\MockFiles\\dominfo.txt");
        
            Console.Write(virshSystemInfo);

            Dictionary<string,string> result = DomInfoParser.Parse(virshSystemInfo);

            Assert.NotNull(result);
            Assert.True(result.ContainsKey("Name"));
        }


        public string GetInputFile(string filename)
        {
            return System.IO.File.ReadAllText(filename);
        }
    }
}
