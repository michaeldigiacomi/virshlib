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
    public class SystemInfoTests
    {
        [Fact]
        public void TestParse()
        {
            SystemInfo TestParseModel = new SystemInfo();

            string virshSystemInfo = GetInputFile("../../../MockFiles/virshsysinfo.txt");
        
            Console.Write(virshSystemInfo);

            SystemInfoModel result = TestParseModel.Parse(virshSystemInfo);

            Assert.NotNull(result);
        }


        public string GetInputFile(string filename)
        {
            return System.IO.File.ReadAllText(filename);
        }
    }
}
