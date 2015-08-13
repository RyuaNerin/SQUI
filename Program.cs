﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SQUI
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                Framework f = new Framework();
                Setting.Load();
                f.Run();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
