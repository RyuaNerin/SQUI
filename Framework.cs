﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SQUI
{
    class Framework
    {

        public Framework()
        {

        }

        public void Run()
        {
            foreach (var order in Setting.Orders)
            {
                if (order.Enabled)
                {
                    if (!Directory.Exists(order.DepartureFolder))
                    {
                        MessageBox.Show(string.Format("[ {0} ]는 올바른 경로가 아닙니다", order.DepartureFolder));
                        return;
                    }
                    if (!Directory.Exists(order.DestinationFolder))
                    {
                        MessageBox.Show(string.Format("[ {0} ]는 올바른 경로가 아닙니다", order.DestinationFolder));
                        return;
                    }

                    Process(order.DepartureFolder, order);
                }
            }
        }

        void Process(string a_dir, ManagedDirectory order)
        {
            if (order.Option.RootSerach)
            {
                var dirs = Directory.GetDirectories(a_dir);
                foreach (var dir in dirs)
                {
                    Process(dir, order);
                }
            }

            var files = Directory.GetFiles(a_dir);
            foreach (var file in files)
            {
                var fn = Path.GetFileName(file);

                if (isManagedFile(fn, order))
                {
                    var c_dir = a_dir.Replace(order.DepartureFolder, order.DestinationFolder);
                    var dest = Path.Combine(c_dir, fn);
                    if (File.Exists(dest))
                    {
                        bool np = false;
                        switch (order.Option.Duplicate)
                        {
                            case DuplicateProcessing.Overwrite:
                                break;
                            case DuplicateProcessing.Renaming:
                                dest = Path.Combine(
                                     Path.GetDirectoryName(dest),
                                     string.Format(
                                         "{0} ({1}){2}",
                                         Path.GetFileNameWithoutExtension(dest),
                                         DateTime.Now.Ticks,
                                         Path.GetExtension(dest)
                                     )
                                 );
                                break;
                            case DuplicateProcessing.None:
                                np = true;
                                break;
                        }
                        if (np) continue;
                    }
                    if (!Directory.Exists(c_dir)) Directory.CreateDirectory(c_dir);
                    if (order.Option.isCopy)
                    {
                        File.Copy(file, dest, true);
                    }
                    else
                    {
                        File.Move(file, dest);
                    }
                }
            }
        }

        public static bool isManagedFile(string path, ManagedDirectory order)
        {
            bool extensionPass = false;
            bool includePass = true;
            bool decludePass = true;
            bool optionPass = false;

            if (order.Option.FileExtensions.Count == 0)
            {
                extensionPass = true;
            }
            else
            {
                foreach (var item in order.Option.FileExtensions)
                {
                    if (Path.GetExtension(path) == item)
                    {
                        extensionPass = true;
                    }
                }
            }

            foreach (var item in order.Option.IncludeStrings)
            {
                if (!path.Contains(item))
                {
                    includePass = false;
                }
            }


            foreach (var item in order.Option.DecludeStrings)
            {
                if (path.Contains(item))
                {
                    decludePass = false;
                }
            }

            if (order.Option.OptionStrings.Count == 0)
            {
                optionPass = true;
            }
            else
            {
                foreach (var item in order.Option.OptionStrings)
                {
                    if (path.Contains(item))
                    {
                        optionPass = true;
                    }
                }
            }

            return extensionPass & includePass & decludePass & optionPass;
        }
    }
}
