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
                comboBox1.Text = "새 파일로 덮어쓰기";
            }
            else if(d.Option.Duplicate == DuplicateProcessing.Renaming)
            {
                comboBox1.Text = "이름 뒤에 고유한 숫자 추가";
            }
            else if(d.Option.Duplicate == DuplicateProcessing.None)
            {
                comboBox1.Text = "이동하지 않음";
            }

            RootSearch.Checked = d.Option.RootSerach;
            
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
            if (comboBox1.Text == "새 파일로 덮어쓰기")
            {
                dp = DuplicateProcessing.Overwrite;
            }
            else if (comboBox1.Text == "이름 뒤에 고유한 숫자 추가")
            {
                dp = DuplicateProcessing.Renaming;
            }

            var option = new Option(
                    TextBoxFileExtensions.Text.Split(' '),
                    TextBoxInclude.Text.Split(' '),
                    TextBoxDecludeStrings.Text.Split(' '),
                    TextBoxOptionStrings.Text.Split(' '),
                    RadioIsCopy.Checked,
                    dp,
                    RootSearch.Checked
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
