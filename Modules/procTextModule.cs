using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrRobot
{
    class procTextModule : Modules
    {
        static public void replaceText()
        {
            Console.WriteLine("Введите путь к файлу: ");
            string file = Console.ReadLine();
            try
            {
                string[] s = System.IO.File.ReadAllLines(file, Encoding.UTF8);
                Console.WriteLine("Что будем делать? ( 1-Замена лишних символов/)");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        s = replaceSymbols(s);
                        break;
                    default:
                        break;
                }
                System.IO.File.WriteAllLines(file, s);
                Console.WriteLine("Обработка текста завершена");
                speechText.speech("Обработка текста завершена");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: "+ex);
                speechText.speech("Произошла ошибка");
            }
        }
        static protected string[] replaceSymbols(string[] textMas)
        {
            string[] s = textMas;
            for (long i = 0; i < s.Length; i++)
            {
                s[i] = s[i].Replace("=", " ");
                s[i] = s[i].Replace("\\", " ");
                s[i] = s[i].Replace("?", " ");
                s[i] = s[i].Replace("0", " ");
                s[i] = s[i].Replace(")", " ");
                s[i] = s[i].Replace(":", " ");
                s[i] = s[i].Replace("!", " ");
                s[i] = s[i].Replace("1", " ");
                s[i] = s[i].Replace("2", " ");
                s[i] = s[i].Replace("3", " ");
                s[i] = s[i].Replace("4", " ");
                s[i] = s[i].Replace("5", " ");
                s[i] = s[i].Replace("6", " ");
                s[i] = s[i].Replace("7", " ");
                s[i] = s[i].Replace("8", " ");
                s[i] = s[i].Replace("9", " ");
                s[i] = s[i].Replace("(", " ");
                s[i] = s[i].Replace("/", " ");
                Console.WriteLine(s[i]);
            }
            return s;
        }
    }
}
