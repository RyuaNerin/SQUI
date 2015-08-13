using System;
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
                        MessageBox.Show("[ " + order.DepartureFolder + " ]는 올바른 경로가 아닙니다");
                    }
                    if (!Directory.Exists(order.DestinationFolder))
                    {
                        MessageBox.Show("[ " + order.DestinationFolder + " ]는 올바른 경로가 아닙니다");
                    }

                    var files = Directory.GetFiles(order.DepartureFolder);
                    foreach (var file in files)
                    {
                        var fn = Path.GetFileName(file);

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
                                if (Path.GetExtension(fn).ToLower() == item.ToLower())
                                {
                                    extensionPass = true;
                                }
                            }
                        }

                        foreach (var item in order.Option.IncludeStrings)
                        {
                            if (!fn.Contains(item))
                            {
                                includePass = false;
                            }
                        }


                        foreach (var item in order.Option.DecludeStrings)
                        {
                            if (fn.Contains(item))
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
                                if (fn.Contains(item))
                                {
                                    optionPass = true;
                                }
                            }
                        }

                        if (extensionPass && includePass && decludePass && optionPass)
                        {
                            var dest = order.DestinationFolder + '/' + fn;
                            if (File.Exists(dest))
                            {
                                dest += "(" + DateTime.Now.Ticks + ")";
                            }
                            File.Move(file, dest);
                        }

                    }
                }
            }
        }
    }
}
