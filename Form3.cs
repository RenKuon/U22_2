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
        //トラックバー操作中の排他制御用変数
        private bool trackbar_mouseup = false;

        public Form3()
        {
            InitializeComponent();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.uiMode = "none";

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



        //再生
        private void playbutton_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        //一時停止
        private void pausebutton_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        //ファイル参照
        private void input_file_button_Click(object sender, EventArgs e)
        {
            string set_filepath = @"C:\";
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "ファイル選択";
                ofd.InitialDirectory = set_filepath;
                ofd.Filter = "MP4ファイル|*.mp4";
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string select_mp4_filepath = ofd.FileName;


                    axWindowsMediaPlayer1.URL = select_mp4_filepath;
                }
                else
                {
                    MessageBox.Show("キャンセルまたはエラー", "通知");
                }
            }
        }


        //プレビューの再生時間の更新
        private void axWindowsMediaPlayer1_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            if (axWindowsMediaPlayer1.openState == WMPLib.WMPOpenState.wmposMediaOpen)
            {
                double tolal_time = axWindowsMediaPlayer1.currentMedia.duration; //動画の総秒数の取得


                //trackbarに動画の総秒数を反映
                movie_trackbar.Maximum = (int)(tolal_time * 1000);  //秒数をミリ秒として扱う
                movie_trackbar.Minimum = 0; //最小値は0に設定
                movie_trackbar.Value = 0; //初期値は0に設定

                //labelに動画の総秒数を表示
                TimeSpan total_timespan = TimeSpan.FromSeconds(tolal_time);
                time_display_label.Text = $"00:00:00.00 / {total_timespan.Hours:D2}:{total_timespan.Minutes:D2}:{total_timespan.Seconds:D2}"; //HH:MM:SS形式で表示

                timer1.Start(); // 動画がロードされたらタイマーを開始
            }
        }

        //時間を反映
        private void update_timer_tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.currentMedia != null && axWindowsMediaPlayer1.Ctlcontrols.currentPosition >= 0)
            {
                if (trackbar_mouseup == false)// トラックバー操作中でない場合のみ更新 
                {
                    int currentPosition_value = (int)(axWindowsMediaPlayer1.Ctlcontrols.currentPosition);
                    int trackbar_value = (int)(currentPosition_value * 1000); // 秒をミリ秒に変換

                    if (trackbar_value >= movie_trackbar.Minimum && trackbar_value <= movie_trackbar.Maximum)
                    {
                        movie_trackbar.Value = trackbar_value;
                    }

                }

                // 時間表示ラベルを更新
                TimeSpan current = TimeSpan.FromSeconds(axWindowsMediaPlayer1.Ctlcontrols.currentPosition);
                TimeSpan total = TimeSpan.FromSeconds(axWindowsMediaPlayer1.currentMedia.duration);
                time_display_label.Text = $"{current.ToString(@"hh\:mm\:ss\.ff")} / {total.ToString(@"hh\:mm\:ss\.ff")}";

            }
        }

        private void movie_trackbar_MouseUp(object sender, MouseEventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = movie_trackbar.Value / 1000.0;
            trackbar_mouseup = false;
        }

        private void movie_trackbar_MouseDown(object sender, MouseEventArgs e)
        {
            trackbar_mouseup = true;
        }
    }
}

