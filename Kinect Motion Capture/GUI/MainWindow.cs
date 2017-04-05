using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Kinect;

namespace AnimationTest
{
    public partial class Window : Form
    {
        // Glowne klasy
        private KAnimation AnimationManager;
        private KKinect    SensorManager;

        // FPS
        private float Timer_TotalTime;
        private float Timer_RecordTime;
        private int   Timer_FPSCount;
        
        // Szkielet
        private KModel model;
        private int   prevFrame;
        private bool  RootBoneScaleSet;
        private float RootBoneScale;
        private float DistanceFromSensor;

        public Window()
        {
            InitializeComponent();
            KTimer.SetupTimer();
            AnimationManager = AnimPanel.AnimationManager;
            SensorManager = KinectPanel.Sensor;
            SensorManager.StatusChanged += new EventHandler(EVENT_Kinect_StatusChanged);
            SensorManager.TrackingChanged += new EventHandler(EVENT_Kinect_TrackingChanged);
            LKinectStatus.Text = KKinectHelper.GetDeviceStatusDesc(SensorManager.Status);
        }

        void DoUpdate()
        {
            float time = KTimer.GetElapsedTime();

            // Licznik FPS
            Timer_TotalTime += time;
            Timer_FPSCount++;
            if (Timer_TotalTime > 1.0f)
            {
                RenderingPanel.SetFPS(Timer_FPSCount);
                Timer_TotalTime -= 1.0f;
                Timer_FPSCount = 0;
            }

            if (model != null && AnimationManager != null)
            {
                if (AnimationManager.IsAnimationLoaded)
                {
                    if (AnimationManager.IsPlaying)
                        AnimationManager.Update(time);

                    if (prevFrame != AnimationManager.CurrentFrame || AnimationManager.IsPlaying)
                    {
                        KeyFrame frame = AnimationManager.GetActualFrame();
                        model.UpdateTransform(frame.Bones);
                        BonePanel.Update(frame.Bones);
                        prevFrame = AnimationManager.CurrentFrame;
                    }
                }
                else
                {
                    if (SensorManager != null)
                    {
                        if (SensorManager.IsRunning())
                        {
                            // Szkielet
                            VBone[] bones = KMeshHelper.CopyBones(model.GetBones());
                            Skeleton skel = SensorManager.GetSkeletonFrame();

                            if (skel != null && model != null)
                            {
                                KJointType[] JointList = BonePanel.BoneConnections.ToArray();

                                for (int i = 0; i < bones.Length; i++)
                                {
                                    if (JointList[i] != KJointType.None)
                                    {
                                        JointType ktype = (JointType)JointList[i];
                                        if (skel.Joints[ktype].TrackingState == JointTrackingState.Tracked)
                                        {
                                            Quaternion rotation = KKinectHelper.RecalculateKinectJointOrientation(ktype, skel);

                                            if (bones[i].ParentIndex == -1) // Gdy kość root
                                            {
                                                rotation.W *= -1;
                                                if (!RootBoneScaleSet)
                                                {
                                                    RootBoneScale = bones[i].BonePos.Position.Z / skel.Joints[ktype].Position.Y; // KINECT.Y == XNA.Z
                                                    DistanceFromSensor = skel.Joints[ktype].Position.Z;
                                                    RootBoneScaleSet = true;
                                                }
                                                bones[i].BonePos.Position.X = skel.Joints[ktype].Position.X * RootBoneScale;
                                                bones[i].BonePos.Position.Y = (skel.Joints[ktype].Position.Z - DistanceFromSensor) * RootBoneScale;
                                                bones[i].BonePos.Position.Z = skel.Joints[ktype].Position.Y * RootBoneScale;
                                            }

                                            bones[i].BonePos.Orientation = rotation;
                                        }
                                    }
                                }
                                model.UpdateTransform(bones);
                                BonePanel.Update(bones);
                            }

                            if (AnimationManager.IsRecording)
                            {
                                Timer_RecordTime += time;
                                if (Timer_RecordTime > AnimationManager.StepTime)
                                {
                                    KeyFrame key = new KeyFrame();
                                    key.Time = AnimationManager.StepTime * (AnimationManager.GetFrameCount() + 1);
                                    key.Bones = bones;
                                    AnimationManager.AddKeyFrame(key);
                                    Timer_RecordTime -= AnimationManager.StepTime;
                                }
                            }
                        }
                    }
                }
            }
        }

        // Funkcje od Okna
        protected override void OnCreateControl()
        {
            Application.Idle += new EventHandler(OnIdle);
            base.OnCreateControl();
        }
        void OnIdle(object sender, EventArgs e)
        {
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            DoUpdate();
            KinectPanel.Draw();
            RenderingPanel.Draw();
        }

        // Przyciski górnego menu
        private void EVENT_ButtonLoadPSA(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PSA Animation File|*.psa";
            openFile.Title = "Select a Animation File";
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (model == null) return;
                AnimationManager.AnimationLoad(openFile.FileName);
                KeyFrame frame = AnimationManager.GetActualFrame();
                model.UpdateTransform(frame.Bones);
                BonePanel.Update(frame.Bones);
            }
        }
        private void EVENT_ButtonSavePSA(object sender, EventArgs e)
        {
            if (model != null)
            {
                Debug.WriteLine("Framecount " + AnimationManager.GetFrameCount());
                if (AnimationManager.GetFrameCount() == -1)
                {
                    MessageBox.Show("No animation to save !", "Save file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.Filter = "Animation File PSA|*.psa";
                    saveFile.Title = "Select animation to save";
                    if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        AnimationManager.AnimationSave(saveFile.FileName, model.GetBones());
                }
            }
        }
        private void EVENT_ButtonLoadPSK(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PSK File|*.psk";
            openFile.Title = "Select a Skeletal Mesh File";
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                model = KFile.LoadPSK(RenderingPanel.Renderer.device, openFile.FileName);
                RenderingPanel.SetMesh(model);
                if (model != null)
                {
                    BonePanel.SetData(model.GetBones());
                    menu_animload.Enabled = true;
                    menu_animsave.Enabled = true;
                    menu_modelmaterial.Enabled = true;
                    AnimPanel.Enabled = true;
                }
            }
        }
        private void EVENT_ButtonSetMaterial(object sender, EventArgs e)
        {
            if (model != null)
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Texture File|*.png";
                openFile.Title = "Select a Texture File";
                if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Texture2D texture = KFile.LoadTexture(RenderingPanel.Renderer.device, openFile.FileName);
                    if (texture != null) model.SetMaterial(texture);
                }
            }
        }

        // Dolny pasek statusu
        private void EVENT_Kinect_StatusChanged(object sender, EventArgs e)
        {
            LKinectStatus.Text = KKinectHelper.GetDeviceStatusDesc(SensorManager.Status);
        }
        private void EVENT_Kinect_TrackingChanged(object sender, EventArgs e)
        {
            if (SensorManager != null)
                LKinectTracking.Text = (SensorManager.IsTracking) ? "Detected" : "Not detected";
        }
    }
}
