using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQUI
{
    public partial class MainForm : Form
    {
        Framework framework = new Framework();

        public MainForm()
        {
            InitializeComponent();
            Setting.Load();
            RefrashOrderList();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            frameworkRunner.RunWorkerAsync();
            RunButton.Enabled = button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = listView1.Enabled = false;

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Setting.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new CreateOrder();
            frm.ShowDialog();
            RefrashOrderList();
        }

        private void RefrashOrderList()
        {
            listView1.Items.Clear();
            foreach (var item in Setting.Orders)
            {
                var gen = new ListViewItem((item.Enabled) ? "켜짐" : "꺼짐");
                gen.SubItems.Add(item.DepartureFolder);
                gen.SubItems.Add(item.DestinationFolder);
                var sb = new StringBuilder();
                for (int i = 0; i < item.Option.FileExtensions.Count; i++)
                {
                    sb.Append(item.Option.FileExtensions[i]);
                    if (item.Option.FileExtensions.Count - 1 != i)
                    {
                        sb.Append(", ");
                    }
                }
                gen.SubItems.Add(sb.ToString());
                if (sb.Length > 0) sb.Remove(0, sb.Length);

                for (int i = 0; i < item.Option.IncludeStrings.Count; i++)
                {
                    sb.Append(item.Option.IncludeStrings[i]);
                    if (item.Option.IncludeStrings.Count - 1 != i)
                    {
                        sb.Append(", ");
                    }
                }
                gen.SubItems.Add(sb.ToString());
                if (sb.Length > 0) sb.Remove(0, sb.Length);

                for (int i = 0; i < item.Option.DecludeStrings.Count; i++)
                {
                    sb.Append(item.Option.DecludeStrings[i]);
                    if (item.Option.DecludeStrings.Count - 1 != i)
                    {
                        sb.Append(", ");
                    }
                }
                gen.SubItems.Add(sb.ToString());
                if (sb.Length > 0) sb.Remove(0, sb.Length);

                for (int i = 0; i < item.Option.OptionStrings.Count; i++)
                {
                    sb.Append(item.Option.OptionStrings[i]);
                    if (item.Option.OptionStrings.Count - 1 != i)
                    {
                        sb.Append(", ");
                    }
                }
                gen.SubItems.Add(sb.ToString());
                gen.SubItems.Add((item.Option.isCopy) ? "복사" : "이동");

                var dpstr = string.Empty;
                if (item.Option.Duplicate == DuplicateProcessing.Overwrite)
                {
                    dpstr = Properties.Resources.OverwriteString;
                }
                else if (item.Option.Duplicate == DuplicateProcessing.Renaming)
                {
                    dpstr = Properties.Resources.RenamingString;
                }
                else if (item.Option.Duplicate == DuplicateProcessing.None)
                {
                    dpstr = Properties.Resources.NoneString;
                }
                gen.SubItems.Add(dpstr);
                gen.SubItems.Add((item.Option.RootSerach) ? "포함" : "미포함");
                listView1.Items.Add(gen);
            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Setting.Orders.RemoveAt(listView1.SelectedItems[0].Index);
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Setting.Orders.RemoveAt(listView1.SelectedItems[0].Index);
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var i = listView1.SelectedItems[0].Index;
                var frm = new CreateOrder(Setting.Orders[i], i);
                frm.ShowDialog();
                RefrashOrderList();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var rep = Setting.Orders[listView1.SelectedItems[0].Index];
                Setting.Orders[listView1.SelectedItems[0].Index].Enabled = !rep.Enabled;

                if (rep.Option.RealtimeWatch)
                {
                    if (rep.Enabled)
                    {
                        Watcher.Start(rep.WatcherIndex);
                    }
                    else
                    {
                        Watcher.Stop(rep.WatcherIndex);
                    }
                }
                RefrashOrderList();
            }
        }

        private void frameworkRunner_DoWork(object sender, DoWorkEventArgs e)
        {
            framework.Run();
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    RunButton.Enabled = button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = listView1.Enabled = true;
                }));
            }
        }
    }
}
