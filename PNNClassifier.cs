using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facial_Gesture_Recognition
{
    class PNNClassifier
    {
        Tuple<Matrix, int>[] TrainData;
        Tuple<Matrix, int>[] TestData;
        int num_test_Samples;
        int num_train_Samples;
        double[,] Samples_weight;
        double[] netK;
        double[] Final_Posterior;
        double V;
        public Matrix Confusion;
        public double Accuracy;
        public int num_of_hits;

        public PNNClassifier(Tuple<Matrix, int>[] Training_data, Tuple<Matrix, int>[] Testing_data)
        {
            TrainData = Training_data;
            TestData = Testing_data;
            num_train_Samples = TrainData.Count();
            num_test_Samples = TestData.Count();
            Samples_weight = new double[num_train_Samples, 12];
            netK = new double[num_train_Samples];
            Final_Posterior = new double[4];
            V = Math.Pow(2, 12);
            Confusion = new Matrix(4, 4);
            num_of_hits = 0;
        }

        public void Classify()
        {
            Train();

            for (int i = 0; i < num_test_Samples; i++)
            {
                Matrix TestMatx = normalize(TestData[i].Item1);
                Set_Posterior(TestMatx);

                double max = Final_Posterior.Max();
                int MaxIndex = Array.IndexOf(Final_Posterior, max);
                int expected = TestData[i].Item2;
                Confusion[MaxIndex, expected]++;
                if (expected == MaxIndex)
                    num_of_hits++;
            }
            Accuracy = (num_of_hits * 100) / num_test_Samples;

        }

        private void Set_Posterior(Matrix TestMatx)
        {
            double[] Ki = new double[4];
            for (int j = 0; j < num_train_Samples; j++)
            {
                double netKj = 0;
                for (int k = 0; k < 12; k++)
                {
                    netKj += Samples_weight[j, k] * TestMatx[k, 0];
                }
                Ki[TrainData[j].Item2] += Math.Pow(Math.E, (netKj - 1));
            }
            ////////////////////////////////////////////////////////////////////////////////

            double[] P = new double[4];
            double sum_P = 0;
            for (int j = 0; j < 4; j++)
            {
                P[j] = (Ki[j] / num_train_Samples) / V;         //P(x|wi) = ki/(n*v)
                sum_P += P[j] * 0.25;                           //P(x) = P(x|w1) P(w1) + P(x|w2) P(w2) + .....
            }
            for (int j = 0; j < 4; j++)
            {
                Final_Posterior[j] = (P[j] * 0.25) / sum_P;     //P(wi|x) = P(x|wi) P(wi)/P(x)
            }
        }

        public int test()
        {
            Matrix TestMatx = normalize(TestData[0].Item1);
            Set_Posterior(TestMatx);

            double max = Final_Posterior.Max();
            int MaxIndex = Array.IndexOf(Final_Posterior, max);
            return MaxIndex;
        }

        public void Train()
        {
            for (int i = 0; i < num_train_Samples; i++)
            {
                Matrix m = TrainData[i].Item1;
                Matrix Norm = normalize(m);
                //Set wights for Samples
                for (int j = 0; j < 12; j++)
                {
                    Samples_weight[i, j] = Norm[j, 0];
                }
            }
        }

        Matrix normalize(Matrix Input)
        {
            Matrix returned = Input;
            double sum = 0;
            for (int j = 0; j < 12; j++)
            {
                sum += Math.Pow(Input[j, 0], 2);
            }
            double Norm = Math.Sqrt(sum);
            for (int j = 0; j < 12; j++)
            {
                returned[j, 0] = Input[j, 0] / Norm;
            }
            return returned;
        }

    }
}
