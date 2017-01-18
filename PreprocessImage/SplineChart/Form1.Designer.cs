namespace SplineChart
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxPointsRemoved = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxVisiblePoints = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxUpdateInterval = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.richSplineChart1 = new SplineChart.RichSplineChart();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 200;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.comboBoxPointsRemoved);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBoxVisiblePoints);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxUpdateInterval);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonStart);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 154);
            this.panel1.TabIndex = 3;
            // 
            // comboBoxPointsRemoved
            // 
            this.comboBoxPointsRemoved.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPointsRemoved.Items.AddRange(new object[] {
            "1",
            "25",
            "50",
            "75"});
            this.comboBoxPointsRemoved.Location = new System.Drawing.Point(168, 88);
            this.comboBoxPointsRemoved.Name = "comboBoxPointsRemoved";
            this.comboBoxPointsRemoved.Size = new System.Drawing.Size(80, 22);
            this.comboBoxPointsRemoved.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Points &Removed:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxVisiblePoints
            // 
            this.comboBoxVisiblePoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVisiblePoints.Items.AddRange(new object[] {
            "100",
            "150",
            "200",
            "300"});
            this.comboBoxVisiblePoints.Location = new System.Drawing.Point(168, 48);
            this.comboBoxVisiblePoints.Name = "comboBoxVisiblePoints";
            this.comboBoxVisiblePoints.Size = new System.Drawing.Size(80, 22);
            this.comboBoxVisiblePoints.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "&Number of Visible Points:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxUpdateInterval
            // 
            this.comboBoxUpdateInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUpdateInterval.Items.AddRange(new object[] {
            "100",
            "200",
            "300",
            "500",
            "1000",
            "1500",
            "2000"});
            this.comboBoxUpdateInterval.Location = new System.Drawing.Point(168, 8);
            this.comboBoxUpdateInterval.Name = "comboBoxUpdateInterval";
            this.comboBoxUpdateInterval.Size = new System.Drawing.Size(80, 22);
            this.comboBoxUpdateInterval.TabIndex = 1;
            this.comboBoxUpdateInterval.SelectedIndexChanged += new System.EventHandler(this.comboBoxUpdateInterval_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update &Interval (mS):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.SystemColors.Control;
            this.buttonStart.Location = new System.Drawing.Point(104, 126);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(144, 23);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "&Stop Real Time Data";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(6, 126);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save Image";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // richSplineChart1
            // 
            this.richSplineChart1.Font = new System.Drawing.Font("Verdana", 9F);
            this.richSplineChart1.Location = new System.Drawing.Point(306, 9);
            this.richSplineChart1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richSplineChart1.Name = "richSplineChart1";
            this.richSplineChart1.Size = new System.Drawing.Size(531, 157);
            this.richSplineChart1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(850, 175);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richSplineChart1);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Simulate Spline Chart Form";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void Form_Load(object sender, System.EventArgs e)
        {
            comboBoxUpdateInterval.SelectedIndex = 2;
            comboBoxVisiblePoints.SelectedIndex = 2;
            comboBoxPointsRemoved.SelectedIndex = 0;
        }

        #endregion

        private RichSplineChart richSplineChart1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxPointsRemoved;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxVisiblePoints;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxUpdateInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button btnSave;
    }
}

