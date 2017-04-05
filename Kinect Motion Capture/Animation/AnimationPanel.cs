namespace AnimationTest
{
    using System;
    using System.Windows.Forms;
    using System.Diagnostics;
    public partial class AnimationPanel : UserControl
    {
        public KAnimation AnimationManager;
        private bool bManualChange;
 
        public AnimationPanel()
        {
            InitializeComponent();
            AnimationManager = new KAnimation();
            AnimationManager.FrameAmountChanged += new EventHandler(EVENT_FrameAmountChanged);
            AnimationManager.FrameCurrentChanged += new EventHandler(EVENT_FrameCurrentChanged);
            AnimationManager.FinishAnimation += new EventHandler(EVENT_FinishAnimation);
        }

        // Zdarzenia
        private void EVENT_ButtonRecord(object sender, EventArgs e)
        {
            if (AnimationManager != null) AnimationManager.Record();
        }
        private void EVENT_ButtonStop(object sender, EventArgs e)
        {
            if (AnimationManager != null)
            {
                if (AnimationManager.IsRecording)
                {
                    AnimNameLabel.Text = "Name: " + AnimationManager.AnimationName;
                    AnimationManager.IsAnimationLoaded = true;
                    TimelineBar.Maximum = AnimationManager.GetFrameCount();
                    EVENT_FrameAmountChanged(this, EventArgs.Empty);
                }

                AnimationManager.Stop();
                BPlay.Visible = true;
                BPause.Visible = false;
                TimelineBar.Value = 0;

                int FrameCount = AnimationManager.GetFrameCount();
                if (FrameCount > -1 && !TimelineBar.Enabled)
                {
                    TimelineBar.Enabled = true;
                    TimelineBar.Maximum = FrameCount;
                }
            }
        }
        private void EVENT_ButtonPause(object sender, EventArgs e)
        {
            if (AnimationManager != null) AnimationManager.Pause();
            if (!AnimationManager.IsPlaying)
            {
                BPlay.Visible = true;
                BPause.Visible = false;
            }
        }
        private void EVENT_ButtonPlay(object sender, EventArgs e)
        {
            if (AnimationManager != null) AnimationManager.Play();
            if (AnimationManager.IsPlaying)
            {
                BPlay.Visible = false;
                BPause.Visible = true;
            }
        }
        private void EVENT_ButtonLoop(object sender, EventArgs e)
        {
            if (AnimationManager != null) AnimationManager.IsLooping = LoopCheck.Checked;
        }

        private void EVENT_FinishAnimation(object sender, EventArgs e)
        {
            BPlay.Visible = true;
            BPause.Visible = false;
        }
        private void EVENT_FrameAmountChanged(object sender, EventArgs e)
        {
            int FrameAmaunt = AnimationManager.GetFrameCount();
            if (FrameAmaunt == -1) // Pusta
            {
                TimelineBar.Enabled = false;
                TimelineBar.Maximum = 0;
                TimelineBar.Value = 0;
            }
            else
            {
                if (AnimationManager.IsRecording)
                {
                    LActualFrame.Text = "Frame:" + FrameAmaunt.ToString();
                    LActualTime.Text = "Time:" + (FrameAmaunt * (1.0f / 30)).ToString("0.000") + " s";
                }
                if (!TimelineBar.Enabled)
                {
                    TimelineBar.Enabled = true;
                    TimelineBar.Maximum = FrameAmaunt;
                    LAnimName.Text = AnimationManager.AnimationName;
                }
            }
        }
        private void EVENT_FrameCurrentChanged(object sender, EventArgs e)
        {
            if(AnimationManager.IsPlaying) TimelineBar.Value = AnimationManager.CurrentFrame-1;
            KeyFrame ActualFrame = AnimationManager.GetActualFrame();
            LActualFrame.Text = "Frame:" + TimelineBar.Value + "/ " + AnimationManager.GetFrameCount();
            LActualTime.Text = "Time:" + ActualFrame.Time.ToString("0.000") + " s /" + AnimationManager.AnimationTotalTime.ToString("0.000") + " s"; ;
        }

        // Reakcja na reczna zmiane paska
        private void EVENT_MouseDown(object sender, MouseEventArgs e)
        {
           bManualChange = true;
        }
        private void EVENT_MouseMove(object sender, MouseEventArgs e)
        {
            if (bManualChange)
                AnimationManager.SetFrame(TimelineBar.Value);
        }
        private void EVENT_MouseUp(object sender, MouseEventArgs e)
        {
            bManualChange = false;
        }
        private void EVENT_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}
