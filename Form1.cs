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
            private List<string> segmentFiles = new List<string>();
            private string segmentFolder;
            private CancellationTokenSource cts;
            private int segmentDuration = 5;
            StringBuilder outputBuilder = new StringBuilder();
            StringBuilder errorBuilder = new StringBuilder();

            public void StartRecording(string outputFilePath)
            {
                segmentFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "segments");
                Directory.CreateDirectory(segmentFolder);
                segmentFiles.Clear();
                cts = new CancellationTokenSource();

                int maxSegments = (int)Math.Ceiling((double)Properties.Settings.Default.recordtime / segmentDuration);
                string dateStamp = DateTime.Now.ToString("yyyy_MM_dd");
                int i = 0;

                Task.Run(() =>
                {
                    while (!cts.IsCancellationRequested)
                    {
                        int segmentIndex = i % maxSegments;
                        string segmentFile = Path.Combine(segmentFolder, $"{dateStamp}_{segmentIndex}.ts");

                        if (!segmentFiles.Contains(segmentFile))
                        {
                            segmentFiles.Add(segmentFile);
                        }

                        using (var ffmpeg = new Process())
                        {

                            string set_output_device = "ステレオ ミキサー (Realtek(R) Audio)";

                            ffmpeg.StartInfo.FileName = "ffmpeg.exe";
                            ffmpeg.StartInfo.Arguments =
                                $"-y " +
                                $"-video_size 1920x1080 -framerate 60 " +
                                $"-f gdigrab -i desktop " +
                                $"-f dshow -i audio=\"{set_output_device}\" " +
                                $"-t {segmentDuration} " +
                                $"-map 0:v:0 -map 1:a:0 " +
                                $"-vcodec libx264 -pix_fmt yuv420p -acodec aac -b:a 320k -ac 2 -ar 44100 " +
                                $"-reset_timestamps 1 " +
                                $"-f mpegts \"{segmentFile}\"";
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

                if (segmentFiles.Count == 0)
                {
                    MessageBox.Show("連結対象のセグメントファイルがありません。");
                    return;
                }


                segmentFiles = segmentFiles
                    .Where(File.Exists)
                    .OrderBy(file => File.GetLastWriteTimeUtc(file))
                    .ToList();

                string concatListPath = Path.Combine(segmentFolder, "concat.txt");
                using (StreamWriter writer = new StreamWriter(concatListPath, false, new UTF8Encoding(false))) // ← BOMなし
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
                    ffmpeg.StartInfo.Arguments = $"-y -f concat -safe 0 -i \"{concatListPath}\" -c copy -f mp4 \"{finalPath}\"";
                    ffmpeg.StartInfo.CreateNoWindow = true;
                    ffmpeg.StartInfo.UseShellExecute = false;
                    ffmpeg.StartInfo.RedirectStandardOutput = false;
                    ffmpeg.StartInfo.RedirectStandardError = false;

                    ffmpeg.Start();
                    ffmpeg.WaitForExit();

                    if (ffmpeg.ExitCode != 0 || !File.Exists(finalPath))
                    {
                        MessageBox.Show("連結に失敗しました。詳細はログをご確認ください。");
                        File.AppendAllText(logFilePath, $"\n[ERROR] FFmpeg exited with code {ffmpeg.ExitCode}\n");
                        return;
                    }
                }

                MessageBox.Show("録画ファイルの保存が完了しました。");

                GC.Collect();
                GC.WaitForPendingFinalizers();

                try
                {
                    string[] files = Directory.GetFiles(segmentFolder);
                    foreach (var file in files)
                    {
                        int retry = 0;
                        while (retry < 3)
                        {
                            try
                            {
                                File.Delete(file);
                                break;
                            }
                            catch (IOException)
                            {
                                Thread.Sleep(500); // 少し待って再試行
                                retry++;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"セグメントファイルの削除に失敗しました: {ex.Message}");
                }

            }
        }
    }
}