using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WindowAPITutorial;

namespace Facial_Gesture_Recognition
{
    public partial class TestForm : Form
    {

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(String sClassName, String sAppName);
        private int _actionVal;
        string pts_name = "";

        public TestForm()
        {
            InitializeComponent();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            string Path = "";
            OpenFileDialog upload_file = new OpenFileDialog();
            upload_file.Filter = "Allfiles|*.pgm";
            if (upload_file.ShowDialog() == DialogResult.OK)
            {
                Path = upload_file.FileName;
            }
            txt_path.Text = Path;

            Bitmap B = PGMUtil.ToBitmap(Path);
            Pbox_Img.Image = (Image)B;

            string[] s = Path.Split('\\');
            string Image_name = s[s.Count() - 1];
            string[] s2 = Image_name.Split('.');
            string name = s2[0] + ".pts";
            name = name.ToLower();
            pts_name = "";
            pts_name = "";
            for (int i = 0; i < s.Count() - 1; i++)
            {
                if (i == 0)
                    pts_name += s[i];
                else
                    pts_name += '\\' + s[i];
            }
            pts_name += '\\' + name;
        }
        
        private void intialize_winAPP()
        {
            IntPtr thisWindow = FindWindow(null, "Windows Media Player");
            string _appName = "wmplayer";
            WindowsFunctionFactory _factory = new WindowsFunctionFactory();
            WindowsFunction function = _factory.CreateFunction(thisWindow, _actionVal, _appName);
            function.Execute();
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            Matrix[] Training_Features = readData("Training Dataset/", 15);
            Matrix[] Testing_Feature = readOneData(pts_name);
            if (rb_Bays.Checked == true)
            {
                BayesianClassifier BC = new BayesianClassifier(Training_Features, Testing_Feature);
                BC.Train();
                int Dec = BC.test();
                takeDecision(Dec);
            }
            else if (rb_knn.Checked == true)
            {
                int K = 1; // Get Most Accuracy = 45%
                Tuple<Matrix, int>[] Train_KNN = setIndexedFeatures(Training_Features);
                Tuple<Matrix, int>[] Test_KNN = new Tuple<Matrix, int>[1];
                Test_KNN[0] = new Tuple<Matrix, int>(Testing_Feature[0], 0); // Don't care about int
                KNNClassifier knn = new KNNClassifier(K, Train_KNN, Test_KNN);
                int Dec = knn.test();
                takeDecision(Dec);
            }
            else if (rb_PW.Checked == true)
            {
                int H = 38; // Get Most Accuracy = 45%
                ParzenWindowClassifier PW = new ParzenWindowClassifier(H, Training_Features, Testing_Feature);
                int Dec = PW.Test();
                takeDecision(Dec);
            }
            else if (rb_pnn.Checked == true)
            {
                Tuple<Matrix, int>[] Train_PNN = setIndexedFeatures(Training_Features);
                Tuple<Matrix, int>[] Test_PNN = new Tuple<Matrix, int>[1];
                Test_PNN[0] = new Tuple<Matrix, int>(Testing_Feature[0], 0); // Don't care about int
                PNNClassifier pnn = new PNNClassifier(Train_PNN, Test_PNN);
                pnn.Train();
                int Dec = pnn.test();
                takeDecision(Dec);
            }
            intialize_winAPP();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private Tuple<Matrix, int>[] setIndexedFeatures(Matrix[] All_Features)
        {
            int size = All_Features.Count();
            Tuple<Matrix, int>[] indexed_features = new Tuple<Matrix, int>[size];
            int classSize = size / 4;
            for (int i = 0; i < size; i++)
            {
                indexed_features[i] = new Tuple<Matrix, int>(All_Features[i], i / classSize);
            }
            return indexed_features;
        }

        private Matrix[] readData(string path, int size)
        {
            string targetDirectory = path;
            ReadFile rf = new ReadFile(targetDirectory, size);
            XY_Data Data = rf.Set_Data();
            FeatureExtraction FEx = new FeatureExtraction(Data, size * 4);
            Matrix[] ExtractedFeatures = FEx.GetFeatures();
            return ExtractedFeatures;
        }

        private Matrix[] readOneData(string path)
        {
            string targetDirectory = path;
            ReadFile rf = new ReadFile(targetDirectory);
            PTS_file Data = rf.readOneFile();
            FeatureExtraction FEx = new FeatureExtraction(Data);
            Matrix[] Extracted_Feature = FEx.GetOneFeature();
            return Extracted_Feature;
        }
       
        private enum actionVal
        {
            RESTORE = 1,
            OPEN = 2,
            CLOSE = 3,
            MIN = 6,
        }
        
        private void takeDecision(int Dec)
        {
            if (Dec == 0)
            {
                _actionVal = (int)actionVal.CLOSE;
                MessageBox.Show("Now Close Dialog");
            }
            else if (Dec == 1)
            {
                _actionVal = (int)actionVal.MIN;
                MessageBox.Show("Now Minimize Dialog");
            }
            else if (Dec == 2)
            {
                _actionVal = (int)actionVal.OPEN;
                MessageBox.Show("Now Open Dialog");
            }
            else
            {
                _actionVal = (int)actionVal.RESTORE;
                MessageBox.Show("Now Restore Dialog");
            }
        }

    }
}
