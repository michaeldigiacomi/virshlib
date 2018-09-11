using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using virshlib.Helpers;
using virshlib.Models;

namespace virshlib.api.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class DomainResManagerController : ControllerBase {
        [HttpGet ("{domain}/{state}")]
        public Dictionary<string, string> Get (EditResourceModel UpdatedResources) {

            UnixCmdHelper _cmd = new UnixCmdHelper ();
            string consoleresponse = "";
            Dictionary<string, string> responseMessage = new Dictionary<string, string> ();

            try {
                foreach (var rec in UpdatedResources.updatedResourceSettings) {
                    switch (rec.Key) {
                        case "CPUs":
                            consoleresponse = _cmd.ExecuteShellCMD ("/usr/bin/virsh", "setvcpus " + UpdatedResources.modelID + " " + rec.Value + " --current");
                            break;
                        case "MaxMemory":
                            consoleresponse = _cmd.ExecuteShellCMD ("/usr/bin/virsh", "setmem " + UpdatedResources.modelID + " " + rec.Value + " --current");
                            break;
                        case "MinMemory":
                            consoleresponse = _cmd.ExecuteShellCMD ("/usr/bin/virsh", "setmemmax " + UpdatedResources.modelID + " " + rec.Value + " --current");
                            break;
                        default:
                            throw new NotImplementedException ();
                    }
                    if (!string.IsNullOrEmpty (consoleresponse.Trim ())) {
                        throw new Exception (consoleresponse);
                    }
                }
                responseMessage.Add ("Result", "Success");
                responseMessage.Add ("Message", "Resources Successfully Updated");

                return responseMessage;

            } catch (Exception error) {
                responseMessage.Clear ();
                responseMessage.Add ("Result", "Error");
                responseMessage.Add ("Message", error.Message);
                return responseMessage;
            }
        }
    }
}