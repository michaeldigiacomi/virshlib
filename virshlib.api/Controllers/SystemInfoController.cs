﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            SystemInfo sysinf = new SystemInfo();

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/usr/bin/virsh",
		            Arguments = $"sysinfo",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.Write(result);

            return sysinf.ParseModels(result);
        }
    }
}
