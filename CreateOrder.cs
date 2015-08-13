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
            index = -1; // new
        }

        public CreateOrder(ManagedDirectory d, int index)
        {
            InitializeComponent();
            folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.index = index;

            TextBoxdeparture.Text = d.DepartureFolder;
            TextBoxDestination.Text = d.DestinationFolder;

            var str = string.Empty;
            if (d.Option.FileExtensions.Count > 0)
            {
                CheckBoxFileExtensions.Checked = true;
                TextBoxFileExtensions.Enabled = true;
                for (int i = 0; i < d.Option.FileExtensions.Count; i++)
                {
                    str += d.Option.FileExtensions[i];
                    if (d.Option.FileExtensions.Count - 1 != i)
                    {
                        str += " ";
                    }
                }
                TextBoxFileExtensions.Text = str;
            }
            if (d.Option.IncludeStrings.Count > 0)
            {
                CheckBoxIncludes.Checked = true;
                TextBoxInclude.Enabled = true;
                str = string.Empty;
                for (int i = 0; i < d.Option.IncludeStrings.Count; i++)
                {
                    str += d.Option.IncludeStrings[i];
                    if (d.Option.IncludeStrings.Count - 1 != i)
                    {
                        str += " ";
                    }
                }
                TextBoxInclude.Text = str;
            }
            if (d.Option.DecludeStrings.Count > 0)
            {
                CheckBoxDecludeStrings.Checked = true;
                TextBoxDecludeStrings.Enabled = true;
                str = string.Empty;
                for (int i = 0; i < d.Option.DecludeStrings.Count; i++)
                {
                    str += d.Option.DecludeStrings[i];
                    if (d.Option.DecludeStrings.Count - 1 != i)
                    {
                        str += " ";
                    }
                }
                TextBoxDecludeStrings.Text = str;
            }
            if (d.Option.OptionStrings.Count > 0)
            {
                CheckBoxOptions.Checked = true;
                TextBoxOptionStrings.Enabled = true;
                str = string.Empty;
                for (int i = 0; i < d.Option.OptionStrings.Count; i++)
                {
                    str += d.Option.OptionStrings[i];
                    if (d.Option.OptionStrings.Count - 1 != i)
                    {
                        str += " ";
                    }
                }
                TextBoxOptionStrings.Text = str;
            }

            RadioIsCopy.Checked = d.Option.isCopy;
            RadioIsCopy.Checked = !d.Option.isCopy;
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
            var option = new Option(
                    (string.IsNullOrEmpty(TextBoxFileExtensions.Text)) ? new string[] { } : (TextBoxFileExtensions.Text.Contains(' ')) ? TextBoxFileExtensions.Text.Split(new char[] { ' ' }) : new string[] { TextBoxFileExtensions.Text },
                    (string.IsNullOrEmpty(TextBoxInclude.Text)) ? new string[] { } : (TextBoxInclude.Text.Contains(' ')) ? TextBoxInclude.Text.Split(new char[] { ' ' }) : new string[] { TextBoxInclude.Text },
                    (string.IsNullOrEmpty(TextBoxDecludeStrings.Text)) ? new string[] { } : (TextBoxDecludeStrings.Text.Contains(' ')) ? TextBoxDecludeStrings.Text.Split(new char[] { ' ' }) : new string[] { TextBoxDecludeStrings.Text },
                    (string.IsNullOrEmpty(TextBoxOptionStrings.Text)) ? new string[] { } : (TextBoxOptionStrings.Text.Contains(' ')) ? TextBoxOptionStrings.Text.Split(new char[] { ' ' }) : new string[] { TextBoxOptionStrings.Text },
                    RadioIsCopy.Checked
                    );
            if(this.index == -1) // new obj
            {
                Setting.Orders.Add(new ManagedDirectory(
                    TextBoxdeparture.Text,
                    TextBoxDestination.Text,
                    option
                    ));
            }
            else
            {
                Setting.Orders[index] = new ManagedDirectory(
                    TextBoxdeparture.Text,
                    TextBoxDestination.Text,
                    option
                    );
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
    }
}
