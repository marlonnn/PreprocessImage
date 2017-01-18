using System.Windows.Forms;

namespace PreprocessImage
{
    partial class FramePlayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playTimer = new System.Windows.Forms.Timer(this.components);
            this.trackBar = new Summer.UI.Track.MACTrackBar();
            this.lblFps = new System.Windows.Forms.Label();
            this.controlPanel = new PreprocessImage.ControlPanel();
            this.richSplineChart1 = new SplineChart.RichSplineChart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Image = global::PreprocessImage.Properties.Resources.background;
            this.pictureBox.Location = new System.Drawing.Point(3, 25);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(465, 489);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(481, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenItem_Click);
            // 
            // playTimer
            // 
            this.playTimer.Tick += new System.EventHandler(this.PlayTimer_Tick);
            // 
            // trackBar
            // 
            this.trackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar.BackColor = System.Drawing.Color.Transparent;
            this.trackBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.trackBar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.trackBar.Enabled = false;
            this.trackBar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.trackBar.IndentHeight = 6;
            this.trackBar.Location = new System.Drawing.Point(82, 2);
            this.trackBar.Maximum = 50;
            this.trackBar.Minimum = 1;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(358, 22);
            this.trackBar.TabIndex = 3;
            this.trackBar.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.trackBar.TickFrequency = 5;
            this.trackBar.TickHeight = 4;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.trackBar.TrackerSize = new System.Drawing.Size(10, 10);
            this.trackBar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.trackBar.TrackLineHeight = 3;
            this.trackBar.Value = 5;
            this.trackBar.ValueChanged += new Summer.UI.Track.ValueChangedHandler(this.TrackBar_ValueChanged);
            // 
            // lblFps
            // 
            this.lblFps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFps.Location = new System.Drawing.Point(443, 6);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(22, 13);
            this.lblFps.TabIndex = 4;
            this.lblFps.Text = "5";
            // 
            // controlPanel
            // 
            this.controlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlPanel.FPS = 0;
            this.controlPanel.Frames = null;
            this.controlPanel.Location = new System.Drawing.Point(3, 520);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Play = false;
            this.controlPanel.Size = new System.Drawing.Size(468, 61);
            this.controlPanel.TabIndex = 0;
            // 
            // richSplineChart1
            // 
            this.richSplineChart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richSplineChart1.Font = new System.Drawing.Font("Verdana", 9F);
            this.richSplineChart1.Location = new System.Drawing.Point(3, 583);
            this.richSplineChart1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richSplineChart1.Name = "richSplineChart1";
            this.richSplineChart1.Size = new System.Drawing.Size(478, 116);
            this.richSplineChart1.TabIndex = 5;
            // 
            // FramePlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 702);
            this.Controls.Add(this.richSplineChart1);
            this.Controls.Add(this.lblFps);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FramePlayer";
            this.Text = "FramePlayer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlPanel controlPanel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Timer playTimer;
        private Summer.UI.Track.MACTrackBar trackBar;
        private Label lblFps;
        private SplineChart.RichSplineChart richSplineChart1;
    }
}