using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static プロコン部チーム_0622_TEST.Form2;

namespace プロコン部チーム_0622_TEST
{
    public partial class Form1 : Form
    {
        FFmpegRecorder recorder;

        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false; // 最大化ボタンを無効化
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // サイズ変更を禁止
            //this.Icon = new System.Drawing.Icon("C:\\Users\\legac\\OneDrive\\画像\\Test_GUI.ico"); 
            //↑アイコンを入れる場合（.icoへの正しい変換が必要）
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        public class FFmpegRecorder
        {
            private List<string> segmentFiles = new List<string>();
            private string segmentFolder;
            private CancellationTokenSource cts;
            private int segmentDuration = 5; // 5秒ごとのセグメント
            StringBuilder outputBuilder = new StringBuilder();
            StringBuilder errorBuilder = new StringBuilder();

            public void StartRecording(string outputFilePath)
            {
                segmentFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "segments");
                Directory.CreateDirectory(segmentFolder);
                segmentFiles.Clear();
                cts = new CancellationTokenSource();

                int maxSegments = (int)Math.Ceiling((double)Form2.Recordtime / segmentDuration);
                string dateStamp = DateTime.Now.ToString("yyyy_MM_dd");
                int i = 0;

                Task.Run(() =>
                {
                    while (!cts.IsCancellationRequested)
                    {
                        int segmentIndex = i % maxSegments;
                        string segmentFile = Path.Combine(segmentFolder, $"{dateStamp}_{segmentIndex}.mp4");

                        // 保存リストに追加（上書きでもリスト保持）
                        if (!segmentFiles.Contains(segmentFile))
                        {
                            segmentFiles.Add(segmentFile);
                        }

                        using (var ffmpeg = new Process())
                        {
                            ffmpeg.StartInfo.FileName = "ffmpeg.exe";
                            ffmpeg.StartInfo.Arguments =
                                $"-y -f gdigrab -framerate 60 -i desktop -t {segmentDuration} -c:v libx264 -pix_fmt yuv420p -preset ultrafast \"{segmentFile}\"";
                            ffmpeg.StartInfo.CreateNoWindow = true;
                            ffmpeg.StartInfo.UseShellExecute = false;
                            ffmpeg.Start();
                            ffmpeg.WaitForExit();
                        }

                        if (!File.Exists(segmentFile))
                        {
                            MessageBox.Show($"録画に失敗しました: {segmentFile}");
                        }

                        i++;
                    }
                });
            }


            public void StopRecording()
            {
                cts?.Cancel();

                string logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
                Directory.CreateDirectory(logFolder);
                string logFilePath = Path.Combine(logFolder, $"ffmpeg_log_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
                File.WriteAllText(logFilePath, outputBuilder.ToString() + Environment.NewLine + errorBuilder.ToString());

                string concatListPath = Path.Combine(segmentFolder, "concat.txt");
                using (StreamWriter writer = new StreamWriter(concatListPath, false, Encoding.UTF8))
                {
                    foreach (var file in segmentFiles)
                    {
                        writer.WriteLine($"file '{file.Replace("\\", "/")}'");
                    }
                }

                string baseName = $"combined_{DateTime.Now:yyyy_MM_dd}";
                string outputFolder = Path.GetDirectoryName(Properties.Settings.Default.raw_movie_filepath);
                string finalName = baseName + ".mp4";
                int suffix = 1;
                while (File.Exists(Path.Combine(outputFolder, finalName)))
                {
                    finalName = $"{baseName}_{suffix}.mp4";
                    suffix++;
                }

                string finalPath = Path.Combine(outputFolder, finalName);

                using (var ffmpeg = new Process())
                {
                    ffmpeg.StartInfo.FileName = "ffmpeg.exe";
                    ffmpeg.StartInfo.Arguments = $"-y -f concat -safe 0 -i \"{concatListPath}\" -c copy \"{finalPath}\"";
                    ffmpeg.StartInfo.CreateNoWindow = true;
                    ffmpeg.StartInfo.UseShellExecute = false;
                    ffmpeg.Start();
                    ffmpeg.WaitForExit();
                }

                MessageBox.Show("録画ファイルの保存が完了しました。");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("録画を開始しました。");
            button1.Enabled = false;    //開始ボタンを押せなくする
            button2.Visible = true;       //停止ボタンを出現させる
            label1.Visible = true;        //「録画中」を出現させる
            button3.Enabled = false;    //設定を押せなくする
            button4.Enabled = false;    //編集を押せなくする

            recorder = new FFmpegRecorder();

            //フォルダ作成機能

            //string folderPath = Path.Combine(AppState.FolderPath, AppState.FolderName);
            //Directory.CreateDirectory(folderPath); // 存在しない場合でも安全に作成されます

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string outputFile = $"recording_{timestamp}.mp4";// 出力ファイル名（必要に応じてパスも指定可）

            string outputFilePath = Path.Combine(Properties.Settings.Default.folderpath, outputFile);//出力先パス、ファイル名をグローバルな変数から持ってくる
            Properties.Settings.Default.raw_movie_filepath = outputFilePath; //設定ファイルに出力先パスを保存
            recorder.StartRecording(outputFilePath);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("録画を停止しました。");
            button1.Enabled = true;     //開始ボタンを再び有効化
            button2.Visible = false;    //停止ボタンを隠す
            label1.Visible = false;       //「録画中」を隠す
            button3.Enabled = true;     //設定を有効化
            button4.Enabled = true;     //編集を有効化

            recorder.StopRecording();



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show(); // モードレス表示（親フォームも操作可能）
                          // form2.ShowDialog(); // モーダル表示（親フォームは操作不可）

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show(); // モードレス表示（親フォームも操作可能）
        }
        /*
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ffmpegProcess != null && !ffmpegProcess.HasExited)
            {
                ffmpegProcess.StandardInput.WriteLine("q");
                ffmpegProcess.WaitForExit(3000); // 最後の処理に余裕をもたせる
                if (!ffmpegProcess.HasExited)
                {
                    ffmpegProcess.Kill();
                }
            }
        }
        */

    }

}