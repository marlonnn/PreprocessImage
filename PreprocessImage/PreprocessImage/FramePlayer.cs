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
        private List<Frame> _frames;

        private int numberOfPointsInChart = 300;

        private int numberOfPointsAfterRemoval = 100;

        private int _currentNumber;

        public int CurrentNumber
        {
            get { return this._currentNumber; }
            set
            {
                lock (thisLock)
                {
                    this._currentNumber = value;
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
                this.controlPanel.FPS = value;

            }
        }

        public FramePlayer()
        {
            InitializeComponent();

            _fps = 5;
            _frames = new List<Frame>();
            //Set initialize 5 FPS
            this.playTimer.Interval = 200;
            this.controlPanel.PlayClickHandler += PlayClickHandler;
            this.controlPanel.StopClickHandler += StopClickHandler;
        }

        private void StopPlay()
        {
            this.playTimer.Enabled = false;
            this.pictureBox.Image = global::PreprocessImage.Properties.Resources.background;
            this._currentNumber = 0;
        }

        private void StopClickHandler(object sender, EventArgs e)
        {
            StopPlay();
            this.controlPanel.Play = false;
            this.controlPanel.StopControlPanel();

        }

        private void PlayClickHandler(object sender, EventArgs e)
        {
            this.playTimer.Enabled = this.controlPanel.Play;
        }

        private void PlayTimer_Tick(object sender, EventArgs e)
        {
            if (this._frames != null && this._frames.Count > 0)
            {
                this.pictureBox.ImageLocation = _frames[_currentNumber].FileFullName;

                this.controlPanel.UpdateControlPanel(_currentNumber);
                if (_currentNumber == 0)
                    CalcImageDiff(null, _frames[_currentNumber]);
                else
                    CalcImageDiff(_frames[_currentNumber - 1], _frames[_currentNumber]);
                ShowSplineChart(_frames[_currentNumber], _currentNumber);
                _currentNumber = ++_currentNumber;
                if (_currentNumber == _frames.Count)
                {
                    this._currentNumber = 0;
                    this.playTimer.Enabled = false;
                    this.controlPanel.Play = false;
                    this.controlPanel.Finish();
                }
            }
        }

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
            this.richSplineChart1.Chart.SaveImage(string.Format("{0}\\SourceImage\\{1}_processed.png",System.Environment.CurrentDirectory, pointIndex), ChartImageFormat.Png);
            // Redraw chart
            this.richSplineChart1.Chart.Invalidate();
        }

        private void CalcImageDiff(Frame preFrame, Frame currentFrame)
        {
            if (preFrame != null)
            {
                double diff = AlgorithmHelper.CalcDiff(preFrame.FileFullName, currentFrame.FileFullName);
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

        private void OpenItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog ofd = new FolderBrowserDialog())
            {
                ofd.Description = "请选择将要播放帧图的文件夹";
                ofd.RootFolder = Environment.SpecialFolder.Desktop;
                ofd.SelectedPath = System.Environment.CurrentDirectory + "\\Images";

                _frames.Clear();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
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
                            _frames.Add(frame);
                        }
                        this.trackBar.Enabled = true;
                        this.controlPanel.EnableSlider(true);
                        this.controlPanel.InitializeControlPanel(_frames, _fps);
                        numberOfPointsInChart = this._frames.Count;
                    }
                    catch (Exception ee)
                    {
                    }
                }
            }
        }

        private void TrackBar_ValueChanged(object sender, decimal value)
        {
            this.lblFps.Text = value.ToString();
            this.FPS = (int)(value);
            this.controlPanel.CalculateDuration();
        }
    }
}
