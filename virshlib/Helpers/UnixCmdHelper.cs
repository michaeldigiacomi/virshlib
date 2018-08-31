using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace virshlib.Helpers
{
    public class UnixCmdHelper
    {
        public string ExecuteShellCMD(string ShellCMD, string Parameters)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ShellCMD,
                    Arguments = Parameters,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();

            string result = process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            return result;
        }
    }
}
