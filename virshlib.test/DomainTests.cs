using System;
using Xunit;

using virshlib.Parsers;
using virshlib.Models;

using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace virshlib.test
{
    public class DomainTests
    {
        [Fact]
        public void TestParse()
        {
            Domain TestParseModel = new Domain();

            string virshListFile = GetInputFile("../../../MockFiles/virshlist.txt");
        
            Console.Write(virshListFile);

            List<DomainModel> result = TestParseModel.Parse(virshListFile);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("1", result[0].ID);
        }


        public string GetInputFile(string filename)
        {
            return System.IO.File.ReadAllText(filename);
        }
    }
}
