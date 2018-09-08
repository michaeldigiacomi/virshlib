using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using virshlib.Helpers;

namespace virshlib.api.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class DomainStateController : ControllerBase {
        // GET: api/DomainState/5
        [HttpGet ("{domain}/{state}")]
        public Dictionary<string, string> Get (string domain, string state) {
            UnixCmdHelper _cmd = new UnixCmdHelper ();

            Console.WriteLine (state);

            string consoleresponse = "";

            try {

                switch (state.Trim ()) {
                    case "Start":
                        consoleresponse = _cmd.ExecuteShellCMD ("/usr/bin/virsh", "start " + domain);
                        break;
                    case "Shutdown":
                        consoleresponse = _cmd.ExecuteShellCMD ("/usr/bin/virsh", "shutdown " + domain);
                        break;
                    case "Suspend":
                        consoleresponse = _cmd.ExecuteShellCMD ("/usr/bin/virsh", "suspend --domain " + domain);
                        break;
                    case "ForceReset":
                        consoleresponse = _cmd.ExecuteShellCMD ("/usr/bin/virsh", "reset " + domain);
                        break;
                    case "ForceShutdown":
                        consoleresponse = _cmd.ExecuteShellCMD ("/usr/bin/virsh", "destroy " + domain);
                        break;
                    default:
                        throw new Exception ("Error: Action Not Supported.");
                }

                Dictionary<string, string> restresponse = new Dictionary<string, string> ();
                restresponse.Add ("Result", "Success");
                restresponse.Add ("Message", consoleresponse);

                return restresponse;

            } catch (Exception error) {
                Dictionary<string, string> restresponse = new Dictionary<string, string> ();
                restresponse.Add ("Result", "Error");
                restresponse.Add ("Message", error.Message);

                return restresponse;
            }
        }
    }
}