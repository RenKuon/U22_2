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

namespace クリッパーInstantReplay
{
    public partial class Form3 : Form
    {
        //トラックバー操作中の排他制御用変数
        private bool trackbar_mouseup = false;

        private bool output_focus = false; // 出力ファイル名のテキストボックスにフォーカスがあるかどうかのフラグ

        // ドラッグ開始時のメディアプレーヤーの状態を保存するための変数
        private WMPLib.WMPPlayState play_state;

        public Form3()
        {
            InitializeComponent(); //フォームの初期化
            this.MinimumSize = new System.Drawing.Size(1100, 700); //最小サイズを設定
            this.status_label.Visible = false; //実行中テキストを非表示にする


        }

        private void Form3_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.uiMode = "none"; //UIモードをnoneに設定して、コントロールを非表示にする
            Properties.Settings.Default.cut_start_time = TimeSpan.Zero; //カット開始時間の初期値
            Properties.Settings.Default.cut_end_time = TimeSpan.Zero;   //カット終了時間の初期値

            axWindowsMediaPlayer1.URL = Properties.Settings.Default.raw_movie_filepath; //settingsファイルから動画のパスを読み込み


        }

        private async void cut_button_Click(object sender, EventArgs e)
        {
            //カットする範囲の開始時間と終了時間を.settingsファイルから取得
            TimeSpan start_time = Properties.Settings.Default.cut_start_time;                           //カットする範囲の開始地点の指定変数
            TimeSpan end_time = Properties.Settings.Default.cut_end_time;                               //カットする範囲の終了地点の指定変数

            if (axWindowsMediaPlayer1.openState != WMPLib.WMPOpenState.wmposMediaOpen)      //動画が読み込まれていない場合
            {
                MessageBox.Show("動画が読み込まれていません。", "エラー");
                return; //動画が読み込まれていない場合は処理を中止
            }
            else if (start_time >= end_time)  //カット開始時間がカット終了時間より後の場合
            {
                MessageBox.Show("カット開始時間はカット終了時間より前に設定してください。", "エラー");
                return; //カット開始時間がカット終了時間より後の場合は処理を中止
            }


            //textboxの入力値チェック
            if (string.IsNullOrWhiteSpace(output_filename_textbox.Text)) //出力ファイル名のテキストボックスが空の場合
            {
                MessageBox.Show("出力ファイル名を入力してください。", "エラー");
                return; //出力ファイル名が空の場合は処理を中止
            }
            if (output_filename_textbox.Text.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0) //出力ファイル名に無効な文字が含まれている場合
            {
                MessageBox.Show("出力ファイル名に無効な文字が含まれています。", "エラー");
                return; //無効な文字が含まれている場合は処理を中止
            }
            if (output_filename_textbox.Text != output_filename_textbox.Text.Trim())
            {
                MessageBox.Show("出力ファイル名の先頭または末尾に空白が含まれています。", "エラー");
                return; // 先頭または末尾に空白がある場合は処理を中止
            }


            string input_filepath = Properties.Settings.Default.raw_movie_filepath;     //インスタントリプレイの保存ファイルパスを.settingsファイルから読み込み
            string input_filename = Path.GetFileName(input_filepath);       //元のファイル名を取得



            //出力ファイルパスの設定
            string output_filename = output_filename_textbox.Text + ".mp4";      //出力するファイル名をテキストボックスから取得


            string output_filepath = Path.Combine(Properties.Settings.Default.folderpath, output_filename); //カット後のファイルの保存先パス


            int i = 1; //連番の初期値
            while (File.Exists(output_filepath)) //同名のファイルが存在する場合にファイル名に連番をつける
            {
                output_filepath = Path.Combine(Properties.Settings.Default.cut_folderpath, $"{output_filename_textbox.Text}({(i)}).mp4");
                i++;
            }

            if (output_filepath.Length == 260)
            {
                MessageBox.Show("出力ファイル名が長すぎます。260文字以下にしてください。", "エラー");
                return; //出力ファイル名が長すぎる場合は処理を中止
            }

            axWindowsMediaPlayer1.Ctlcontrols.pause();




            //カット処理
            this.status_label.Text = "実行中"; //実行中テキストを更新
            this.status_label.ForeColor = Color.Red; //実行中のテキスト色を赤に変更
            this.status_label.Visible = true; //実行中テキストを表示する

            //カット処理の実行]
            string ffmpegCommand = $"ffmpeg -ss {start_time} -i \"{input_filepath}\" -to {end_time} -c copy \"{output_filepath}\"";


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
            //Form3終了処理
            this.status_label.Text = "実行完了"; //実行中テキストを更新
            this.status_label.ForeColor = Color.Green; //実行完了のテキスト色を緑に変更
            await Task.Delay(2000); //2秒待機
            this.status_label.Visible = false; //実行中テキストを非表示にする
            this.Close();





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
            string set_filepath = Properties.Settings.Default.folderpath;
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
                TimeSpan current = TimeSpan.FromSeconds(axWindowsMediaPlayer1.Ctlcontrols.currentPosition);  // 現在の再生位置を取得
                TimeSpan total = TimeSpan.FromSeconds(axWindowsMediaPlayer1.currentMedia.duration);  // 動画の総時間を取得
                time_display_label.Text = $"{current.ToString(@"mm\:ss\.ff")} / {total.ToString(@"mm\:ss\.ff")}";  // mm:ss.ff形式で表示

            }
        }


        //トラックバーのクリックを外したときの処理
        private void movie_trackbar_MouseUp(object sender, MouseEventArgs e)
        {
            // マウスの左ボタンが離された場合のみ処理を終了
            if (e.Button == MouseButtons.Left)
            {
                trackbar_mouseup = false;
                // TrackBar の現在のインスタンスを取得
                TrackBar tb = (TrackBar)sender;
                // 最終的な位置で一度シークを確定させる
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = tb.Value / 1000.0;
                // ドラッグ開始時の再生状態に戻す
                if (play_state == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.play(); // 元々再生中だった場合は再生を再開
                }

            }
        }


        //トラックバーのクリック時の処理
        private void movie_trackbar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {


                trackbar_mouseup = true;


                play_state = axWindowsMediaPlayer1.playState;  // 現在の再生状態を保存

                // 動画を一時停止する
                if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.pause();
                }

                // TrackBar の現在のインスタンスを取得
                TrackBar tb = (TrackBar)sender;

                // クリックされたX座標とTrackBarの幅から、新しい値を計算する
                // e.X はTrackBarコントロール内での相対X座標
                // tb.Width はTrackBarコントロールの幅

                // クリック位置をTrackBarの最小値から最大値の範囲にマッピング
                // (double)e.X / tb.Width はクリック位置の割合 (0.0 ～ 1.0)
                double clickPercent = (double)e.X / tb.Width;

                // 計算された新しい値
                int new_value = (int)Math.Round(tb.Minimum + (tb.Maximum - tb.Minimum) * clickPercent);

                // TrackBar の値を更新
                tb.Value = new_value;


                //トラックバーの値で動画の再生時間を更新
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = movie_trackbar.Value / 1000.0;
            }
        }

        private void movie_trackbar_Move(object sender, MouseEventArgs e)
        {
            // ドラッグ中であり、かつ左ボタンが押されている場合のみ処理
            if (trackbar_mouseup && e.Button == MouseButtons.Left)
            {
                TrackBar tb = (TrackBar)sender;

                // マウスカーソルがTrackBarの範囲内にあるかを確認
                // e.X がTrackBarの範囲外に出ると、tb.Value = newValue; でエラーになる可能性があるため
                if (e.X >= 0 && e.X <= tb.Width)
                {
                    // クリック位置をTrackBarの最小値から最大値の範囲にマッピング
                    double clickPercent = (double)e.X / tb.Width;
                    int newValue = (int)Math.Round(tb.Minimum + (tb.Maximum - tb.Minimum) * clickPercent);

                    // TrackBar の値を更新 (MouseMove イベントで値を更新)
                    // この更新がTrackBarのサム（つまみ）をドラッグ中も動かす
                    tb.Value = newValue;

                    // トラックバーの値で動画の再生時間を更新
                    // この行がドラッグ中に繰り返し実行されることで、動画がシークされる
                    axWindowsMediaPlayer1.Ctlcontrols.currentPosition = tb.Value / 1000.0;
                }
            }
        }


        // キー操作の処理
        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (output_focus == false) // 出力ファイル名のテキストボックスにフォーカスがある場合は処理を中止
            {
                // Spaceキーが押されたかを判定
                if (e.KeyCode == Keys.C)
                {
                    Properties.Settings.Default.cut_start_time = TimeSpan.FromSeconds(axWindowsMediaPlayer1.Ctlcontrols.currentPosition);  // カット開始時間を現在の再生位置に設定
                    cut_start_time_display_label.Text = $"カット開始時間: {Properties.Settings.Default.cut_start_time.ToString(@"mm\:ss\.ff")}";  // カット開始時間の表示を更新
                }

                if (e.KeyCode == Keys.V)
                {
                    Properties.Settings.Default.cut_end_time = TimeSpan.FromSeconds(axWindowsMediaPlayer1.Ctlcontrols.currentPosition);  // カット終了時間を現在の再生位置に設定
                    cut_end_time_display_label.Text = $"カット終了時間: {Properties.Settings.Default.cut_end_time.ToString(@"mm\:ss\.ff")}"; ;// カット終了時間の表示を更新
                }
            }
        }

        private void tablelayout_click(object sender, MouseEventArgs e)
        {
            this.axWindowsMediaPlayer1.Focus();
        }

        private void output_textbox_focus_leave(object sender, EventArgs e)
        {
            output_focus = false; // 出力ファイル名のテキストボックスからフォーカスが外れたことを記録
        }

        private void output_textbox_enter(object sender, EventArgs e)
        {
            output_focus = true; // 出力ファイル名のテキストボックスにフォーカスが入ったことを記録
        }

        private void output_filename_textbox_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                output_focus = false; // Enterキーが押されたらフォーカスを外す
                this.axWindowsMediaPlayer1.Focus(); // フォーカスをフォームに戻す
                e.SuppressKeyPress = true;
            }
        }
    }
}