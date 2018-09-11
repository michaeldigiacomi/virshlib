using System;
using System.Collections.Generic;
using System.Text;

namespace virshlib.Models
{
    public class EditResourceModel
    {
        public string modelID;
        public Dictionary<string, string> updatedResourceSettings;

        public EditResourceModel(){
            updatedResourceSettings = new Dictionary<string, string>();

        }

        public EditResourceModel(string _modelID){
            updatedResourceSettings = new Dictionary<string, string>();
            modelID = _modelID;

        }
    }
}