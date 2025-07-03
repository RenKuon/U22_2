using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace プロコン部チーム_0622_TEST
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input_filepath = Properties.Settings.Default.raw_movie_filepath;     //出力ファイルパスを.settingsファイルから読み込み
            string output_filepath = Path.Combine(Properties.Settings.Default.folderpath, "cut_output.mp4"); //カット後のファイルの保存先パス
            string start_time = "00:00:10";                             //カットする範囲の開始地点の指定変数
            string end_time = "00:10:00";                               //カットする範囲の終了地点の指定変数


            //カット処理
            string ffmpegCommand = $"ffmpeg -i \"{input_filepath}\" -ss {start_time} -to {end_time} -c copy \"{output_filepath}\"";

            //バックグラウンドでの処理
            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {ffmpegCommand}",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(processInfo))
            {
                process.WaitForExit();
            }

            string input_filename = Path.GetFileName(input_filepath);       //元のファイル名を取得
            File.Delete(input_filepath); //元のファイルを削除

            File.Move(output_filepath, Path.Combine(Properties.Settings.Default.folderpath, input_filename));//カット後のファイルを元のファイル名に変更



        }
    }
}
