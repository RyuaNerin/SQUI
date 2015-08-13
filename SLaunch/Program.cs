using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SLaunch
{
    class Program
    {
        static void Main(string[] args)
        {
            Process p = new Process();
            p.StartInfo.FileName = "SQUI.exe";
            p.StartInfo.Arguments = "-run";
            p.Start();
        }
    }
}
