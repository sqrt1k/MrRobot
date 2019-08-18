using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Speech.Recognition;

namespace MrRobot
{
    class voiceInput
    {
        static string[] s; //вспомогательная переменная для словарей
        static void voice()
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ru-ru");
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci);
            sre.SetInputToDefaultAudioDevice();
            sre.BabbleTimeout = TimeSpan.FromSeconds(3);

            //задает интервал ожидания полной тишины (без шума)
            sre.InitialSilenceTimeout = TimeSpan.FromSeconds(3);
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);

            //Начинаем создавать словарь
            Choices words = new Choices();
            words.Add(new string[] { "ниже", "выше", "компьютер", "доброе утро компьютер", "спасибо компьютер", "компьютер включи музыку", "что такое", "спасибо хватит", "компьютер включи", "напиши" });

            Choices wiki = new Choices();
            s = System.IO.File.ReadAllLines("F:/MrRobot/bin/Debug/words.txt", Encoding.Default);
            //wiki.Add(new string[] { "робот", " " });
            wiki.Add(s);

            //
            //
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(words);
            gb.Append(wiki);

            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);
            //
            //MessageBox.Show("Словарь загружен в память.");
            //
            sre.RecognizeAsync(RecognizeMode.Multiple);
        }
        static void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)//событие распознавания речи
        {
            if (e.Result.Confidence > 0.6)
            {
                //l.Text = e.Result.Text; //вывести на экран - то, что я сказал
                //speechText.speech(e.Result.Text);// и произнести это
                CommandClass.process(e.Result.Text);
                /*
                if (e.Result.Text == "доброе утро компьютер")
                {
                    //brw.Show();
                    //speechText.speech("Доброе утро!");
                    CommandClass.process("Доброе утро!");
                }
                else if (e.Result.Text == "спасибо компьютер")
                {
                    //brw.Hide();

                }
                else if (e.Result.Text == "компьютер включи музыку")
                {

                }
                else if (e.Result.Text.Contains("что такое"))
                {
                    string str = e.Result.Text.Replace("что такое ", string.Empty);
                    //speech(search(str));
                }
                else if (e.Result.Text == "спасибо хватит")
                {
                    /*
                    //speechText.speech("Хорошо.");
                    CommandClass.process("Хорошо.");

                }
                else if (e.Result.Text.Contains("компьютер включи"))
                {
                    string str = e.Result.Text.Replace("компьютер включи ", string.Empty);
                    if (str == "гугл хром")
                    {
                        System.Diagnostics.Process Proc = new System.Diagnostics.Process();
                        Proc.StartInfo.FileName = "chrome.exe";
                        Proc.Start();
                    }
                }*/
                /*else if (e.Result.Text.Contains("напиши"))
                {
                    string str = e.Result.Text.Replace("напиши ", string.Empty);
                    if (str == "контакт")
                    {
                        SendKeys.Send("v");
                        SendKeys.Send("k");
                        SendKeys.Send("{ENTER}");
                    }
                }*/

                /*if (brw.Visible)
                {
                    if (e.Result.Text == "ниже")
                    {
                        br2_x += 300;
                        brw.br2_scrol(true, br2_x);
                    }
                    else if (e.Result.Text == "выше")
                    {
                        br2_x -= 300;
                        brw.br2_scrol(false, br2_x);
                    }
                }*/
            }
        }
    }
}
