namespace PreprocessImage
{
    partial class ControlPanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.colorSlider = new Summer.UI.Slider.ColorSlider();
            this.btnRewind = new System.Windows.Forms.Button();
            this.btnForword = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCurrent
            // 
            this.lblCurrent.Location = new System.Drawing.Point(8, 5);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(35, 15);
            this.lblCurrent.TabIndex = 8;
            this.lblCurrent.Text = "00:00";
            // 
            // lblDuration
            // 
            this.lblDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDuration.Location = new System.Drawing.Point(432, 5);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(35, 15);
            this.lblDuration.TabIndex = 9;
            this.lblDuration.Text = "00:00";
            // 
            // colorSlider
            // 
            this.colorSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorSlider.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider.BarInnerColor = System.Drawing.SystemColors.Control;
            this.colorSlider.BarOuterColor = System.Drawing.SystemColors.Control;
            this.colorSlider.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider.Enabled = false;
            this.colorSlider.LargeChange = ((uint)(5u));
            this.colorSlider.Location = new System.Drawing.Point(47, 3);
            this.colorSlider.Name = "colorSlider";
            this.colorSlider.Size = new System.Drawing.Size(379, 17);
            this.colorSlider.SmallChange = ((uint)(1u));
            this.colorSlider.TabIndex = 4;
            this.colorSlider.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.colorSlider.ThumbRoundRectSize = new System.Drawing.Size(2, 2);
            this.colorSlider.Value = 0;
            this.colorSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Slider_Scroll);
            // 
            // btnRewind
            // 
            this.btnRewind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRewind.BackgroundImage = global::PreprocessImage.Properties.Resources.rewind;
            this.btnRewind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRewind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRewind.Location = new System.Drawing.Point(170, 23);
            this.btnRewind.Name = "btnRewind";
            this.btnRewind.Size = new System.Drawing.Size(35, 35);
            this.btnRewind.TabIndex = 3;
            this.btnRewind.UseVisualStyleBackColor = true;
            this.btnRewind.Click += new System.EventHandler(this.btnRewind_Click);
            // 
            // btnForword
            // 
            this.btnForword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnForword.BackgroundImage = global::PreprocessImage.Properties.Resources.forward;
            this.btnForword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnForword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForword.Location = new System.Drawing.Point(252, 23);
            this.btnForword.Name = "btnForword";
            this.btnForword.Size = new System.Drawing.Size(35, 35);
            this.btnForword.TabIndex = 2;
            this.btnForword.UseVisualStyleBackColor = true;
            this.btnForword.Click += new System.EventHandler(this.btnForword_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.BackgroundImage = global::PreprocessImage.Properties.Resources.pause;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(211, 23);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(35, 35);
            this.btnStop.TabIndex = 1;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlay.BackgroundImage = global::PreprocessImage.Properties.Resources.play;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Location = new System.Drawing.Point(8, 23);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(35, 35);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.colorSlider);
            this.Controls.Add(this.btnRewind);
            this.Controls.Add(this.btnForword);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Name = "ControlPanel";
            this.Size = new System.Drawing.Size(470, 61);
            this.Load += new System.EventHandler(this.ControlPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnForword;
        private System.Windows.Forms.Button btnRewind;
        private Summer.UI.Slider.ColorSlider colorSlider;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblDuration;
    }
}
