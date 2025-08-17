namespace ClipperInstantReplay
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.status_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.output_filename_textbox = new System.Windows.Forms.TextBox();
            this.cut_start_time_display_label = new System.Windows.Forms.Label();
            this.cut_end_time_display_label = new System.Windows.Forms.Label();
            this.time_display_label = new System.Windows.Forms.Label();
            this.movie_trackbar = new System.Windows.Forms.TrackBar();
            this.pausebutton = new System.Windows.Forms.Button();
            this.inputfile_button = new System.Windows.Forms.Button();
            this.playbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cut_button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.movie_trackbar)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.update_timer_tick);
            // 
            // status_label
            // 
            this.status_label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.status_label.Dock = System.Windows.Forms.DockStyle.Top;
            this.status_label.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.status_label.ForeColor = System.Drawing.Color.Red;
            this.status_label.Location = new System.Drawing.Point(0, 0);
            this.status_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(662, 167);
            this.status_label.TabIndex = 13;
            this.status_label.Text = "実行中です";
            this.status_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.status_label.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(2, 179);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "出力するファイル名";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // output_filename_textbox
            // 
            this.output_filename_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output_filename_textbox.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.output_filename_textbox.Location = new System.Drawing.Point(2, 201);
            this.output_filename_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.output_filename_textbox.MaxLength = 100;
            this.output_filename_textbox.Name = "output_filename_textbox";
            this.output_filename_textbox.Size = new System.Drawing.Size(196, 37);
            this.output_filename_textbox.TabIndex = 10;
            this.output_filename_textbox.Enter += new System.EventHandler(this.output_textbox_enter);
            this.output_filename_textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.output_filename_textbox_keydown);
            this.output_filename_textbox.Leave += new System.EventHandler(this.output_textbox_focus_leave);
            // 
            // cut_start_time_display_label
            // 
            this.cut_start_time_display_label.AutoSize = true;
            this.cut_start_time_display_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cut_start_time_display_label.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cut_start_time_display_label.Location = new System.Drawing.Point(2, 299);
            this.cut_start_time_display_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cut_start_time_display_label.Name = "cut_start_time_display_label";
            this.cut_start_time_display_label.Size = new System.Drawing.Size(196, 50);
            this.cut_start_time_display_label.TabIndex = 9;
            this.cut_start_time_display_label.Text = "カット開始時間: 00:00.00";
            this.cut_start_time_display_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cut_end_time_display_label
            // 
            this.cut_end_time_display_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cut_end_time_display_label.AutoSize = true;
            this.cut_end_time_display_label.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cut_end_time_display_label.Location = new System.Drawing.Point(2, 399);
            this.cut_end_time_display_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cut_end_time_display_label.Name = "cut_end_time_display_label";
            this.cut_end_time_display_label.Size = new System.Drawing.Size(196, 50);
            this.cut_end_time_display_label.TabIndex = 8;
            this.cut_end_time_display_label.Text = "カット終了時間00:00.00";
            this.cut_end_time_display_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // time_display_label
            // 
            this.time_display_label.AutoSize = true;
            this.time_display_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.time_display_label.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.time_display_label.Location = new System.Drawing.Point(202, 449);
            this.time_display_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.time_display_label.Name = "time_display_label";
            this.time_display_label.Size = new System.Drawing.Size(223, 50);
            this.time_display_label.TabIndex = 6;
            this.time_display_label.Text = "00:00.00 / 00:00.00";
            this.time_display_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // movie_trackbar
            // 
            this.movie_trackbar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.movie_trackbar, 6);
            this.movie_trackbar.Location = new System.Drawing.Point(2, 501);
            this.movie_trackbar.Margin = new System.Windows.Forms.Padding(2);
            this.movie_trackbar.Maximum = 1000;
            this.movie_trackbar.Name = "movie_trackbar";
            this.movie_trackbar.Size = new System.Drawing.Size(862, 41);
            this.movie_trackbar.TabIndex = 7;
            this.movie_trackbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.movie_trackbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.movie_trackbar_MouseDown);
            this.movie_trackbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.movie_trackbar_Move);
            this.movie_trackbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.movie_trackbar_MouseUp);
            // 
            // pausebutton
            // 
            this.pausebutton.AutoSize = true;
            this.pausebutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pausebutton.Location = new System.Drawing.Point(538, 451);
            this.pausebutton.Margin = new System.Windows.Forms.Padding(2);
            this.pausebutton.Name = "pausebutton";
            this.pausebutton.Size = new System.Drawing.Size(105, 46);
            this.pausebutton.TabIndex = 4;
            this.pausebutton.Text = "‖ 一時停止";
            this.pausebutton.UseVisualStyleBackColor = true;
            this.pausebutton.Click += new System.EventHandler(this.pausebutton_Click);
            // 
            // inputfile_button
            // 
            this.inputfile_button.AutoSize = true;
            this.inputfile_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputfile_button.Location = new System.Drawing.Point(647, 451);
            this.inputfile_button.Margin = new System.Windows.Forms.Padding(2);
            this.inputfile_button.Name = "inputfile_button";
            this.inputfile_button.Size = new System.Drawing.Size(105, 46);
            this.inputfile_button.TabIndex = 5;
            this.inputfile_button.Text = "参照";
            this.inputfile_button.UseVisualStyleBackColor = true;
            this.inputfile_button.Click += new System.EventHandler(this.input_file_button_Click);
            // 
            // playbutton
            // 
            this.playbutton.AutoSize = true;
            this.playbutton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.playbutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playbutton.Location = new System.Drawing.Point(429, 451);
            this.playbutton.Margin = new System.Windows.Forms.Padding(2);
            this.playbutton.Name = "playbutton";
            this.playbutton.Size = new System.Drawing.Size(105, 46);
            this.playbutton.TabIndex = 2;
            this.playbutton.Text = "▶ 再生";
            this.playbutton.UseVisualStyleBackColor = false;
            this.playbutton.Click += new System.EventHandler(this.playbutton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.LimeGreen;
            this.label3.Location = new System.Drawing.Point(33, 275);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Cキーで指定";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.LimeGreen;
            this.label4.Location = new System.Drawing.Point(33, 375);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "Vキーで指定";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.18859F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.21319F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.64956F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.64956F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.64956F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.64956F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.playbutton, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.inputfile_button, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.pausebutton, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.cut_button, 5, 7);
            this.tableLayoutPanel1.Controls.Add(this.movie_trackbar, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.time_display_label, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.cut_end_time_display_label, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.cut_start_time_display_label, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.output_filename_textbox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.92307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.07693F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(866, 544);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.TabStop = true;
            this.tableLayoutPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tablelayout_click);
            // 
            // cut_button
            // 
            this.cut_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cut_button.Location = new System.Drawing.Point(756, 451);
            this.cut_button.Margin = new System.Windows.Forms.Padding(2);
            this.cut_button.Name = "cut_button";
            this.cut_button.Size = new System.Drawing.Size(108, 46);
            this.cut_button.TabIndex = 0;
            this.cut_button.Text = "カット実行";
            this.cut_button.UseVisualStyleBackColor = true;
            this.cut_button.Click += new System.EventHandler(this.cut_button_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 5);
            this.panel1.Controls.Add(this.status_label);
            this.panel1.Controls.Add(this.axWindowsMediaPlayer1);
            this.panel1.Location = new System.Drawing.Point(202, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 7);
            this.panel1.Size = new System.Drawing.Size(662, 445);
            this.panel1.TabIndex = 15;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Margin = new System.Windows.Forms.Padding(2);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(662, 445);
            this.axWindowsMediaPlayer1.TabIndex = 3;
            this.axWindowsMediaPlayer1.OpenStateChange += new AxWMPLib._WMPOCXEvents_OpenStateChangeEventHandler(this.axWindowsMediaPlayer1_OpenStateChange);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 544);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(884, 591);
            this.Name = "Form3";
            this.Text = "編集";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form3_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.movie_trackbar)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label status_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox output_filename_textbox;
        private System.Windows.Forms.Label cut_start_time_display_label;
        private System.Windows.Forms.Label cut_end_time_display_label;
        private System.Windows.Forms.Label time_display_label;
        private System.Windows.Forms.TrackBar movie_trackbar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button playbutton;
        private System.Windows.Forms.Button inputfile_button;
        private System.Windows.Forms.Button pausebutton;
        private System.Windows.Forms.Panel panel1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button cut_button;
    }
}