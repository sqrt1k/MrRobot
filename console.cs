using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace MrRobot
{
    class consoleInput
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public consoleInput()
        {
            AllocConsole();
            Console.WriteLine("Text Input:");
            Thread th1 = new Thread(new ThreadStart(textInput));
            th1.Start();
        }
        public static void getString(string s)
        {
            Console.WriteLine(s);
        }
        protected static void textInput()
        {
            while (true)
            {
                string s = Console.ReadLine();
                //Console.WriteLine(s);
                //speechText.speech(s);
                CommandClass.process(s);
                Thread.Sleep(0);
            }
        }

    }
}