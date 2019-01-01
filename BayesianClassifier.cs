using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facial_Gesture_Recognition
{
    class BayesianClassifier
    {
        public Matrix[] train_Features;
        Matrix[] Segma;
        Matrix[] Mean;
        Matrix[] SegmaInverse;
        Matrix[] test_Features;
        double[] determant;
        double[] final_Class;

        public int num_of_hits;

        int Size_test_features;
        int Size_train_features;
        public Matrix Confusion;
        public double Accuracy;

        public BayesianClassifier(Matrix[] _train_features, Matrix[] _test_features)
        {
            train_Features = _train_features;
            test_Features = _test_features;
            Segma = new Matrix[4];
            Mean = new Matrix[4];
            SegmaInverse = new Matrix[4];
            determant = new double[4];
            final_Class = new double[4];
            Confusion = new Matrix(4, 4);
            num_of_hits = 0;
            Size_test_features = _test_features.Count();
            Size_train_features = _train_features.Count() / 4;
            for (int i = 0; i < 4; i++)
            {
                Mean[i] = new Matrix(12, 1);
                Segma[i] = new Matrix(12, 12);
            }
        }

        public void Classify()
        {
            Train();
            //here to test 20 images .. 5 fo every class
            num_of_hits = 0;
            for (int i = 0; i < Size_test_features; i++)
            {
                int MaxIndex = P_of_X(test_Features[i]);
                int expected = i / 5;             //this value must be entered to see what the expected class

                Confusion[MaxIndex, expected]++;
                if (expected == MaxIndex)
                    num_of_hits++;
            }
            Accuracy = (num_of_hits * 100) / Size_test_features;
        }

        private void Set_Mean(int start, int end)
        {
            double[] SumFeature = new double[12];
            int Class_Index = start / Size_train_features;
            for (int i = start; i < end; ++i)
            {
                for (int j = 0; j < 12; j++)
                    SumFeature[j] += train_Features[i][j, 0];
            }
            for (int i = 0; i < 12; i++)
                Mean[Class_Index][i, 0] = SumFeature[i] / Size_train_features;
        }

        private void Set_Sigma(int start, int end)
        {
            int Class_Index = start / Size_train_features;
            for (int i = 0; i < 12; ++i)
                for (int j = 0; j < 12; ++j)
                    Segma[Class_Index][i, j] = Calculate_Cell(Class_Index, i, j, start, end);
        }

        private double Calculate_Cell(int Class_Index, int i, int j, int start, int end)
        {
            double Cell = 0;
            for (int k = start; k < end; ++k)
            {
                Cell += (train_Features[k][i, 0] - Mean[Class_Index][i, 0]) * (train_Features[k][j, 0] - Mean[Class_Index][j, 0]);
            }
            return Cell / 15;
        }

        private int P_of_X(Matrix X)
        {
            double sum = 0;
            for (int i = 0; i < 4; i++)
            {
                double x1 = Math.Pow(2 * Math.PI, 19 / 2) * Math.Pow(determant[i], 0.5);
                Matrix X_Sub_M = X - Mean[i];
                Matrix X_Sub_M_Trans = Matrix.Transpose(X_Sub_M);
                Matrix expMatx = -0.5 * X_Sub_M_Trans * SegmaInverse[i] * X_Sub_M;
                double exp = expMatx[0, 0];
                final_Class[i] = (1 / x1) * Math.Exp(exp);
                sum += final_Class[i];
            }
            final_Class[0] = (final_Class[0] * 0.25) / sum;
            final_Class[1] = (final_Class[1] * 0.25) / sum;
            final_Class[2] = (final_Class[2] * 0.25) / sum;
            final_Class[3] = (final_Class[3] * 0.25) / sum;

            double max = Math.Max(Math.Max(final_Class[0], final_Class[1]), Math.Max(final_Class[2], final_Class[3]));

            if (max == final_Class[0])
                return 0;
            else if (max == final_Class[1])
                return 1;
            else if (max == final_Class[2])
                return 2;
            else
                return 3;
        }

        public void Train()
        {
            for (int i = 0; i < 4; i++)
            {
                int start = i * Size_train_features;
                int end = start + Size_train_features;

                Set_Mean(start, end);
                Set_Sigma(start, end);
                SegmaInverse[i] = Segma[i].Invert();
                determant[i] = Segma[i].Det();
            }
        }

        public int test()
        {
            int MaxIndex = P_of_X(test_Features[0]);
            return MaxIndex;
        }

    }
}
