namespace SQUI
{
    partial class CreateOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBoxdeparture = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TextBoxDestination = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.TextBoxInclude = new System.Windows.Forms.TextBox();
            this.TextBoxOptionStrings = new System.Windows.Forms.TextBox();
            this.TextBoxDecludeStrings = new System.Windows.Forms.TextBox();
            this.TextBoxFileExtensions = new System.Windows.Forms.TextBox();
            this.CheckBoxIncludes = new System.Windows.Forms.CheckBox();
            this.CheckBoxOptions = new System.Windows.Forms.CheckBox();
            this.CheckBoxDecludeStrings = new System.Windows.Forms.CheckBox();
            this.CheckBoxFileExtensions = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tooltip = new System.Windows.Forms.Label();
            this.RadioIsCopy = new System.Windows.Forms.RadioButton();
            this.RadioIsMove = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBoxdeparture
            // 
            this.TextBoxdeparture.AllowDrop = true;
            this.TextBoxdeparture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxdeparture.Location = new System.Drawing.Point(75, 12);
            this.TextBoxdeparture.Name = "TextBoxdeparture";
            this.TextBoxdeparture.Size = new System.Drawing.Size(314, 21);
            this.TextBoxdeparture.TabIndex = 0;
            this.TextBoxdeparture.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBoxdeparture_DragDrop);
            this.TextBoxdeparture.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBoxdeparture_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "대상 폴더";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(395, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 23);
            this.button1.TabIndex = 2;
            this.button1.TabStop = false;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TextBoxDestination
            // 
            this.TextBoxDestination.AllowDrop = true;
            this.TextBoxDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxDestination.Location = new System.Drawing.Point(75, 39);
            this.TextBoxDestination.Name = "TextBoxDestination";
            this.TextBoxDestination.Size = new System.Drawing.Size(314, 21);
            this.TextBoxDestination.TabIndex = 1;
            this.TextBoxDestination.DragDrop += new System.Windows.Forms.DragEventHandler(this.TetxBoxDestination_DragDrop);
            this.TextBoxDestination.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBoxdeparture_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "이동 폴더";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(395, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 23);
            this.button2.TabIndex = 2;
            this.button2.TabStop = false;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TextBoxInclude
            // 
            this.TextBoxInclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxInclude.Enabled = false;
            this.TextBoxInclude.Location = new System.Drawing.Point(192, 86);
            this.TextBoxInclude.Name = "TextBoxInclude";
            this.TextBoxInclude.Size = new System.Drawing.Size(278, 21);
            this.TextBoxInclude.TabIndex = 2;
            this.TextBoxInclude.Enter += new System.EventHandler(this.textBox3_Enter);
            this.TextBoxInclude.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // TextBoxOptionStrings
            // 
            this.TextBoxOptionStrings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxOptionStrings.Enabled = false;
            this.TextBoxOptionStrings.Location = new System.Drawing.Point(192, 113);
            this.TextBoxOptionStrings.Name = "TextBoxOptionStrings";
            this.TextBoxOptionStrings.Size = new System.Drawing.Size(278, 21);
            this.TextBoxOptionStrings.TabIndex = 3;
            this.TextBoxOptionStrings.Enter += new System.EventHandler(this.textBox3_Enter);
            this.TextBoxOptionStrings.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // TextBoxDecludeStrings
            // 
            this.TextBoxDecludeStrings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxDecludeStrings.Enabled = false;
            this.TextBoxDecludeStrings.Location = new System.Drawing.Point(192, 140);
            this.TextBoxDecludeStrings.Name = "TextBoxDecludeStrings";
            this.TextBoxDecludeStrings.Size = new System.Drawing.Size(278, 21);
            this.TextBoxDecludeStrings.TabIndex = 4;
            this.TextBoxDecludeStrings.Enter += new System.EventHandler(this.textBox3_Enter);
            this.TextBoxDecludeStrings.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // TextBoxFileExtensions
            // 
            this.TextBoxFileExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxFileExtensions.Enabled = false;
            this.TextBoxFileExtensions.Location = new System.Drawing.Point(192, 167);
            this.TextBoxFileExtensions.Name = "TextBoxFileExtensions";
            this.TextBoxFileExtensions.Size = new System.Drawing.Size(278, 21);
            this.TextBoxFileExtensions.TabIndex = 5;
            this.TextBoxFileExtensions.Enter += new System.EventHandler(this.textBox6_Enter);
            this.TextBoxFileExtensions.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // CheckBoxIncludes
            // 
            this.CheckBoxIncludes.AutoSize = true;
            this.CheckBoxIncludes.Location = new System.Drawing.Point(14, 89);
            this.CheckBoxIncludes.Name = "CheckBoxIncludes";
            this.CheckBoxIncludes.Size = new System.Drawing.Size(132, 16);
            this.CheckBoxIncludes.TabIndex = 3;
            this.CheckBoxIncludes.TabStop = false;
            this.CheckBoxIncludes.Text = "다음 단어 모두 포함";
            this.CheckBoxIncludes.UseVisualStyleBackColor = true;
            this.CheckBoxIncludes.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // CheckBoxOptions
            // 
            this.CheckBoxOptions.AutoSize = true;
            this.CheckBoxOptions.Location = new System.Drawing.Point(14, 116);
            this.CheckBoxOptions.Name = "CheckBoxOptions";
            this.CheckBoxOptions.Size = new System.Drawing.Size(172, 16);
            this.CheckBoxOptions.TabIndex = 3;
            this.CheckBoxOptions.TabStop = false;
            this.CheckBoxOptions.Text = "다음 단어 적어도 하나 포함";
            this.CheckBoxOptions.UseVisualStyleBackColor = true;
            this.CheckBoxOptions.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // CheckBoxDecludeStrings
            // 
            this.CheckBoxDecludeStrings.AutoSize = true;
            this.CheckBoxDecludeStrings.Location = new System.Drawing.Point(14, 143);
            this.CheckBoxDecludeStrings.Name = "CheckBoxDecludeStrings";
            this.CheckBoxDecludeStrings.Size = new System.Drawing.Size(104, 16);
            this.CheckBoxDecludeStrings.TabIndex = 3;
            this.CheckBoxDecludeStrings.TabStop = false;
            this.CheckBoxDecludeStrings.Text = "다음 단어 제외";
            this.CheckBoxDecludeStrings.UseVisualStyleBackColor = true;
            this.CheckBoxDecludeStrings.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // CheckBoxFileExtensions
            // 
            this.CheckBoxFileExtensions.AutoSize = true;
            this.CheckBoxFileExtensions.Location = new System.Drawing.Point(14, 170);
            this.CheckBoxFileExtensions.Name = "CheckBoxFileExtensions";
            this.CheckBoxFileExtensions.Size = new System.Drawing.Size(128, 16);
            this.CheckBoxFileExtensions.TabIndex = 3;
            this.CheckBoxFileExtensions.TabStop = false;
            this.CheckBoxFileExtensions.Text = "다음 확장자만 해당";
            this.CheckBoxFileExtensions.UseVisualStyleBackColor = true;
            this.CheckBoxFileExtensions.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(395, 241);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "취소";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(314, 241);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "확인";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tooltip
            // 
            this.tooltip.AutoSize = true;
            this.tooltip.Location = new System.Drawing.Point(12, 218);
            this.tooltip.Name = "tooltip";
            this.tooltip.Size = new System.Drawing.Size(0, 12);
            this.tooltip.TabIndex = 5;
            // 
            // RadioIsCopy
            // 
            this.RadioIsCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioIsCopy.AutoSize = true;
            this.RadioIsCopy.Location = new System.Drawing.Point(429, 42);
            this.RadioIsCopy.Name = "RadioIsCopy";
            this.RadioIsCopy.Size = new System.Drawing.Size(47, 16);
            this.RadioIsCopy.TabIndex = 8;
            this.RadioIsCopy.Text = "복사";
            this.RadioIsCopy.UseVisualStyleBackColor = true;
            // 
            // RadioIsMove
            // 
            this.RadioIsMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioIsMove.AutoSize = true;
            this.RadioIsMove.Checked = true;
            this.RadioIsMove.Location = new System.Drawing.Point(429, 15);
            this.RadioIsMove.Name = "RadioIsMove";
            this.RadioIsMove.Size = new System.Drawing.Size(47, 16);
            this.RadioIsMove.TabIndex = 8;
            this.RadioIsMove.TabStop = true;
            this.RadioIsMove.Text = "이동";
            this.RadioIsMove.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "새 파일로 덮어쓰기",
            "이름 뒤에 고유한 숫자 추가",
            "이동하지 않음"});
            this.comboBox1.Location = new System.Drawing.Point(103, 203);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(155, 20);
            this.comboBox1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "중복 파일 처리";
            // 
            // CreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 276);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.RadioIsMove);
            this.Controls.Add(this.RadioIsCopy);
            this.Controls.Add(this.tooltip);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.CheckBoxFileExtensions);
            this.Controls.Add(this.CheckBoxDecludeStrings);
            this.Controls.Add(this.CheckBoxOptions);
            this.Controls.Add(this.CheckBoxIncludes);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxFileExtensions);
            this.Controls.Add(this.TextBoxDecludeStrings);
            this.Controls.Add(this.TextBoxOptionStrings);
            this.Controls.Add(this.TextBoxInclude);
            this.Controls.Add(this.TextBoxDestination);
            this.Controls.Add(this.TextBoxdeparture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CreateOrder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CreateOrder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxdeparture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TextBoxDestination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TextBoxInclude;
        private System.Windows.Forms.TextBox TextBoxOptionStrings;
        private System.Windows.Forms.TextBox TextBoxDecludeStrings;
        private System.Windows.Forms.TextBox TextBoxFileExtensions;
        private System.Windows.Forms.CheckBox CheckBoxIncludes;
        private System.Windows.Forms.CheckBox CheckBoxOptions;
        private System.Windows.Forms.CheckBox CheckBoxDecludeStrings;
        private System.Windows.Forms.CheckBox CheckBoxFileExtensions;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label tooltip;
        private System.Windows.Forms.RadioButton RadioIsCopy;
        private System.Windows.Forms.RadioButton RadioIsMove;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
    }
}