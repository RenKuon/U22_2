﻿using System;
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
            private Process ffmpegProcess;
            // private FFmpegRecorder recorder;
            StringBuilder outputBuilder = new StringBuilder();
            StringBuilder errorBuilder = new StringBuilder();


            public void StartRecording(string outputFilePath)
            {
                string ffmpegPath = "ffmpeg.exe"; // 実行可能ファイルのパス（相対または絶対）
                string arguments = $"-y -f gdigrab -framerate 60 -i desktop -c:v libx264 -pix_fmt yuv420p -preset ultrafast \"{outputFilePath}\"";

                ffmpegProcess = new Process();
                ffmpegProcess.StartInfo.FileName = ffmpegPath;
                ffmpegProcess.StartInfo.Arguments = arguments;
                ffmpegProcess.StartInfo.CreateNoWindow = true;
                ffmpegProcess.StartInfo.UseShellExecute = false;
                ffmpegProcess.StartInfo.RedirectStandardInput = true;
                ffmpegProcess.StartInfo.RedirectStandardError = true;
                ffmpegProcess.StartInfo.RedirectStandardOutput = true;

                //ここから下が新規
                ffmpegProcess.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        outputBuilder.AppendLine($"FFmpeg StdOut:{e.Data}");
                    }
                };

                ffmpegProcess.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        errorBuilder.AppendLine($"FFmpeg StdErr:{e.Data}");
                    }
                };
                //ここから上が新規

                try
                {
                    ffmpegProcess.Start();
                    ffmpegProcess.BeginOutputReadLine();
                    ffmpegProcess.BeginErrorReadLine();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("FFmpeg の起動に失敗しました: " + ex.Message);
                }
            }

            public void StopRecording()
            {
                if (ffmpegProcess != null && !ffmpegProcess.HasExited)
                {
                    ffmpegProcess.StandardInput.WriteLine("q");
                    ffmpegProcess.WaitForExit();                 // プロセスが完全に終了するまで待つ
                                                                 // 必要ならここで UI 更新や「録画完了」メッセージなど
                                                                 //ここから下が新規
                                                                 // 例: StopRecordingの最後などに追記
                    string logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
                    Directory.CreateDirectory(logFolder); // フォルダがなければ作る

                    string logFilePath = Path.Combine(logFolder, $"ffmpeg_log_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

                    File.WriteAllText(logFilePath, outputBuilder.ToString() + Environment.NewLine + errorBuilder.ToString());
                    //ここから上が新規
                    //C:\VisualStudio\プロコン部チーム_0622_TEST\bin\Debug\logsにログファイル出力

                    MessageBox.Show("録画ファイルの保存が完了しました。");
                }
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