using System;
using System.Collections.Generic;
using System.Text;

using virshlib.Models;

namespace virshlib.Parsers
{
    public class Domain
    {
        public List<DomainModel> Parse(string commandText)
        {
            Console.WriteLine(commandText);

            List<DomainModel> DomainList = new List<DomainModel>();
            string[] commandTextSplit = commandText.Split(Environment.NewLine);

            Console.WriteLine(commandTextSplit);

            for(int i= 2; i<commandTextSplit.Length; i++)
            {
                try
                {
                    string domainText = commandTextSplit[i];


                    if (string.IsNullOrWhiteSpace(domainText))
                    {
                        Console.WriteLine(domainText);

                        string[] domainValues = System.Text.RegularExpressions.Regex.Split(domainText, @"\s{2,}");

                        DomainModel model = new DomainModel();
                        model.ID = domainValues[0].Trim();
                        model.Name = domainValues[1].Trim();
                        model.Status = domainValues[2].Trim();

                        DomainList.Add(model);
                    }
                }
                catch (Exception error)
                {
                    throw error;
                }
            }

            return DomainList;
        }
    }
}
