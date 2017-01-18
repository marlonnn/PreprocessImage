using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SplineChart
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private int pointIndex = 0;
        private Chart chart1;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            chart1 = this.richSplineChart1.Chart;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxUpdateInterval.SelectedIndex = 2;
            comboBoxVisiblePoints.SelectedIndex = 2;
            comboBoxPointsRemoved.SelectedIndex = 0;
        }

        private void comboBoxUpdateInterval_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.timer.Interval = int.Parse(comboBoxUpdateInterval.Text);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Define some variables
            int numberOfPointsInChart = int.Parse(comboBoxVisiblePoints.Text);
            int numberOfPointsAfterRemoval = numberOfPointsInChart - int.Parse(comboBoxPointsRemoved.Text);

            // Simulate adding new data points
            int numberOfPointsAddedMin = 5;
            int numberOfPointsAddedMax = 10;
            for (int pointNumber = 0; pointNumber <
                random.Next(numberOfPointsAddedMin, numberOfPointsAddedMax); pointNumber++)
            {
                chart1.Series[0].Points.AddXY(pointIndex + 1, random.Next(60, 100));
                ++pointIndex;
            }

            // Adjust Y & X axis scale
            chart1.ResetAutoValues();
            if (chart1.ChartAreas["Default"].AxisX.Maximum < pointIndex)
            {
                chart1.ChartAreas["Default"].AxisX.Maximum = pointIndex;
            }

            // Keep a constant number of points by removing them from the left
            while (chart1.Series[0].Points.Count > numberOfPointsInChart)
            {
                // Remove data points on the left side
                while (chart1.Series[0].Points.Count > numberOfPointsAfterRemoval)
                {
                    chart1.Series[0].Points.RemoveAt(0);
                }

                // Adjust X axis scale
                chart1.ChartAreas["Default"].AxisX.Minimum = pointIndex - numberOfPointsAfterRemoval;
                chart1.ChartAreas["Default"].AxisX.Maximum = chart1.ChartAreas["Default"].AxisX.Minimum + numberOfPointsInChart;
            }

            // Redraw chart
            chart1.Invalidate();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (this.timer.Enabled)
            {
                this.timer.Enabled = false;
                buttonStart.Text = "&Start Real Time Data";
            }
            else
            {
                this.timer.Enabled = true;
                buttonStart.Text = "&Stop Real Time Data";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = System.Environment.CurrentDirectory;
            saveFileDialog.Title = "保存文件";
            //saveFileDialog.Filter = "PNG文件(*.png)|*.png|JPG文件(*.jpg)|*.jpg|所有文件(*.*)|*.*";
            saveFileDialog.Filter = "PNG文件(*.png)|*.png";
            //默认文件类型显示顺序  
            saveFileDialog.FilterIndex = 1;
            //记忆上次保存路径  
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                {
                    string localFilePath = saveFileDialog.FileName.ToString();
                    chart1.SaveImage(localFilePath, ChartImageFormat.Png);
                }
            }
        }

        /// <summary>
        /// 保存chart为图片，默认为PNG格式
        /// </summary>
        /// <param name="fileFullName">文件全名</param>
        /// <param name="imageFormat">图片格式</param>
        public void SaveImage(string fileFullName, ChartImageFormat imageFormat = ChartImageFormat.Png)
        {
            chart1.SaveImage(fileFullName, imageFormat);
        }
    }
}
