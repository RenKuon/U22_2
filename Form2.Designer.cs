namespace ClipperInstantReplay
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.reference_textbox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuitem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuitem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuitem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.reference_button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.reference_button2 = new System.Windows.Forms.Button();
            this.reference_textbox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.set_recordtime_label = new System.Windows.Forms.Label();
            this.set_output_device_label = new System.Windows.Forms.Label();
            this.set_output_device_comboBox = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reference_textbox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.reference_textbox1, 3);
            this.reference_textbox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.reference_textbox1.Location = new System.Drawing.Point(2, 34);
            this.reference_textbox1.Margin = new System.Windows.Forms.Padding(2);
            this.reference_textbox1.Name = "reference_textbox1";
            this.reference_textbox1.Size = new System.Drawing.Size(572, 22);
            this.reference_textbox1.TabIndex = 1;
            this.reference_textbox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Noto Sans JP", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(508, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "録画ファイルの保存先を指定してください。";
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Font = new System.Drawing.Font("Noto Sans JP Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Location = new System.Drawing.Point(2, 138);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(252, 42);
            this.button2.TabIndex = 3;
            this.button2.Text = "録画時間を選択";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuitem5,
            this.toolStripMenuitem6,
            this.toolStripMenuitem7});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(110, 148);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(109, 24);
            this.toolStripMenuItem2.Text = "1分";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(109, 24);
            this.toolStripMenuItem3.Text = "2分";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(109, 24);
            this.toolStripMenuItem4.Text = "3分";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuitem5
            // 
            this.toolStripMenuitem5.Name = "toolStripMenuitem5";
            this.toolStripMenuitem5.Size = new System.Drawing.Size(109, 24);
            this.toolStripMenuitem5.Text = "5分";
            this.toolStripMenuitem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuitem6
            // 
            this.toolStripMenuitem6.Name = "toolStripMenuitem6";
            this.toolStripMenuitem6.Size = new System.Drawing.Size(109, 24);
            this.toolStripMenuitem6.Text = "10分";
            this.toolStripMenuitem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuitem7
            // 
            this.toolStripMenuitem7.Name = "toolStripMenuitem7";
            this.toolStripMenuitem7.Size = new System.Drawing.Size(109, 24);
            this.toolStripMenuitem7.Text = "20分";
            this.toolStripMenuitem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // reference_button1
            // 
            this.reference_button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.reference_button1.Font = new System.Drawing.Font("Noto Sans JP", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.reference_button1.Location = new System.Drawing.Point(578, 34);
            this.reference_button1.Margin = new System.Windows.Forms.Padding(2);
            this.reference_button1.Name = "reference_button1";
            this.reference_button1.Size = new System.Drawing.Size(60, 32);
            this.reference_button1.TabIndex = 4;
            this.reference_button1.Text = "参照";
            this.reference_button1.UseVisualStyleBackColor = true;
            this.reference_button1.Click += new System.EventHandler(this.reference_button1_click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.reference_button2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.reference_textbox2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.reference_button1, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.reference_textbox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.set_recordtime_label, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.set_output_device_label, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.set_output_device_comboBox, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(640, 375);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // reference_button2
            // 
            this.reference_button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.reference_button2.Font = new System.Drawing.Font("Noto Sans JP", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.reference_button2.Location = new System.Drawing.Point(578, 102);
            this.reference_button2.Margin = new System.Windows.Forms.Padding(2);
            this.reference_button2.Name = "reference_button2";
            this.reference_button2.Size = new System.Drawing.Size(60, 32);
            this.reference_button2.TabIndex = 10;
            this.reference_button2.Text = "参照";
            this.reference_button2.UseVisualStyleBackColor = true;
            this.reference_button2.Click += new System.EventHandler(this.reference_button2_click);
            // 
            // reference_textbox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.reference_textbox2, 3);
            this.reference_textbox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.reference_textbox2.Location = new System.Drawing.Point(2, 102);
            this.reference_textbox2.Margin = new System.Windows.Forms.Padding(2);
            this.reference_textbox2.Name = "reference_textbox2";
            this.reference_textbox2.Size = new System.Drawing.Size(572, 22);
            this.reference_textbox2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 4);
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Noto Sans JP", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(2, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(636, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "カット処理後の動画ファイルの保存先を指定してください。";
            // 
            // set_recordtime_label
            // 
            this.set_recordtime_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.set_recordtime_label.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.set_recordtime_label, 2);
            this.set_recordtime_label.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.set_recordtime_label.Location = new System.Drawing.Point(259, 147);
            this.set_recordtime_label.Name = "set_recordtime_label";
            this.set_recordtime_label.Size = new System.Drawing.Size(279, 23);
            this.set_recordtime_label.TabIndex = 5;
            this.set_recordtime_label.Text = "設定されている録画時間:0分";
            // 
            // set_output_device_label
            // 
            this.set_output_device_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.set_output_device_label.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.set_output_device_label, 2);
            this.set_output_device_label.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.set_output_device_label.Location = new System.Drawing.Point(3, 182);
            this.set_output_device_label.Name = "set_output_device_label";
            this.set_output_device_label.Size = new System.Drawing.Size(315, 23);
            this.set_output_device_label.TabIndex = 6;
            this.set_output_device_label.Text = "ステレオミキサーを選択してください";
            // 
            // set_output_device_comboBox
            // 
            this.set_output_device_comboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.set_output_device_comboBox.FormattingEnabled = true;
            this.set_output_device_comboBox.Location = new System.Drawing.Point(3, 208);
            this.set_output_device_comboBox.Name = "set_output_device_comboBox";
            this.set_output_device_comboBox.Size = new System.Drawing.Size(250, 23);
            this.set_output_device_comboBox.TabIndex = 7;
            this.set_output_device_comboBox.SelectedValueChanged += new System.EventHandler(this.set_output_device_comboBox_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 375);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.Text = "設定";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox reference_textbox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.Button reference_button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuitem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuitem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuitem7;
        private System.Windows.Forms.Label set_recordtime_label;
        private System.Windows.Forms.Label set_output_device_label;
        private System.Windows.Forms.ComboBox set_output_device_comboBox;
        private System.Windows.Forms.Button reference_button2;
        private System.Windows.Forms.TextBox reference_textbox2;
        private System.Windows.Forms.Label label2;
    }
}