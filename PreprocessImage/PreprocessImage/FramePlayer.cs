using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PreprocessImage
{
    public partial class FramePlayer : Form
    {
        private Object thisLock = new Object();

        private List<Frame> frames;

        private int numberOfPointsInChart = 300;

        private int numberOfPointsAfterRemoval = 100;

        private int currentNumber;

        private bool start;

        public int CurrentNumber
        {
            get { return this.currentNumber; }
            set
            {
                lock (thisLock)
                {
                    this.currentNumber = value;
                }
            }
        }

        private int _fps;

        public int FPS
        {
            set
            {
                this._fps = value;
                this.playTimer.Interval = 1000 / value;
                //this.controlPanel.FPS = value;

            }
        }

        public FramePlayer()
        {
            InitializeComponent();

            _fps = 5;
            frames = new List<Frame>();
            //Set initialize 5 FPS
            this.playTimer.Interval = 200;
            start = true;
            this.progressBar1.Enabled = false;
            this.startToolStripMenuItem.Enabled = false;
            this.openToolStripMenuItem.Enabled = true;
            this.progressBar1.Value = 0;
        }

        /// <summary>
        /// 停止播放
        /// </summary>
        private void StopPlay()
        {
            this.playTimer.Enabled = false;
            this.pictureBox.Image = global::PreprocessImage.Properties.Resources.background;
            this.currentNumber = 0;
            this.startToolStripMenuItem.Enabled = false;
            this.openToolStripMenuItem.Enabled = true;
        }

        private void PlayTimer_Tick(object sender, EventArgs e)
        {
            if (this.frames != null && this.frames.Count > 0)
            {
                this.pictureBox.ImageLocation = frames[currentNumber].FileFullName;

                //this.controlPanel.UpdateControlPanel(currentNumber);
                if (currentNumber == 0)
                {
                    CalcImageDiff(null, frames[currentNumber], currentNumber);
                }
                else
                {
                    CalcImageDiff(frames[currentNumber - 1], frames[currentNumber], currentNumber);
                }
                ShowSplineChart(frames[currentNumber], currentNumber);
                UpdateProgressBar(currentNumber);
                currentNumber = ++currentNumber;
                if (currentNumber == frames.Count)
                {
                    StopPlay();
                }
            }
        }

        /// <summary>
        /// 更新进度条
        /// </summary>
        /// <param name="value"></param>
        private void UpdateProgressBar(int value)
        {

            this.progressBar1.Value = value;
        }

        /// <summary>
        /// 显示柱状图
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="pointIndex"></param>
        private void ShowSplineChart(Frame frame, int pointIndex)
        {
            // adding new data points
            this.richSplineChart1.Chart.Series[0].Points.AddXY(pointIndex + 1, frame.ImageDiff);
            // Adjust Y & X axis scale
            this.richSplineChart1.Chart.ResetAutoValues();
            if (this.richSplineChart1.Chart.ChartAreas["Default"].AxisX.Maximum < pointIndex)
            {
                this.richSplineChart1.Chart.ChartAreas["Default"].AxisX.Maximum = pointIndex;
            }
            // Keep a constant number of points by removing them from the left
            while (this.richSplineChart1.Chart.Series[0].Points.Count > numberOfPointsInChart)
            {
                // Remove data points on the left side
                while (this.richSplineChart1.Chart.Series[0].Points.Count > numberOfPointsAfterRemoval)
                {
                    this.richSplineChart1.Chart.Series[0].Points.RemoveAt(0);
                }

                // Adjust X axis scale
                this.richSplineChart1.Chart.ChartAreas["Default"].AxisX.Minimum = pointIndex - numberOfPointsAfterRemoval;
                this.richSplineChart1.Chart.ChartAreas["Default"].AxisX.Maximum = this.richSplineChart1.Chart.ChartAreas["Default"].AxisX.Minimum + numberOfPointsInChart;
            }
            this.richSplineChart1.Chart.SaveImage(string.Format("{0}\\ChartImages\\{1}_chart.png",System.Environment.CurrentDirectory, pointIndex), ChartImageFormat.Png);
            // Redraw chart
            this.richSplineChart1.Chart.Invalidate();
        }

        /// <summary>
        /// 计算差值
        /// </summary>
        /// <param name="preFrame">前一图片</param>
        /// <param name="currentFrame">当前图片</param>
        /// <param name="currentIndex">当前图片位置</param>
        private void CalcImageDiff(Frame preFrame, Frame currentFrame, int currentIndex)
        {
            try
            {
                if (preFrame != null)
                {
                    //Simulate need
                    //double diff = AlgorithmHelper.CalcDiff(preFrame.FileFullName, currentFrame.FileFullName);
                    double diff = AlgorithmHelper.CalcImageDiff(preFrame.FileFullName, currentFrame.FileFullName,
                        500, 600, string.Format("{0}\\ProcessedImages\\{1}_processed.png", System.Environment.CurrentDirectory, currentIndex));
                    currentFrame.ImageDiff = diff;
                    currentFrame.DiffList = new List<double>();
                    currentFrame.DiffList.AddRange(preFrame.DiffList);
                    currentFrame.DiffList.Add(diff);
                }
                else
                {
                    currentFrame.ImageDiff = 0;
                    currentFrame.DiffList = new List<double>();
                    currentFrame.DiffList.Add(0);
                }
            }
            catch (Exception e)
            {
            }
        }

        private void OpenItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog ofd = new FolderBrowserDialog())
            {
                ofd.Description = "请选择将要播放帧图的文件夹";
                ofd.RootFolder = Environment.SpecialFolder.Desktop;
                ofd.SelectedPath = System.Environment.CurrentDirectory + "\\Images";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    frames.Clear();
                    string fileFolder = ofd.SelectedPath;
                    DirectoryInfo folder = new DirectoryInfo(fileFolder);
                    try
                    {
                        FileInfo[] fileInfos = folder.GetFiles();
                        Array.Sort(fileInfos, delegate (FileInfo x, FileInfo y)
                        {
                            return Int32.Parse(Path.GetFileNameWithoutExtension(x.Name)).CompareTo
                            (Int32.Parse(Path.GetFileNameWithoutExtension(y.Name)));
                        });
                        foreach (FileInfo info in fileInfos)
                        {
                            var v = Path.GetFileNameWithoutExtension(info.Name);
                            Frame frame = new Frame(info.FullName, fileFolder);
                            frames.Add(frame);
                        }
                        numberOfPointsInChart = this.frames.Count;
                        this.lblFps.Text = this._fps.ToString();
                        this.startToolStripMenuItem.Enabled = true;
                        this.progressBar1.Maximum = this.frames.Count;
                    }
                    catch (Exception ee)
                    {
                    }
                }
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            start = !start;
            ChangeStartToolStripMenuItem(start);
        }

        private void ChangeStartToolStripMenuItem(bool start)
        {
            this.startToolStripMenuItem.Image = start ? 
                global::PreprocessImage.Properties.Resources.Run : global::PreprocessImage.Properties.Resources.pause;
            this.startToolStripMenuItem.Text = start ? "Start" : "Pause";
            this.playTimer.Enabled = !start;
            this.openToolStripMenuItem.Enabled = start;
        }
    }
}
