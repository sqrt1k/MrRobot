using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace MrRobot
{
    class ProgramModule : Modules
    {
        public static void openProgramm(string s)
        {
            string filePath = "";
            if ((s.IndexOf("гугл хром") >= 0)|| (s.IndexOf("Google Chrome") >= 0)|| (s.IndexOf("хром") >= 0))
            {
                string[] str = System.IO.File.ReadAllLines("programms.ini", Encoding.Default);
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i].IndexOf("chrome") >= 0)
                    {
                        filePath = str[i];
                        break;
                    }
                    else
                    {
                        try
                        {
                            string[] findFiles = System.IO.Directory.GetFiles(@"C:\Program Files (x86)", "chrome.exe", System.IO.SearchOption.AllDirectories);
                            foreach (string file in findFiles)
                            {
                                using (var writer = new StreamWriter("programms.ini", true))
                                {
                                    writer.WriteLine(file);
                                }
                                filePath = file;
                            }
                            Console.WriteLine("Открываю");
                            speechText.speech("Открываю");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка");
                        }
                    }
                }
                Process.Start(filePath);
            }
        }
    }
}
