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

namespace プロコン部チーム_0622_TEST
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;

            set_recordtime_label.Text = $"設定されている録画時間:{Properties.Settings.Default.recordtime / 60}分"; // 設定から録画時間を取得して表示


        }
        public static class AppState
        {
            public static string FolderPath;
            public static string FolderName;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            textBox1.ReadOnly = true;
            textBox1.Text = Properties.Settings.Default.folderpath;     // 設定からフォルダパスを取得
            set_output_device_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;


            // コンボボックスをクリア
            set_output_device_comboBox.Items.Clear();

            // NAudioを使ってオーディオ出力デバイスの数を取得
            int deviceCount = WaveIn.DeviceCount;


            for (int i = 0; i < deviceCount; i++)
            {
                var caps = WaveIn.GetCapabilities(i);
                set_output_device_comboBox.Items.Add(caps.ProductName);

                if (caps.ProductName.Contains("ステレオ ミキサー"))
                {
                    set_output_device_comboBox.SelectedIndex = i; // デフォルトで選択
                    Properties.Settings.Default.set_output_device = caps.ProductName; // 設定に保存
                    Properties.Settings.Default.Save(); // 設定を保存
                }
            }
            if (!Properties.Settings.Default.set_output_device.Contains("ステレオ ミキサー"))
            {
                MessageBox.Show("ステレオ ミキサーが見つかりません。ステレオミキサーを有効にしてください。");
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



        private void button1_Click_1(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.folderpath = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                    AppState.FolderPath = Properties.Settings.Default.folderpath;
                }
            }
            textBox1.Text = Properties.Settings.Default.folderpath;
            MessageBox.Show("出力ファイルのパス指定が完了しました。");
        }


        private void set_output_device_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!set_output_device_comboBox.SelectedItem.ToString().Contains("ステレオ ミキサー"))
            {
                MessageBox.Show("ステレオ ミキサーが見つかりません。ステレオミキサーを有効にしてください。");
            }
            else
            {
                Properties.Settings.Default.set_output_device = set_output_device_comboBox.SelectedItem.ToString(); // 設定に保存
                Properties.Settings.Default.Save(); // 設定を保存
            }
        }
    }
}