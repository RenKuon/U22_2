namespace プロコン部チーム_0622_TEST
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.button1 = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pausebutton = new System.Windows.Forms.Button();
            this.playbutton = new System.Windows.Forms.Button();
            this.input_file_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(300, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1, 59);
            this.button1.TabIndex = 0;
            this.button1.Text = "カット実行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.axWindowsMediaPlayer1, 5);
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(300, 3);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(909, 374);
            this.axWindowsMediaPlayer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.axWindowsMediaPlayer1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pausebutton, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.playbutton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.input_file_button, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.25664F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.74336F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1212, 630);
            this.tableLayoutPanel1.TabIndex = 2;

            // 
            // pausebutton
            // 
            this.pausebutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pausebutton.AutoSize = true;
            this.pausebutton.Location = new System.Drawing.Point(654, 383);
            this.pausebutton.Name = "pausebutton";
            this.pausebutton.Size = new System.Drawing.Size(200, 50);
            this.pausebutton.TabIndex = 4;
            this.pausebutton.Text = "‖ 一時停止";
            this.pausebutton.UseVisualStyleBackColor = true;
            this.pausebutton.Click += new System.EventHandler(this.pausebutton_Click);
            // 
            // playbutton
            // 
            this.playbutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.playbutton.AutoSize = true;
            this.playbutton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.playbutton.Location = new System.Drawing.Point(448, 383);
            this.playbutton.Name = "playbutton";
            this.playbutton.Size = new System.Drawing.Size(200, 50);
            this.playbutton.TabIndex = 2;
            this.playbutton.Text = "▶ 再生";
            this.playbutton.UseVisualStyleBackColor = false;
            this.playbutton.Click += new System.EventHandler(this.playbutton_Click);
            // 
            // input_file_button
            // 
            this.input_file_button.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.input_file_button.AutoSize = true;
            this.input_file_button.Location = new System.Drawing.Point(860, 383);
            this.input_file_button.Name = "input_file_button";
            this.input_file_button.Size = new System.Drawing.Size(200, 50);
            this.input_file_button.TabIndex = 5;
            this.input_file_button.Text = "参照";
            this.input_file_button.UseVisualStyleBackColor = true;
            this.input_file_button.Click += new System.EventHandler(this.input_file_button_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 630);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form3";
            this.Text = "編集";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button playbutton;
        private System.Windows.Forms.Button pausebutton;
        private System.Windows.Forms.Button input_file_button;
    }
}