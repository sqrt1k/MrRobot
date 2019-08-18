using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Collections;

namespace MrRobot
{
    class googleModule : Modules
    {
        public static string start(string s)
        {
            return search(s);
        }
        public static string search(string str)
        {
            string html = "https://google.ru/search?q=";
            string req = str;
            html = html + req;
            HtmlDocument HD = new HtmlDocument();
            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8,
            };
            HD = web.Load(html);

            // Собственно, здесь и производится выборка интересующих нам нодов
            // В данном случае выбираем блочные элементы с классом eTitle
            HtmlNode NoAltElements = HD.DocumentNode.SelectSingleNode("//span[@class='st']");
            consoleInput.getString(NoAltElements.InnerText);
            if (NoAltElements != null)
            {
                    string outputText = NoAltElements.InnerText;
                    return outputText;
            }
            return "Я ничего не нашёл";
            // Проверяем наличие узлов
            /*if (NoAltElements != null)
            {
                foreach (HtmlNode HN in NoAltElements)
                {
                    // Получаем строчки
                    string outputText = HN.InnerText;
                    //int startindex = outputText.IndexOf("&#160;—");
                    //int endindex = outputText.IndexOf("Сод") - startindex;
                    // if(outputText.Contains("&#160;"))
                    string text = outputText;
                    /*
                    try
                    {
                        text = outputText.Substring(startindex, endindex);
                    }
                    catch
                    {
                        /*
                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i] == str)
                            {
                                s[i] = "";
                                break;
                            }
                        }
                        System.IO.File.WriteAllLines("F:/MrRobot/bin/Debug/words.txt", s);

                        return "Я не знаю";
                    }
                    text = text.Replace("&#160;", "");
                    text = text.Replace("&#91;1&#93", string.Empty);
                    text = text.Replace("&#91;2&#93", string.Empty);
                    text = text.Replace("&#91;3&#93", string.Empty);
                    text = text.Replace("&#91;4&#93", string.Empty);

                    return text;
                }
            }*/

        }
    }
}
