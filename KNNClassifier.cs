using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facial_Gesture_Recognition
{
    class KNNClassifier
    {
        Tuple<Matrix, int>[] train_Features;
        Tuple<Matrix, int>[] test_Features;
        double[] final_Class;
        List<Tuple<double, int>> Distances;

        int K;
        public int num_of_hits;

        int Size_test_features;
        int Size_train_features;
        public Matrix Confusion;
        public double Accuracy;

        public KNNClassifier(int _K, Tuple<Matrix, int>[] _train_features, Tuple<Matrix, int>[] _test_features)
        {
            train_Features = _train_features;
            test_Features = _test_features;
            Size_test_features = test_Features.Count();
            Size_train_features = train_Features.Count();
            final_Class = new double[4];
            Confusion = new Matrix(4, 4);
            num_of_hits = 0;
            K = _K;
        }

        public void Classify()
        {
            if (K > Size_train_features)
                throw new MException("K input must less than Train Data Size!"); ;
            for (int i = 0; i < Size_test_features; i++)
            {
                Distances = getEqlidian(test_Features[i]);
                Distances.Sort();
                Array.Clear(final_Class, 0, 4);
                for (int j = 0; j < K; j++)
                {
                    int ClassNum = Distances[j].Item2;
                    final_Class[ClassNum]++;
                }

                double max = final_Class.Max();
                int MaxIndex = Array.IndexOf(final_Class, max);
                int expected = test_Features[i].Item2;
                Confusion[MaxIndex, expected]++;
                if (expected == MaxIndex)
                    num_of_hits++;
            }
            Accuracy = (num_of_hits * 100) / Size_test_features;
        }

        public int test()
        {
            Distances = getEqlidian(test_Features[0]);
            Distances.Sort();
            Array.Clear(final_Class, 0, 4);
            for (int j = 0; j < K; j++)
            {
                int ClassNum = Distances[j].Item2;
                final_Class[ClassNum]++;
            }

            double max = final_Class.Max();
            int MaxIndex = Array.IndexOf(final_Class, max);
            return MaxIndex;
        }

        private List<Tuple<double, int>> getEqlidian(Tuple<Matrix, int> test_feature)
        {
            double dis;
            List<Tuple<double, int>> Final_list = new List<Tuple<double, int>>();
            for (int i = 0; i < Size_train_features; i++)
            {
                dis = EqlidianDistance(test_feature.Item1, train_Features[i].Item1);
                Final_list.Add(new Tuple<double, int>(dis, train_Features[i].Item2));
            }
            return Final_list;

        }

        private double EqlidianDistance(Matrix X, Matrix Xi)
        {
            double sum = 0;
            for (int i = 0; i < 12; i++)
                sum += Math.Pow(X[i, 0] - Xi[i, 0], 2);
            return Math.Sqrt(sum);
        }

    }
}
