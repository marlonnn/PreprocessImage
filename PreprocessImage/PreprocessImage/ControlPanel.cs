using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreprocessImage
{
    public partial class ControlPanel : UserControl
    {
        private List<Frame> _frames;

        private int _fps;

        public int FPS
        {
            get { return this._fps; }
            set { this._fps = value; }
        }


        public delegate void ClickDelegate(object sender, EventArgs e);

        public ClickDelegate PlayClickHandler;

        public ClickDelegate StopClickHandler;

        private bool _play;

        private FramePlayer _framePlayer;

        public bool Play
        {
            get { return this._play; }
            set { this._play = value; }
        }

        public ControlPanel()
        {
            InitializeComponent();

            _play = false;
        }



        public List<Frame> Frames
        {
            get { return this._frames; }
            set
            {
                this._frames = value;
            }
        }

        public void InitializeControlPanel(List<Frame> frames, int fps)
        {
            this._frames = frames;
            this._fps = fps;
            this.colorSlider.Maximum = this._frames.Count;
            this.lblDuration.Text = CalculateDuration(this._frames.Count);
        }

        private string CalculateDuration(int value)
        {
            int amount = value / this._fps;
            int sec = amount % 60;
            int min = ((amount - sec) / 60) % 60;
            return string.Format("{0:D2}:{1:D2}", min, sec);
        }

        public void CalculateDuration()
        {
            this.lblDuration.Text = CalculateDuration(this._frames.Count);
        }

        public void UpdateControlPanel(int value)
        {
            this.colorSlider.Value = value;
            if (value % this._fps == 0)
            {
                int amount = value / this._fps;
                int sec = amount % 60;
                int min = ((amount - sec) / 60) % 60;
                this.lblCurrent.Text = string.Format("{0:D2}:{1:D2}", min, sec);
            }
        }

        public void StopControlPanel()
        {
            this.colorSlider.Value = 0;
            this.lblDuration.Text = this.lblCurrent.Text = "00:00";
            this.btnPlay.BackgroundImage = global::PreprocessImage.Properties.Resources.play;
        }

        public void Finish()
        {
            this.btnPlay.BackgroundImage = global::PreprocessImage.Properties.Resources.play;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (_frames != null && _frames.Count != 0 && PlayClickHandler != null)
            {
                _play = !_play;
                PlayClickHandler(sender, e);
                this.btnPlay.BackgroundImage = _play ? global::PreprocessImage.Properties.Resources.pause :
                    global::PreprocessImage.Properties.Resources.play;
                this.lblDuration.Text = CalculateDuration(this._frames.Count);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (StopClickHandler != null)
                StopClickHandler(sender, e);

        }

        private void btnRewind_Click(object sender, EventArgs e)
        {
            if (_framePlayer != null)
            {
                int value = _framePlayer.CurrentNumber - this._fps * 2;
                _framePlayer.CurrentNumber = value <= 0 ? 0 : value;
            }
        }

        private void btnForword_Click(object sender, EventArgs e)
        {
            if (_framePlayer != null)
            {
                int value = _framePlayer.CurrentNumber + this._fps * 2;
                _framePlayer.CurrentNumber = value >= this._frames.Count - 1 ? this._frames.Count - 1 : value;
            }
        }


        private void Slider_Scroll(object sender, ScrollEventArgs e)
        {
            var value = this.colorSlider.Value - 1;
            if (_framePlayer != null)
            {
                _framePlayer.CurrentNumber = value < 0 ? 0 : value;
            }
        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            _framePlayer = this.Parent as FramePlayer;

        }

        public void EnableSlider(bool enable)
        {
            this.colorSlider.Enabled = enable;
        }
    }
}
