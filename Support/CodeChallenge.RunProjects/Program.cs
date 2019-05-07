using System;
using System.Diagnostics;
using System.IO;

namespace CodeChallenge.RunProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();

            Console.WriteLine("The current directory is {0}", path);

            char delimiter = '\\';

            string[] paths = path.Split(delimiter);

            int parts = paths.Length;
            string runningPath = string.Empty;

            foreach (string filePath in paths)
            {
                if (runningPath.Contains("Support"))
                {
                    break;
                }

                runningPath = runningPath + filePath + @"\";


            }

            Console.WriteLine(runningPath);

           
            Console.WriteLine("Starting Customers Web Api");
            Process process0 = new Process();
            process0.StartInfo.CreateNoWindow = false;
            process0.StartInfo.UseShellExecute = false;
            process0.StartInfo.RedirectStandardOutput = false;
            process0.StartInfo.FileName = runningPath + @"\Customers.bat";
            process0.StartInfo.Arguments = runningPath;
            Console.WriteLine(process0.StartInfo.FileName);
            process0.Start();

            Console.WriteLine("Starting Vehicles Web Api");
            Process process2 = new Process();
            process2.StartInfo.CreateNoWindow = false;
            process2.StartInfo.UseShellExecute = false;
            process2.StartInfo.RedirectStandardOutput = false;
            process2.StartInfo.FileName = runningPath + @"\Vehicles.bat";
            process2.StartInfo.Arguments = runningPath;
            process2.Start();

            Console.WriteLine("Starting Simulation Web Api");
            Process process1 = new Process();
            process1.StartInfo.CreateNoWindow = false;
            process1.StartInfo.UseShellExecute = false;
            process1.StartInfo.RedirectStandardOutput = false;
            process1.StartInfo.FileName = runningPath + @"\Simulation.bat";
            process1.StartInfo.Arguments = runningPath;
            process1.Start();


            Console.ReadKey();

        }

    }
}
