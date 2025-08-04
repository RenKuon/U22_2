using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace プロコン部チーム_0622_TEST
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
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
            MessageBox.Show($"録画時間を{minutes}分に設定しました。");
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

    }
}
