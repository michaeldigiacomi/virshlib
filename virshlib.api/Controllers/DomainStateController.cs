using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using virshlib.Helpers;

namespace virshlib.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainStateController : ControllerBase
    {
        // GET: api/DomainState/5
        [HttpGet("{domain}/{action}", Name = "Get")]
        public string Get(string domain, string action)
        {
            UnixCmdHelper _cmd = new UnixCmdHelper();

            switch (action)
            {
                case "Start":
                    return _cmd.ExecuteShellCMD("/usr/bin/virsh", "start " + domain);
                case "ShutDown":
                    return _cmd.ExecuteShellCMD("/usr/bin/virsh", "shutdown " + domain);
                case "Suspend":
                    return _cmd.ExecuteShellCMD("/usr/bin/virsh", "suspend --domain " + domain);
                default:
                    return "Error: Action Not Supported.";
            }
        }
    }
}
