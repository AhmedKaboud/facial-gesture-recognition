using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facial_Gesture_Recognition
{
    class CrossValidation
    {
        const int ITIMES = 3;
        const int K = 2;

        Tuple<Matrix, int>[] Test_Features;
        Tuple<Matrix, int>[] Train_Features;
        Tuple<Matrix, int>[] indexed_featured;
        public double performance_e;
        int K_KNN;
        int FoldSize;
        int desc;

        public CrossValidation(int _d, Tuple<Matrix, int>[] _Features, int _K)
        {
            indexed_featured = _Features;
            performance_e = 0;
            FoldSize = indexed_featured.Count() / K;        //divide them into 2 chunks
            Test_Features = new Tuple<Matrix, int>[FoldSize];
            Train_Features = new Tuple<Matrix, int>[FoldSize];
            desc = _d;
            K_KNN = _K;
            if (_K > FoldSize)
                K_KNN = FoldSize;
        }

        public void foldCrossValidation()
        {
            double Error;
            double sum_Error = 0;
            for (int i = 0; i < ITIMES; i++)
            {
                RandomizeFeatures();        //set test_features and train_features in random way
                double Wng_classified;
                double sum_Wng_classified = 0;
                for (int j = 0; j < K; j++)
                {
                    if (desc == 0)
                    {
                        KNNClassifier knn;
                        if (j == 0)
                            knn = new KNNClassifier(K_KNN, Train_Features, Test_Features);
                        else
                            knn = new KNNClassifier(K_KNN, Test_Features, Train_Features);
                        knn.Classify();
                        Wng_classified = FoldSize - knn.num_of_hits;
                    }
                    else
                    {
                        PNNClassifier pnn;
                        if (j == 0)
                            pnn = new PNNClassifier(Train_Features, Test_Features);
                        else
                            pnn = new PNNClassifier(Test_Features, Train_Features);
                        pnn.Classify();
                        Wng_classified = FoldSize - pnn.num_of_hits;
                    }
                    sum_Wng_classified += Wng_classified;
                }
                Error = sum_Wng_classified / indexed_featured.Count();
                sum_Error += Error;
            }
            performance_e = sum_Error / ITIMES;
        }

        public void RandomizeFeatures()
        {
            Tuple<Matrix, int>[] Random_Features;
            Random r = new Random();
            //random integers from 0 to 59 then => order the array according to these numbers
            Random_Features = indexed_featured.OrderBy(x => r.Next(0, 60)).ToArray();
            Array.Copy(Random_Features, 0, Train_Features, 0, 30);
            Array.Copy(Random_Features, 30, Test_Features, 0, 30);
        }

    }
}
