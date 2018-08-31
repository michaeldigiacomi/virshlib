using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using virshlib.Models;
using virshlib.Parsers;
using virshlib.Helpers;

namespace virshlib.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainController : ControllerBase
    {
        // GET: api/SystemInfo
        [HttpGet]
        public List<DomainModel> Get()
        {
            UnixCmdHelper _cmd = new UnixCmdHelper();

            var response = _cmd.ExecuteShellCMD("/usr/bin/virsh", $"list --all");

            return new Domain().Parse(response);
        }

        // GET: api/SystemInfo
        [HttpGet]
        public Dictionary<string,string> Get(string Name)
        {
            try
            {
                UnixCmdHelper _cmd = new UnixCmdHelper();

                var response = _cmd.ExecuteShellCMD("/usr/bin/virsh", $"dominfo " + Name);

                return new DomInfo().Parse(response);
            }
            catch(Exception)
            {
                Dictionary<string,string> errorval =  new Dictionary<string, string>();
                errorval.Add("error", "Error Retrieving VM Details");
                return errorval;
            }
        }
    }
}
