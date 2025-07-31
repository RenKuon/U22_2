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
        public static int Recordtime; //録画したい時間

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
            textBox1.ReadOnly = true;
            textBox1.Text = Properties.Settings.Default.folderpath;     // 設定からフォルダパスを取得
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppState.FolderName = textBox2.Text;
            MessageBox.Show("出力フォルダの指名が完了しました。");

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
            Recordtime = 60;    //1分
            Properties.Settings.Default.recordtime = 60; // 設定に録画時間を保存
            MessageBox.Show("録画時間を1分に設定しました。");
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Recordtime = 120;   //2分
            MessageBox.Show("録画時間を2分に設定しました。");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Recordtime = 180;   //3分
            MessageBox.Show("録画時間を3分に設定しました。");
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
