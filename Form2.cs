using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClipperInstantReplay
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;

            set_recordtime_label.Text = $"設定されている録画時間:{Properties.Settings.Default.recordtime / 60}分"; // 設定から録画時間を取得して表示

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            reference_textbox1.ReadOnly = true;
            reference_textbox1.Text = Properties.Settings.Default.folderpath;     // 設定からフォルダパスを取得
            reference_textbox2.ReadOnly = true;
            reference_textbox2.Text = Properties.Settings.Default.cut_folderpath; // 設定からカットフォルダパスを取得
            set_output_device_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;


            // コンボボックスをクリア
            set_output_device_comboBox.Items.Clear();

            // NAudioを使ってオーディオ出力デバイスの数を取得
            int deviceCount = WaveIn.DeviceCount;


            for (int i = 0; i < deviceCount; i++)
            {
                var caps = WaveIn.GetCapabilities(i);
                set_output_device_comboBox.Items.Add(caps.ProductName);

                if (caps.ProductName.Contains(Properties.Settings.Default.set_output_device))
                {
                    set_output_device_comboBox.SelectedIndex = i; // デフォルトで選択
                }
            }
        }






        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button2, new Point(0, button2.Height));

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            set_record_time(1);    //1分
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            set_record_time(2);    //2分
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            set_record_time(3);    //3分
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            set_record_time(5);    //5分
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            set_record_time(10);   //10分
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            set_record_time(20);   //20分
        }

        private void set_record_time(int minutes)
        {
            Properties.Settings.Default.recordtime = minutes * 60; // 分を秒に変換
            set_recordtime_label.Text = $"設定されている録画時間:{minutes}分";
            Properties.Settings.Default.Save(); // 設定を保存
        }



        private void reference_button1_click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.folderpath = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                    reference_textbox1.Text = Properties.Settings.Default.folderpath;
                    MessageBox.Show("出力ファイルのパス指定が完了しました。");

                    if (Properties.Settings.Default.cut_folderpath == "")
                    {
                        Properties.Settings.Default.cut_folderpath = fbd.SelectedPath; // 同じフォルダを出力先に変更
                        Properties.Settings.Default.Save();
                        reference_textbox2.Text = Properties.Settings.Default.cut_folderpath;
                    }
                }
                else
                {
                    MessageBox.Show("フォルダの選択がキャンセルされました。");
                    return;
                }
            }
        }

        private void reference_button2_click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.cut_folderpath = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                    reference_textbox2.Text = Properties.Settings.Default.cut_folderpath;
                    MessageBox.Show("出力ファイルのパス指定が完了しました。");
                }
                else
                {
                    MessageBox.Show("フォルダの選択がキャンセルされました。");
                    return;
                }
            }
        }


        private void set_output_device_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.set_output_device = set_output_device_comboBox.SelectedItem.ToString(); // 設定に保存
            Properties.Settings.Default.Save(); // 設定を保存
        }
    }
}