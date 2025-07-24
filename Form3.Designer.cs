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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.playbutton = new System.Windows.Forms.Button();
            this.input_file_button = new System.Windows.Forms.Button();
            this.pausebutton = new System.Windows.Forms.Button();
            this.movie_trackbar = new System.Windows.Forms.TrackBar();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.time_display_label = new System.Windows.Forms.Label();
            this.cut_end_time_display_label = new System.Windows.Forms.Label();
            this.cut_start_time_display_label = new System.Windows.Forms.Label();
            this.output_filename_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movie_trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(931, 523);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "カット実行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.playbutton, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.input_file_button, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.pausebutton, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.button1, 5, 7);
            this.tableLayoutPanel1.Controls.Add(this.movie_trackbar, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.axWindowsMediaPlayer1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.time_display_label, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.cut_end_time_display_label, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.cut_start_time_display_label, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.output_filename_textbox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1078, 644);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(3, 523);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 54);
            this.button2.TabIndex = 14;
            this.button2.Text = "設定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.LimeGreen;
            this.label4.Location = new System.Drawing.Point(22, 432);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 28);
            this.label4.TabIndex = 13;
            this.label4.Text = "Vキーで指定";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.LimeGreen;
            this.label3.Location = new System.Drawing.Point(22, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 28);
            this.label3.TabIndex = 12;
            this.label3.Text = "Cキーで指定";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playbutton
            // 
            this.playbutton.AutoSize = true;
            this.playbutton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.playbutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playbutton.Location = new System.Drawing.Point(481, 523);
            this.playbutton.Name = "playbutton";
            this.playbutton.Size = new System.Drawing.Size(144, 54);
            this.playbutton.TabIndex = 2;
            this.playbutton.Text = "▶ 再生";
            this.playbutton.UseVisualStyleBackColor = false;
            this.playbutton.Click += new System.EventHandler(this.playbutton_Click);
            // 
            // input_file_button
            // 
            this.input_file_button.AutoSize = true;
            this.input_file_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input_file_button.Location = new System.Drawing.Point(781, 523);
            this.input_file_button.Name = "input_file_button";
            this.input_file_button.Size = new System.Drawing.Size(144, 54);
            this.input_file_button.TabIndex = 5;
            this.input_file_button.Text = "参照";
            this.input_file_button.UseVisualStyleBackColor = true;
            this.input_file_button.Click += new System.EventHandler(this.input_file_button_Click);
            // 
            // pausebutton
            // 
            this.pausebutton.AutoSize = true;
            this.pausebutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pausebutton.Location = new System.Drawing.Point(631, 523);
            this.pausebutton.Name = "pausebutton";
            this.pausebutton.Size = new System.Drawing.Size(144, 54);
            this.pausebutton.TabIndex = 4;
            this.pausebutton.Text = "‖ 一時停止";
            this.pausebutton.UseVisualStyleBackColor = true;
            this.pausebutton.Click += new System.EventHandler(this.pausebutton_Click);
            // 
            // movie_trackbar
            // 
            this.movie_trackbar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.movie_trackbar, 6);
            this.movie_trackbar.Location = new System.Drawing.Point(3, 583);
            this.movie_trackbar.Maximum = 1000;
            this.movie_trackbar.Name = "movie_trackbar";
            this.movie_trackbar.Size = new System.Drawing.Size(1072, 58);
            this.movie_trackbar.TabIndex = 7;
            this.movie_trackbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.movie_trackbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.movie_trackbar_MouseDown);
            this.movie_trackbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.movie_trackbar_MouseUp);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.axWindowsMediaPlayer1, 5);
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(203, 3);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.tableLayoutPanel1.SetRowSpan(this.axWindowsMediaPlayer1, 7);
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(872, 514);
            this.axWindowsMediaPlayer1.TabIndex = 1;
            this.axWindowsMediaPlayer1.OpenStateChange += new AxWMPLib._WMPOCXEvents_OpenStateChangeEventHandler(this.axWindowsMediaPlayer1_OpenStateChange);
            // 
            // time_display_label
            // 
            this.time_display_label.AutoSize = true;
            this.time_display_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.time_display_label.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.time_display_label.Location = new System.Drawing.Point(203, 520);
            this.time_display_label.Name = "time_display_label";
            this.time_display_label.Size = new System.Drawing.Size(272, 60);
            this.time_display_label.TabIndex = 6;
            this.time_display_label.Text = "00:00.00 / 00:00.00";
            this.time_display_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cut_end_time_display_label
            // 
            this.cut_end_time_display_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cut_end_time_display_label.AutoSize = true;
            this.cut_end_time_display_label.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cut_end_time_display_label.Location = new System.Drawing.Point(3, 460);
            this.cut_end_time_display_label.Name = "cut_end_time_display_label";
            this.cut_end_time_display_label.Size = new System.Drawing.Size(194, 60);
            this.cut_end_time_display_label.TabIndex = 8;
            this.cut_end_time_display_label.Text = "カット終了時間00:00.00";
            this.cut_end_time_display_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cut_start_time_display_label
            // 
            this.cut_start_time_display_label.AutoSize = true;
            this.cut_start_time_display_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cut_start_time_display_label.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cut_start_time_display_label.Location = new System.Drawing.Point(3, 340);
            this.cut_start_time_display_label.Name = "cut_start_time_display_label";
            this.cut_start_time_display_label.Size = new System.Drawing.Size(194, 60);
            this.cut_start_time_display_label.TabIndex = 9;
            this.cut_start_time_display_label.Text = "カット開始時間: 00:00.00";
            this.cut_start_time_display_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // output_filename_textbox
            // 
            this.output_filename_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output_filename_textbox.Location = new System.Drawing.Point(3, 223);
            this.output_filename_textbox.Name = "output_filename_textbox";
            this.output_filename_textbox.Size = new System.Drawing.Size(194, 25);
            this.output_filename_textbox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(3, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "出力するファイル名";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.update_timer_tick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(439, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 200);
            this.label2.TabIndex = 13;
            this.label2.Text = "実行中です";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 644);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "Form3";
            this.Text = "編集";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form3_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movie_trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button playbutton;
        private System.Windows.Forms.Button pausebutton;
        private System.Windows.Forms.Button input_file_button;
        private System.Windows.Forms.Label time_display_label;
        private System.Windows.Forms.TrackBar movie_trackbar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label cut_end_time_display_label;
        private System.Windows.Forms.Label cut_start_time_display_label;
        private System.Windows.Forms.TextBox output_filename_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}