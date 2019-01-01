using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facial_Gesture_Recognition
{
    class ParzenWindowClassifier
    {
        public double[] Final_Posterior;
        public Matrix[] test_features;
        public Matrix[] train_features;
        public Matrix Confusion;
        public int num_of_hits;

        int H;
        //#samples for training
        //set with the training data size
        const int NumOfSampeles = 15;
        const int NumofClasses = 4;
        int Size_test_features;
        int Size_train_features;
        public double Accuracy;

        public ParzenWindowClassifier(int _h, Matrix[] _train_features, Matrix[] _test_features)
        {
            H = _h;
            test_features = _test_features;
            train_features = _train_features;
            Size_test_features = test_features.Count();
            Size_train_features = train_features.Count();
            num_of_hits = 0;
            Final_Posterior = new double[NumofClasses];
            Confusion = new Matrix(NumofClasses, NumofClasses);
        }

        public void Classify()
        {
            num_of_hits = 0;

            for (int i = 0; i < Size_test_features; i++)
            {
                Get_Posterior(test_features[i]);

                int MaxIndex;
                double max = Math.Max(Math.Max(Final_Posterior[0], Final_Posterior[1]), Math.Max(Final_Posterior[2], Final_Posterior[3]));

                if (max == Final_Posterior[0])
                    MaxIndex = 0;
                else if (max == Final_Posterior[1])
                    MaxIndex = 1;
                else if (max == Final_Posterior[2])
                    MaxIndex = 2;
                else
                    MaxIndex = 3;

                int expected = i / 5;

                Confusion[MaxIndex, expected]++;
                if (expected == MaxIndex)
                    num_of_hits++;
            }
            Accuracy = (num_of_hits * 100) / Size_test_features;
        }

        public int Test()
        {
            Get_Posterior(test_features[0]);

            int MaxIndex;
            double max = Math.Max(Math.Max(Final_Posterior[0], Final_Posterior[1]), Math.Max(Final_Posterior[2], Final_Posterior[3]));
            if (max == Final_Posterior[0])
                MaxIndex = 0;
            else if (max == Final_Posterior[1])
                MaxIndex = 1;
            else if (max == Final_Posterior[2])
                MaxIndex = 2;
            else
                MaxIndex = 3;

            return MaxIndex;
        }
        public void Get_Posterior(Matrix X)
        {
            double[] Sum = new double[NumofClasses];
            for (int i = 0; i < Size_train_features; i++)
            {
                Sum[i / NumOfSampeles] += get_Phay(X, train_features[i]);
            }
            double V = Math.Pow(H, 12);

            double[] P = new double[NumofClasses];
            double sum_P = 0;
            for (int i = 0; i < NumofClasses; i++)
            {
                P[i] = (Sum[i] / Size_train_features) / V;
                sum_P += P[i] / NumofClasses;
            }

            for (int i = 0; i < NumofClasses; i++)
            {
                Final_Posterior[i] = (P[i] / NumofClasses) / sum_P;
            }
        }

        private double get_Phay(Matrix X, Matrix Xi)
        {
            double sum = 0;
            for (int i = 0; i < 12; i++)
                sum += Math.Pow(X[i, 0] - Xi[i, 0], 2);

            double Di = Math.Sqrt(sum);
            if (Di / H <= 0.5)
                return 1;
            else
                return 0;
        }

    }
}
