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
            framework.Run();
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
                var str = string.Empty;
                for (int i = 0; i < item.Option.FileExtensions.Count; i++)
                {
                    str += item.Option.FileExtensions[i];
                    if (item.Option.FileExtensions.Count - 1 != i)
                    {
                        str += ", ";
                    }
                }
                gen.SubItems.Add(str);
                str = string.Empty;
                for (int i = 0; i < item.Option.IncludeStrings.Count; i++)
                {
                    str += item.Option.IncludeStrings[i];
                    if (item.Option.IncludeStrings.Count - 1 != i)
                    {
                        str += ", ";
                    }
                }
                gen.SubItems.Add(str);
                str = string.Empty;
                for (int i = 0; i < item.Option.DecludeStrings.Count; i++)
                {
                    str += item.Option.DecludeStrings[i];
                    if (item.Option.DecludeStrings.Count - 1 != i)
                    {
                        str += ", ";
                    }
                }
                gen.SubItems.Add(str);
                str = string.Empty;
                for (int i = 0; i < item.Option.OptionStrings.Count; i++)
                {
                    str += item.Option.OptionStrings[i];
                    if (item.Option.OptionStrings.Count - 1 != i)
                    {
                        str += ", ";
                    }
                }
                gen.SubItems.Add(str);
                gen.SubItems.Add((item.Option.isCopy) ? "복사" : "이동");
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
            Setting.Orders.RemoveAt(listView1.SelectedItems[0].Index);
            listView1.Items.Remove(listView1.SelectedItems[0]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var i = listView1.SelectedItems[0].Index;
            var frm = new CreateOrder(Setting.Orders[i], i);
            frm.ShowDialog();
            RefrashOrderList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Setting.Orders[listView1.SelectedItems[0].Index].Enabled = !Setting.Orders[listView1.SelectedItems[0].Index].Enabled;
            RefrashOrderList();
        }
    }
}
