using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Facial_Gesture_Recognition
{
    class ReadFile
    {
        private List<string> All_File_paths;
        private XY_Data Data;
        public string Path;
        private int num_files;

        //constructor get the path of DataSets for training & number of PTS files in every Folder
        public ReadFile(string _Path, int _NumFiles)
        {
            All_File_paths = new List<string>();
            Path = _Path;
            num_files = _NumFiles;
            Data = new XY_Data(_NumFiles);
        }

        public ReadFile(string _path)
        {
            Path = _path;
        }

        //Read all files and return the data of all files Class
        public XY_Data Set_Data()
        {
            ProcessDirectory(Path);

            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < num_files; j++)
                {
                    FileStream fsread = new FileStream(All_File_paths[count++], FileMode.Open);
                    StreamReader sr = new StreamReader(fsread);
                    sr.ReadLine();      //read version 
                    sr.ReadLine();      //n_points
                    sr.ReadLine();      //{
                    int Point_num = 0;
                    while (sr.Peek() > -1)
                    {
                        string line = sr.ReadLine();
                        if (line == "}")
                            continue;
                        string[] num = line.Split(' ');
                        Data.TT_Data[i].PTS_Files[j].point[Point_num].X = double.Parse(num[0]);
                        Data.TT_Data[i].PTS_Files[j].point[Point_num].Y = double.Parse(num[1]);
                        Point_num++;
                    }
                    sr.Close();
                }
            }
            return Data;
        }

        //Open all files in the DataSet Folder .. and set the all file pathes
        public void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory, "*.pts");
            foreach (string fileName in fileEntries)
                All_File_paths.Add(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        public PTS_file readOneFile()
        {
            PTS_file pts_file = new PTS_file(20);
            FileStream fsread = new FileStream(Path, FileMode.Open);
            StreamReader sr = new StreamReader(fsread);
            sr.ReadLine();      //read version 
            sr.ReadLine();      //n_points
            sr.ReadLine();      //{
            int Point_num = 0;
            while (sr.Peek() > -1)
            {
                string line = sr.ReadLine();
                if (line == "}")
                    continue;
                string[] num = line.Split(' ');
                pts_file.point[Point_num].X = double.Parse(num[0]);
                pts_file.point[Point_num].Y = double.Parse(num[1]);
                Point_num++;
            }
            sr.Close();
            return pts_file;
        }
    }
}
