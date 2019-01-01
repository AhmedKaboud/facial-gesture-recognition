using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facial_Gesture_Recognition
{

    public struct PointD
    {
        public double X;
        public double Y;
    }
    //Contain the X Y of every PTS file
    public struct PTS_file
    {
        public PointD[] point;
        public int size;
        public PTS_file(int y)
        {
            point = new PointD[20];
            size = y;
        }
    }
    //Contain the all file of one Class
    public struct Files_Class
    {
        public PTS_file[] PTS_Files;
        public Files_Class(int size)
        {
            PTS_Files = new PTS_file[size];
            for (int i = 0; i < size; i++)
                PTS_Files[i] = new PTS_file(20);
        }
    }
    //Contain the 4 class files
    public struct XY_Data
    {
        public Files_Class[] TT_Data;
        public XY_Data(int Num_Files)
        {
            TT_Data = new Files_Class[4];
            for (int i = 0; i < 4; i++)
                TT_Data[i] = new Files_Class(Num_Files);
        }
    }

    class StructContainer
    {
    }
}
