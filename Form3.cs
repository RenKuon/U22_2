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
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.label2.Visible = false; //実行中テキストを非表示にする


        }

        private void Form3_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.uiMode = "none";
            Properties.Settings.Default.cut_start_time = TimeSpan.Zero; //カット開始時間の初期値
            Properties.Settings.Default.cut_end_time = TimeSpan.Zero;   //カット終了時間の初期値

            axWindowsMediaPlayer1.URL = Properties.Settings.Default.raw_movie_filepath; //settingsファイルから動画のパスを読み込み


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //カットする範囲の開始時間と終了時間を.settingsファイルから取得
            TimeSpan start_time = Properties.Settings.Default.cut_start_time;                           //カットする範囲の開始地点の指定変数
            TimeSpan end_time = Properties.Settings.Default.cut_end_time;                               //カットする範囲の終了地点の指定変数


            if (start_time >= end_time)
            {
                MessageBox.Show("カット開始時間はカット終了時間より前に設定してください。", "エラー");
                return; //カット開始時間がカット終了時間より後の場合は処理を中止
            }



            string input_filepath = Properties.Settings.Default.raw_movie_filepath;     //インスタントリプレイの保存ファイルパスを.settingsファイルから読み込み
            string input_filename = Path.GetFileName(input_filepath);       //元のファイル名を取得


            //出力ファイルパスの設定
            string output_filename = output_filename_textbox.Text + ".mp4";      //出力するファイル名をテキストボックスから取得


            string output_filepath = Path.Combine(Properties.Settings.Default.folderpath, output_filename); //カット後のファイルの保存先パス


            int i = 1; //連番の初期値
            while (File.Exists(output_filepath)) //同名のファイルが存在する場合にファイル名に連番をつける
            {
                output_filepath = Path.Combine(Properties.Settings.Default.folderpath, $"{output_filename_textbox.Text}{(i)}.mp4");
                i++;
            }


            axWindowsMediaPlayer1.Ctlcontrols.pause();




            //カット処理

            this.label2.Visible = true; //実行中テキストを表示する

            //カット処理の実行
            string ffmpegCommand = $"ffmpeg -ss {start_time} -i \"{input_filepath}\" -to {end_time} -c:v libx264 -preset medium -crf 23 -c:a aac -b:a 128k \"{output_filepath}\"";
            //string ffmpegCommand = $"ffmpeg -ss {start_time} -i \"{input_filepath}\" -to {end_time} -c copy \"{output_filepath}\"";


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



            if (output_filepath == input_filepath)
            {
                File.Delete(input_filepath); //元のファイルを削除

                File.Move(output_filepath, input_filename);//カット後のファイルを元のファイル名に変更
            }

            this.label2.Visible = false; //実行中テキストを非表示にする



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
                    Properties.Settings.Default.raw_movie_filepath = select_mp4_filepath;
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

                output_filename_textbox.Text = Path.GetFileNameWithoutExtension(Properties.Settings.Default.raw_movie_filepath); //出力するファイル名の初期値を設定
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
                time_display_label.Text = $"{current.ToString(@"mm\:ss\.ff")} / {total.ToString(@"mm\:ss\.ff")}";

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

            // TrackBar の現在のインスタンスを取得
            TrackBar tb = (TrackBar)sender;

            // クリックされたX座標とTrackBarの幅から、新しい値を計算する
            // e.X はTrackBarコントロール内での相対X座標
            // tb.Width はTrackBarコントロールの幅

            // クリック位置をTrackBarの最小値から最大値の範囲にマッピング
            // (double)e.X / tb.Width はクリック位置の割合 (0.0 ～ 1.0)
            double clickPercent = (double)e.X / tb.Width;

            // 計算された新しい値
            int newValue = (int)Math.Round(tb.Minimum + (tb.Maximum - tb.Minimum) * clickPercent);

            // TrackBar の値を更新
            tb.Value = newValue;


            //トラックバーの値で動画の再生時間を更新
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = movie_trackbar.Value / 1000.0;
        }


        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            // Spaceキーが押されたかを判定
            if (e.KeyCode == Keys.C)
            {
                Properties.Settings.Default.cut_start_time = TimeSpan.FromSeconds(axWindowsMediaPlayer1.Ctlcontrols.currentPosition);
                cut_start_time_display_label.Text = $"カット開始時間: {Properties.Settings.Default.cut_start_time.ToString(@"mm\:ss\.ff")}";
            }

            if (e.KeyCode == Keys.V)
            {
                Properties.Settings.Default.cut_end_time = TimeSpan.FromSeconds(axWindowsMediaPlayer1.Ctlcontrols.currentPosition);
                cut_end_time_display_label.Text = $"カット終了時間: {Properties.Settings.Default.cut_end_time.ToString(@"mm\:ss\.ff")}";
            }
        }


    }
}