using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MrRobot
{
    class CommandClass
    {
        public static void process(string s) //обработчик сообщения. Должен определять команда это или разговорное предложение
        {
            if(s.IndexOf("что такое")>=0)
            {
                //передаём строку модулю wikipedia
                string str = s.Replace("что такое ", string.Empty);
                speechText.speech(WikiModule.start(str));
            }
            else if(s.IndexOf("найди") >= 0)
            {
                string str = s.Replace("найди ", string.Empty);
                speechText.speech(googleModule.start(str));
            }
            else if(s.IndexOf("стоп хватит")>=0)
            {
                speechText.stopSpeech();
                speechText.speech("Хорошо");
            }
            else if(s.IndexOf("обработай текст")>=0)
            {
                procTextModule.replaceText();
            }
            else if(s.IndexOf("сколько будет")>=0)
            {
                string str = s.Replace("сколько будет ", string.Empty);
                calculatorModule.calculate(str);
            }
            else if(s.IndexOf("видео")>=0)
            {
                videoRecognition.start();
            }
            else if(s.IndexOf("сохрани изображение") >= 0)
            {
                videoRecognition.imgSave();
            }
            else if(s.IndexOf("спасибо") >= 0)
            {
                Console.WriteLine("Всегда пожалуйста");
                speechText.speech("Всегда пожалуйста");
            }
            else if (s.IndexOf("открой") >= 0)
            {
                string str = s.Replace("открой ", string.Empty);
                ProgramModule.openProgramm(str);
            }
            else
            {
                if(s.IndexOf("скажи")>=0)
                {
                    string str = s.Replace("скажи ", string.Empty);
                    Console.WriteLine(str);
                    speechText.speech(str);
                }
                else
                {
                    dialogModule.getString(s);
                }
            }
        }
    }
}
