using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using virshlib.Helpers;
using virshlib.Models;
using virshlib.Parsers;

namespace virshlib.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemInfoController : ControllerBase
    {
        // GET: api/SystemInfo
        [HttpGet]
        public SystemInfoModel Get()
        {
            UnixCmdHelper _cmd = new UnixCmdHelper();

            var response = _cmd.ExecuteShellCMD("/usr/bin/virsh", $"sysinfo");

            return new SystemInfo().Parse(response);
        }
    }
}
