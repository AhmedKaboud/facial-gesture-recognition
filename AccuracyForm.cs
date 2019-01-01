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
    public partial class AccuracyForm : Form
    {
        public AccuracyForm()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////       Read Data       ////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////
            Matrix[] Training_Features = readData("Training Dataset/", 15);
            Matrix[] Testing_Features = readData("Testing Dataset/", 5);


            ////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////       Start Classifier       ////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////
            //use Bayesian Classifier to clculate accuracy and confusion
            BayesianClassifier BayesClass = new BayesianClassifier(Training_Features, Testing_Features);
            BayesClass.Classify();

            //here Code for Parzen Window to clculate accuracy and confusion
            int H = int.Parse(txt_h.Text.ToString());
            ParzenWindowClassifier PW = new ParzenWindowClassifier(H, Training_Features, Testing_Features);
            PW.Classify();

            //here Code for KNN to calculate accuracy and confusion
            int K = int.Parse(txt_K.Text.ToString());
            Tuple<Matrix, int>[] Train_NN = setIndexedFeatures(Training_Features);
            Tuple<Matrix, int>[] Test_NN = setIndexedFeatures(Testing_Features);
            KNNClassifier knn = new KNNClassifier(K, Train_NN, Test_NN);
            knn.Classify();
            CrossValidation cv = new CrossValidation(0, Train_NN, K);
            cv.foldCrossValidation();

            //here Code for PNN to calculate accuracy and confusion

            PNNClassifier pnn = new PNNClassifier(Train_NN, Test_NN);
            pnn.Classify();
            CrossValidation cv2 = new CrossValidation(1, Train_NN, K);
            cv2.foldCrossValidation();

            ////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////       Show Data       ////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////

            //Show the data of Bayesian
            showConfusion(DGVBaseyian, BayesClass.Confusion);
            txt_BaysAcc.Text = BayesClass.Accuracy.ToString();

            //Show the data of Parzen
            showConfusion(DGVParzen, PW.Confusion);
            txt_ParzenAcc.Text = PW.Accuracy.ToString();
            //txt_ParzenCross.Text = cv.performance_e.ToString();

            //Show the data of K-NN
            showConfusion(DGVKNN, knn.Confusion);
            txt_KnnACC.Text = knn.Accuracy.ToString();
            txt_KNNCross.Text = (cv.performance_e * 100).ToString();

            //Show the data of PNN
            showConfusion(DGVPNN, pnn.Confusion);
            txt_PNNAcc.Text = pnn.Accuracy.ToString();
            txt_PNNCross.Text = (cv2.performance_e * 100).ToString();
        }

        private void AccuracyForm_Load(object sender, EventArgs e)
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

        private void showConfusion(DataGridView DGV, Matrix matx)
        {
            if (DGV.Rows.Count != 5)
            {
                DGV.Rows.Add();
                DGV.Rows.Add();
                DGV.Rows.Add();
                DGV.Rows.Add();
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    DGV.Rows[i].Cells[j].Value = matx[i, j].ToString();
                }
            }
        }

    }
}
