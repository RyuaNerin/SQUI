using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQUI
{
    public partial class CreateOrder : Form
    {
        int index;
        public CreateOrder()
        {
            InitializeComponent();
            folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.dubCombobox.Text = Properties.Resources.OverwriteString;
            index = -1; // new
        }

        public CreateOrder(ManagedDirectory d, int index)
        {
            InitializeComponent();
            folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.index = index;
            if(d.WatcherIndex > 0)
            {
                Watcher.Stop(d.WatcherIndex);
                Watcher.Remove(d.WatcherIndex);
            }

            TextBoxdeparture.Text = d.DepartureFolder;
            TextBoxDestination.Text = d.DestinationFolder;
            
            var sb = new StringBuilder();
            if (d.Option.FileExtensions.Count > 0)
            {
                CheckBoxFileExtensions.Checked = true;
                TextBoxFileExtensions.Enabled = true;
                for (int i = 0; i < d.Option.FileExtensions.Count; i++)
                {
                    sb.Append(d.Option.FileExtensions[i]);
                    if (d.Option.FileExtensions.Count - 1 != i)
                    {
                        sb.Append(' ');
                    }
                }
                TextBoxFileExtensions.Text = sb.ToString();
                if (sb.Length > 0) sb.Remove(0, sb.Length);
            }
            if (d.Option.IncludeStrings.Count > 0)
            {
                CheckBoxIncludes.Checked = true;
                TextBoxInclude.Enabled = true;
                for (int i = 0; i < d.Option.IncludeStrings.Count; i++)
                {
                    sb.Append(d.Option.IncludeStrings[i]);
                    if (d.Option.IncludeStrings.Count - 1 != i)
                    {
                        sb.Append(' ');
                    }
                }
                TextBoxInclude.Text = sb.ToString();
                if (sb.Length > 0) sb.Remove(0, sb.Length);
            }
            if (d.Option.DecludeStrings.Count > 0)
            {
                CheckBoxDecludeStrings.Checked = true;
                TextBoxDecludeStrings.Enabled = true;
                for (int i = 0; i < d.Option.DecludeStrings.Count; i++)
                {
                    sb.Append(d.Option.DecludeStrings[i]);
                    if (d.Option.DecludeStrings.Count - 1 != i)
                    {
                        sb.Append(' ');
                    }
                }
                TextBoxInclude.Text = sb.ToString();
                if (sb.Length > 0) sb.Remove(0, sb.Length);
            }
            if (d.Option.OptionStrings.Count > 0)
            {
                CheckBoxOptions.Checked = true;
                TextBoxOptionStrings.Enabled = true;
                for (int i = 0; i < d.Option.OptionStrings.Count; i++)
                {
                    sb.Append(d.Option.OptionStrings[i]);
                    if (d.Option.OptionStrings.Count - 1 != i)
                    {
                        sb.Append(' ');
                    }
                }
                TextBoxOptionStrings.Text = sb.ToString();
            }

            RadioIsCopy.Checked = d.Option.isCopy;
            RadioIsMove.Checked = !d.Option.isCopy;

            if(d.Option.Duplicate == DuplicateProcessing.Overwrite)
            {
                
                dubCombobox.Text = Properties.Resources.OverwriteString;
            }
            else if(d.Option.Duplicate == DuplicateProcessing.Renaming)
            {
                dubCombobox.Text = Properties.Resources.RenamingString;
            }
            else if(d.Option.Duplicate == DuplicateProcessing.None)
            {
                dubCombobox.Text = Properties.Resources.NoneString;
            }

            RootSearch.Checked = d.Option.RootSerach;
            RealTimeWatchService.Checked = d.Option.RealtimeWatch;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextBoxdeparture.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextBoxDestination.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxInclude.Enabled = CheckBoxIncludes.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxOptionStrings.Enabled = CheckBoxOptions.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxDecludeStrings.Enabled = CheckBoxDecludeStrings.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxFileExtensions.Enabled = CheckBoxFileExtensions.Checked;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CheckBoxIncludes.Checked == false) TextBoxInclude.Text = string.Empty;
            if (CheckBoxOptions.Checked == false) TextBoxOptionStrings.Text = string.Empty;
            if (CheckBoxDecludeStrings.Checked == false) TextBoxDecludeStrings.Text = string.Empty;
            if (CheckBoxFileExtensions.Checked == false) TextBoxFileExtensions.Text = string.Empty;

            DuplicateProcessing dp = DuplicateProcessing.None;
            if (dubCombobox.Text == Properties.Resources.OverwriteString)
            {
                dp = DuplicateProcessing.Overwrite;
            }
            else if (dubCombobox.Text == Properties.Resources.RenamingString)
            {
                dp = DuplicateProcessing.Renaming;
            }

            var option = new Option(
                    GetArrayFromTextbox(TextBoxFileExtensions.Text),
                    GetArrayFromTextbox(TextBoxInclude.Text),
                    GetArrayFromTextbox(TextBoxDecludeStrings.Text),
                    GetArrayFromTextbox(TextBoxOptionStrings.Text),
                    RadioIsCopy.Checked,
                    dp,
                    RootSearch.Checked,
                    RealTimeWatchService.Checked
                    );

            var gen = new ManagedDirectory(
                    TextBoxdeparture.Text,
                    TextBoxDestination.Text,
                    option
                    );
            if(this.index == -1) // new obj
            {
                Setting.Orders.Add(gen);
            }
            else
            {
                Setting.Orders[index] = gen;
            }

            if (gen.Enabled && gen.Option.RealtimeWatch)
            {
                gen.WatcherIndex = Watcher.Create(gen);
            }

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            tooltip.Text = "띄어쓰기로 구분합니다.";
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            tooltip.Text = "'.'을 포함해서 입력하며, 띄어쓰기로 구분합니다.";
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            tooltip.Text = "";
        }

        private void TextBoxdeparture_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (Directory.Exists(paths[0]))
            {
                TextBoxdeparture.Text = paths[0];
            }
        }

        private void TextBoxdeparture_DragEnter(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (Directory.Exists(paths[0]))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void TetxBoxDestination_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (Directory.Exists(paths[0]))
            {
                TextBoxDestination.Text = paths[0];
            }
        }

        private string[] GetArrayFromTextbox(string str)
        {
            if (string.IsNullOrEmpty(str)) return new string[] { };
            else return str.Split(' ');
        }
    }
}
