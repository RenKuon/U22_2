namespace クリッパーInstantReplay
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.instantreplay_ONOFF_button = new System.Windows.Forms.Button();
            this.rec_save_button = new System.Windows.Forms.Button();
            this.settings_button = new System.Windows.Forms.Button();
            this.edit_button = new System.Windows.Forms.Button();
            this.guide_label = new System.Windows.Forms.Label();
            this.rec_now_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // instantreplay_ONOFF_button
            // 
            this.instantreplay_ONOFF_button.BackColor = System.Drawing.SystemColors.Window;
            this.instantreplay_ONOFF_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.instantreplay_ONOFF_button.Font = new System.Drawing.Font("Noto Sans JP", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.instantreplay_ONOFF_button.ForeColor = System.Drawing.SystemColors.Desktop;
            this.instantreplay_ONOFF_button.Location = new System.Drawing.Point(10, 10);
            this.instantreplay_ONOFF_button.Margin = new System.Windows.Forms.Padding(2);
            this.instantreplay_ONOFF_button.Name = "instantreplay_ONOFF_button";
            this.instantreplay_ONOFF_button.Size = new System.Drawing.Size(280, 63);
            this.instantreplay_ONOFF_button.TabIndex = 0;
            this.instantreplay_ONOFF_button.Text = "インスタントリプレイON   ";
            this.instantreplay_ONOFF_button.UseVisualStyleBackColor = false;
            this.instantreplay_ONOFF_button.Click += new System.EventHandler(this.instantreplay_ONOFF_button_Click);
            // 
            // rec_save_button
            // 
            this.rec_save_button.AutoSize = true;
            this.rec_save_button.BackColor = System.Drawing.Color.YellowGreen;
            this.rec_save_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rec_save_button.Font = new System.Drawing.Font("Noto Sans JP", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rec_save_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rec_save_button.Location = new System.Drawing.Point(10, 78);
            this.rec_save_button.Margin = new System.Windows.Forms.Padding(2);
            this.rec_save_button.Name = "rec_save_button";
            this.rec_save_button.Size = new System.Drawing.Size(280, 63);
            this.rec_save_button.TabIndex = 2;
            this.rec_save_button.Text = "録画保存";
            this.rec_save_button.UseVisualStyleBackColor = false;
            this.rec_save_button.Visible = false;
            this.rec_save_button.Click += new System.EventHandler(this.rec_save_button_Click);
            // 
            // settings_button
            // 
            this.settings_button.Font = new System.Drawing.Font("Noto Sans JP", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.settings_button.Location = new System.Drawing.Point(11, 145);
            this.settings_button.Margin = new System.Windows.Forms.Padding(2);
            this.settings_button.Name = "settings_button";
            this.settings_button.Size = new System.Drawing.Size(140, 52);
            this.settings_button.TabIndex = 5;
            this.settings_button.Text = "設定";
            this.settings_button.UseVisualStyleBackColor = true;
            this.settings_button.Click += new System.EventHandler(this.settings_button_Click);
            // 
            // edit_button
            // 
            this.edit_button.Font = new System.Drawing.Font("Noto Sans JP", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.edit_button.Location = new System.Drawing.Point(155, 145);
            this.edit_button.Margin = new System.Windows.Forms.Padding(2);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(140, 52);
            this.edit_button.TabIndex = 6;
            this.edit_button.Text = "編集";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
            // 
            // guide_label
            // 
            this.guide_label.AutoSize = true;
            this.guide_label.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.guide_label.Location = new System.Drawing.Point(301, 113);
            this.guide_label.Name = "guide_label";
            this.guide_label.Size = new System.Drawing.Size(254, 28);
            this.guide_label.TabIndex = 7;
            this.guide_label.Text = "ALT+F10で録画保存";
            // 
            // rec_now_label
            // 
            this.rec_now_label.AutoSize = true;
            this.rec_now_label.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rec_now_label.Font = new System.Drawing.Font("Noto Sans JP Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rec_now_label.ForeColor = System.Drawing.Color.Yellow;
            this.rec_now_label.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rec_now_label.Location = new System.Drawing.Point(299, 34);
            this.rec_now_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rec_now_label.Name = "rec_now_label";
            this.rec_now_label.Size = new System.Drawing.Size(98, 39);
            this.rec_now_label.TabIndex = 3;
            this.rec_now_label.Text = "録画中";
            this.rec_now_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rec_now_label.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 243);
            this.Controls.Add(this.guide_label);
            this.Controls.Add(this.edit_button);
            this.Controls.Add(this.settings_button);
            this.Controls.Add(this.rec_now_label);
            this.Controls.Add(this.rec_save_button);
            this.Controls.Add(this.instantreplay_ONOFF_button);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "プロコン部テストUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button instantreplay_ONOFF_button;
        private System.Windows.Forms.Button rec_save_button;
        private System.Windows.Forms.Button settings_button;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Label guide_label;
        private System.Windows.Forms.Label rec_now_label;
    }
}

