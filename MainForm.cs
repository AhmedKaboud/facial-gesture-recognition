using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facial_Gesture_Recognition
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestForm tst = new TestForm();
            tst.Show();

            //this.Hide();
        }

        private void BtnAccuracy_Click(object sender, EventArgs e)
        {
            AccuracyForm Acc = new AccuracyForm();
            Acc.Show();

            //this.Hide();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Training for Classifier
            //string targetDirectory = "Training Dataset/";
            //ReadFile rf = new ReadFile(targetDirectory, 15);
            //XY_Data training_Data = rf.Set_Data();
            //FeatureExtraction FEx = new FeatureExtraction(training_Data);
            //Matrix[] ExtractedFeatures = FEx.GetFeatures();

        }
    }
}
