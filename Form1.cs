using NAudio.Wave;
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
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        // ✅ イベントハンドラはここ（Form1内）に定義すべき
        private void button1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.folderpath == "")
            {
                MessageBox.Show("保存先フォルダが設定されていません。設定を行ってください。");
                return;
            }


            // NAudioを使ってオーディオ出力デバイスの数を取得
            int deviceCount = WaveIn.DeviceCount;

            for (int i = 0; i < deviceCount; i++)
            {
                var caps = WaveIn.GetCapabilities(i);

                if (caps.ProductName.Contains("ステレオ ミキサー"))
                {
                    Properties.Settings.Default.set_output_device = caps.ProductName; // 設定に保存
                    Properties.Settings.Default.Save(); // 設定を保存
                }
            }

            if (!Properties.Settings.Default.set_output_device.Contains("ステレオ ミキサー"))
            {
                MessageBox.Show("ステレオ ミキサーが見つかりません。ステレオミキサーを有効にしてください。");
                return;
            }


            if (Properties.Settings.Default.recordtime <= 0)
            {
                MessageBox.Show("録画時間が設定されていません。設定を行ってください。");
                return;
            }

            MessageBox.Show("録画を開始しました。");
            button1.Enabled = false;
            button2.Visible = true;
            label1.Visible = true;
            button3.Enabled = false;
            button4.Enabled = false;

            recorder = new FFmpegRecorder();

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string outputFile = $"recording_{timestamp}.mp4";
            string outputFilePath = Path.Combine(Properties.Settings.Default.folderpath, outputFile);
            Properties.Settings.Default.raw_movie_filepath = outputFilePath;

            recorder.StartRecording(outputFilePath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("録画を停止しました。");
            button1.Enabled = true;
            button2.Visible = false;
            label1.Visible = false;
            button3.Enabled = true;
            button4.Enabled = true;

            recorder.StopRecording();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public class FFmpegRecorder
        {
            private Process ffmpegProcess;
            private CancellationTokenSource cts;
            private string tempRecordingPath;
            private StringBuilder outputBuilder = new StringBuilder();
            private StringBuilder errorBuilder = new StringBuilder();

            public void StartRecording(string outputFilePath)
            {
                cts = new CancellationTokenSource();

                string segmentFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "segments");
                Directory.CreateDirectory(segmentFolder);
                tempRecordingPath = Path.Combine(segmentFolder, "temp_recording.mp4");

                string set_output_device = Properties.Settings.Default.set_output_device;

                ffmpegProcess = new Process();
                ffmpegProcess.StartInfo.FileName = "ffmpeg.exe";
                ffmpegProcess.StartInfo.Arguments =
                    $"-y -video_size 1920x1080 -framerate 60 " +
                    $"-f gdigrab -i desktop " +
                    $"-f dshow -i audio=\"{set_output_device}\" " +
                    $"-map 0:v:0 -map 1:a:0 " +
                    $"-vcodec libx264 -pix_fmt yuv420p -acodec aac -b:a 320k -ac 2 -ar 44100 " +
                    $"\"{tempRecordingPath}\"";

                ffmpegProcess.StartInfo.CreateNoWindow = true;
                ffmpegProcess.StartInfo.UseShellExecute = false;
                ffmpegProcess.StartInfo.RedirectStandardOutput = false;
                ffmpegProcess.StartInfo.RedirectStandardError = false;

                ffmpegProcess.Start();
            }

            public void StopRecording()
            {
                try
                {
                    if (ffmpegProcess != null && !ffmpegProcess.HasExited)
                    {
                        ffmpegProcess.Kill();
                        ffmpegProcess.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"録画停止に失敗しました: {ex.Message}");
                    return;
                }

                string segmentFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "segments");
                string logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
                Directory.CreateDirectory(logFolder);
                string logFilePath = Path.Combine(logFolder, $"ffmpeg_log_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
                File.WriteAllText(logFilePath, outputBuilder.ToString() + Environment.NewLine + errorBuilder.ToString());

                if (!File.Exists(tempRecordingPath))
                {
                    MessageBox.Show("録画ファイルが存在しません。");
                    return;
                }

                // 録画時間取得
                double durationSeconds;
                using (var ffprobe = new Process())
                {
                    ffprobe.StartInfo.FileName = "ffprobe.exe";
                    ffprobe.StartInfo.Arguments = $"-v error -show_entries format=duration -of default=noprint_wrappers=1:nokey=1 \"{tempRecordingPath}\"";
                    ffprobe.StartInfo.RedirectStandardOutput = true;
                    ffprobe.StartInfo.UseShellExecute = false;
                    ffprobe.StartInfo.CreateNoWindow = true;

                    ffprobe.Start();
                    string output = ffprobe.StandardOutput.ReadToEnd();
                    ffprobe.WaitForExit();

                    if (!double.TryParse(output.Trim(), out durationSeconds))
                    {
                        MessageBox.Show("録画時間の取得に失敗しました。");
                        return;
                    }
                }

                int recordtime = Properties.Settings.Default.recordtime;
                double startTime = Math.Max(0, durationSeconds - recordtime);


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
                    ffmpeg.StartInfo.Arguments =
                        $"-y -ss {startTime} -i \"{tempRecordingPath}\" -t {recordtime} -c:v libx264 -c:a aac \"{finalPath}\"";

                    ffmpeg.StartInfo.CreateNoWindow = true;
                    ffmpeg.StartInfo.UseShellExecute = false;
                    ffmpeg.StartInfo.RedirectStandardOutput = false;
                    ffmpeg.StartInfo.RedirectStandardError = false;

                    ffmpeg.Start();
                    ffmpeg.WaitForExit();

                    if (ffmpeg.ExitCode != 0 || !File.Exists(finalPath))
                    {
                        MessageBox.Show("録画の切り出しに失敗しました。詳細はログをご確認ください。");
                        File.AppendAllText(logFilePath, $"\n[ERROR] FFmpeg exited with code {ffmpeg.ExitCode}\n");
                        return;
                    }
                }

                MessageBox.Show("録画ファイルの保存が完了しました。");

                try
                {
                    File.Delete(tempRecordingPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"一時録画ファイルの削除に失敗しました: {ex.Message}");
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }




        private void stop_rec_keydown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F10)
            {
                button2_Click(sender, e);
            }
        }
    }
}