namespace AnimationTest
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using System.Diagnostics;

    public class KAnimation
    {
        public string AnimationName;
        public float StepTime;

        public bool      IsPlaying;
        public bool      IsRecording;
        public bool      IsAnimationLoaded;
        public bool      IsLooping;
        
        
        public float     AnimationTotalTime;
        public int       CurrentFrame;
        private float    CurrentTime;

        private KeyFrame ActualFrame;
        private List<KeyFrame> keys;
        
        public KAnimation()
        {
            keys = new List<KeyFrame>();
            IsPlaying = false;
            CurrentFrame = 0;
            CurrentTime = 0;
            StepTime = 1.0f / 30;
        }

        // Ładowanie/Zapisywanie animacji
        public void AnimationLoad(string filename)
        {
            ClearAllFrames();
            KAnimInfo info = KFile.LoadPSA(filename);
            AnimationName = info.Name;
            keys = info.Frames;
            if (keys.Count > 0)
            {
                AnimationTotalTime = (keys.Count - 1) * StepTime;
                ActualFrame = keys[0];
                if (FrameAmountChanged != null)
                    FrameAmountChanged(this, EventArgs.Empty);
                IsAnimationLoaded = true;
            }
        }
        public void AnimationSave(string filename, VBone[] BindBones)
        {
            if (keys.Count > 0 && BindBones.Length > 0)
                KFile.SavePSA(filename, AnimationName, BindBones, keys.ToArray());
        }
        public void AnimationCreate(string animName)
        {
            AnimationName = animName;
            CurrentTime = 0.0f;
            CurrentFrame = 0;
            ClearAllFrames();
            IsPlaying = false;
            IsRecording = true;
            IsAnimationLoaded = false;
        }

        private KeyFrame FrameLerp(KeyFrame k1, KeyFrame k2, float Lerp)
        {
            KeyFrame frame = new KeyFrame();

            frame.Bones = new VBone[k1.Bones.Length];
            frame.Time = k1.Time;
            for (int i = 0; i < frame.Bones.Length; i++)
            {
                frame.Bones[i].ParentIndex = k1.Bones[i].ParentIndex;
                frame.Bones[i].BonePos.Orientation = Quaternion.Slerp(k1.Bones[i].BonePos.Orientation, k2.Bones[i].BonePos.Orientation, Lerp);
                frame.Bones[i].BonePos.Position = Vector3.Lerp(k1.Bones[i].BonePos.Position, k2.Bones[i].BonePos.Position, Lerp);
                frame.Bones[i].Name = k1.Bones[i].Name;
            }
            return frame;
        }
        public  void     Update(float DeltaTime)
        {
            int prevFrame = 0;
            if (IsPlaying)
            {
                CurrentTime += DeltaTime;
                prevFrame = CurrentFrame;
                CurrentFrame = (int)(CurrentTime / StepTime);

                if (prevFrame != CurrentFrame)
                {
                    if (FrameCurrentChanged != null)
                        FrameCurrentChanged(this, EventArgs.Empty);
                }

                if (CurrentFrame > (keys.Count - 1))
                {
                    if (IsLooping)
                    {
                        CurrentTime = 0;
                        CurrentFrame = 0;
                    }
                    else
                    {
                        Stop();
                        return;
                    }
                }
                if (CurrentFrame != (keys.Count - 1))
                {
                    float FrameLerpValue = (CurrentTime / StepTime) - CurrentFrame;
                    ActualFrame = FrameLerp(keys[CurrentFrame], keys[CurrentFrame + 1], FrameLerpValue);
                }
            }
        }

        public void     AddKeyFrame(KeyFrame frame)
        {
            keys.Add(frame);
            AnimationTotalTime = (keys.Count - 1) * StepTime;
            Debug.WriteLine("Key " + keys.Count);
            if (FrameAmountChanged != null)
                FrameAmountChanged(this, EventArgs.Empty);
        }
        public void     ClearAllFrames()
        {
            CurrentTime = 0.0f;
            CurrentFrame = 0;
            keys.Clear();
            AnimationTotalTime = 0;
            if (FrameAmountChanged != null)
                FrameAmountChanged(this, EventArgs.Empty);
        }
        public int      GetFrameCount()
        {
            return keys.Count - 1;
        }
        public void     SetFrame(int frame)
        {
            ActualFrame = keys[frame];
            CurrentTime = ActualFrame.Time;
            CurrentFrame = (int)(CurrentTime / StepTime);
            if (FrameCurrentChanged != null)
                FrameCurrentChanged(this, EventArgs.Empty);
        }
        public KeyFrame GetActualFrame()
        {
            return ActualFrame;
        }
    
        // Odtwarzanie
        public void Record()
        {
            if (!IsRecording)
            {
                AnimNameWindow window = new AnimNameWindow();
                if (window.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    AnimationCreate(window.AnimationName);
            }
        }
        public void Play()
        {
            if (keys.Count > 0) IsPlaying = true;
        }
        public void Pause()
        {
            if (keys.Count > 0) IsPlaying = false;
        }
        public void Stop()
        {
            IsPlaying = false;
            IsRecording = false;
            CurrentTime = 0.0f;
            CurrentFrame = 0;
            if (FinishAnimation != null)
                FinishAnimation(this, EventArgs.Empty);
        }

        public event EventHandler FrameAmountChanged;   // Zmiana ilosci klatek
        public event EventHandler FrameCurrentChanged;  // Zmiana aktualnej klatki
        public event EventHandler FinishAnimation;      // Wywolane w momencie zakonczenia odtwarzania animacji
    }
}
