using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facial_Gesture_Recognition
{
    class FeatureExtraction
    {
        Matrix[] train_Features;
        PTS_file pts_test_file;
        XY_Data train_data;

        public FeatureExtraction(XY_Data Data, int _size)
        {
            train_data = Data;
            train_Features = new Matrix[_size];
            for (int i = 0; i < _size; i++)
                train_Features[i] = new Matrix(12, 1);
        }

        public FeatureExtraction(PTS_file Data)
        {
            pts_test_file = Data;
            train_Features = new Matrix[1];
            train_Features[0] = new Matrix(12, 1);
        }

        public Matrix[] GetFeatures()
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                int size = train_data.TT_Data[0].PTS_Files.Count();         //for training data it will = 15
                for (int j = 0; j < size; j++)
                {
                    train_Features[count++] = Eqlidean(train_data.TT_Data[i].PTS_Files[j]);
                }
            }
            return train_Features;
        }

        public Matrix[] GetOneFeature()
        {
            Matrix[] ret = new Matrix[1];
            ret[0] = Eqlidean(pts_test_file);
            return ret;
        }

        private Matrix Eqlidean(PTS_file next_file)
        {
            PTS_file CurFile = next_file;
            Matrix curFeature = new Matrix(12, 1);
            int count = 0;
            double X = CurFile.point[14].X;
            double Y = CurFile.point[14].Y;
            for (int i = 0; i < 20; i++)
            {
                double Xi = CurFile.point[i].X;
                double Yi = CurFile.point[i].Y;
                if (i == 0 || i == 7 || i == 9 || i == 11 || i == 12 || i == 14 || i == 15 || i == 16)
                    continue;
                curFeature[count++, 0] = Math.Sqrt(Math.Pow(Xi - X, 2) + Math.Pow(Yi - Y, 2));
            }
            return curFeature;
        }
    }
}
