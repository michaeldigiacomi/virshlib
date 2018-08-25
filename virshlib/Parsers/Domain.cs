using System;
using System.Collections.Generic;
using System.Text;

using virshlib.Models;

namespace virshlib.Parsers
{
    public class Domain
    {
        public List<DomainModel> ParseModels(string commandText)
        {

            List<DomainModel> DomainList = new List<DomainModel>();
            string[] commandTextSplit = commandText.Split(Environment.NewLine);

            for(int i= 2; i<commandTextSplit.Length; i++)
            {
                string domainText = commandTextSplit[i];
                string[] domainValues = System.Text.RegularExpressions.Regex.Split(domainText, @"\s{2,}");

                DomainModel model = new DomainModel();

                model.ID = domainValues[0].Trim();
                model.Name = domainValues[1].Trim();
                model.Status = domainValues[2].Trim();

                DomainList.Add(model);
            }

            return DomainList;
        }
    }
}
