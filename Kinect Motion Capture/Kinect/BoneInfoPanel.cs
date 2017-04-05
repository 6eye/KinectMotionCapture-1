namespace AnimationTest
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Microsoft.Xna.Framework;

    public partial class BoneInfoPanel : UserControl
    {
        public List<KJointType> BoneConnections;
        private List<TreeNode> all_nodes;
        private VBone[] bones;
        private int SelectedBone;

        public BoneInfoPanel()
        {
            InitializeComponent();

            all_nodes = new List<TreeNode>();
            BoneConnections = new List<KJointType>();

            SelectedBone = -1;
            JointRotation.DataSource = Enum.GetValues(typeof(KJointType));
            JointRotation.SelectedItem = KJointType.None;
        }

        private void AddNode(string Name, int Parent)
        {
            TreeNode node;
            Name = Name.Trim();
            if (Parent == -1)   // ROOT
            {
                node = new TreeNode(Name);
                all_nodes.Add(node);
                BoneTree.Nodes.Add(node);
                return;
            }
            else
            {
                if (Parent < all_nodes.Count)
                {
                    node = new TreeNode(Name);
                    all_nodes[Parent].Nodes.Add(node);
                    all_nodes.Add(node);
                }
            }
        }
        private void ClearList()
        {
            all_nodes.Clear();
            BoneTree.Nodes.Clear();
        }
        public void SetData(VBone[] b)
        {
            ClearList();
            bones = b;
            foreach (VBone bone in bones)
            {
                AddNode(bone.Name, bone.ParentIndex);
                BoneConnections.Add(KJointType.None);
            }
            BoneTree.ExpandAll();
        }

        public void Update(VBone[] b)
        { 
            bones = b;
            if (SelectedBone != -1)
                UpdateDescription();
        }
        private void UpdateDescription()
        {
            if (SelectedBone != -1)
            {
                Vector3 p = bones[SelectedBone].BonePos.Position;
                Vector3 rot = KMath.GetAngleFromQuaternion(bones[SelectedBone].BonePos.Orientation);
                // Opis
                LOffset.Text = "Offset:     X = " + p.X.ToString("0.000") + " Y = " + p.Y.ToString("0.000") + " Z = " + p.Z.ToString("0.000");
                LRotation.Text = "Rotation: Y = " + rot.X.ToString("0.000") + "° P = " + rot.Y.ToString("0.000") + "° R = " + rot.Z.ToString("0.000") + "°";
                LRoot.Text = (bones[SelectedBone].ParentIndex == -1) ? "Root Bone: Yes" : "Root Bone: No";
                LJoint.Text = "Kinect Joint: " + BoneConnections[SelectedBone].ToString();
            }
        }

        // Zdarzenia
        private void EVENT_OnClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectedBone = -1;
            for (int i = 0; i < bones.Length; i++)
            {
                if (bones[i].Name.Trim() == e.Node.Text)
                    SelectedBone = i;
            }
            if (SelectedBone != -1)
                UpdateDescription();
        }
        private void EVENT_JointValueChanged(object sender, EventArgs e)
        {
            if (SelectedBone != -1)
            {
                BoneConnections[SelectedBone] = (JointRotation.SelectedIndex == 20) ? KJointType.None : (KJointType)JointRotation.SelectedIndex;
                LJoint.Text = "Kinect Joint: " + BoneConnections[SelectedBone].ToString();
            }
        }
    }
}
