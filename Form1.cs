using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using Microsoft.Speech.Synthesis;

namespace MrRobot
{
    public partial class Form1 : Form
    {
        private static NotifyIcon _notifyIcon = null; //иконка приложения
         static Browser brw = new Browser(); //окно с браузером
        
        private static int br2_x=0;//смещение экрана во время пролистывания страницы
        
        public Form1()
        {
            InitializeComponent();
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Text = "MrROBOT";
            _notifyIcon.Visible = true;
            //устанавливаем значок, отображаемый в трее:
            _notifyIcon.Icon = Resource1.network;
            //добавляем контекстное меню к значку
            _notifyIcon.ContextMenuStrip = contextMenuStrip1;
            //подписываемся на событие клика по пункту меню "Выход"
            выходToolStripMenuItem.Click += new EventHandler(_exitToolStripMenuItem_Click);

            /*System.Collections.ObjectModel.ReadOnlyCollection<InstalledVoice>

            voices = synthesizer.GetInstalledVoices();

            foreach (InstalledVoice voice in voices)
            {
                MessageBox.Show(voice.VoiceInfo.Name);
            }*/
            //
         /////////////////////////////////////////////////////////////// voiceInput.voice();
        }
        void _exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        static Label l;
        
       
        private void Form1_Load(object sender, EventArgs e)
        {
            /*string[] s = System.IO.File.ReadAllLines("F:/MrRobot/bin/Debug/words.txt", Encoding.Default);
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = s[i].Remove(s[i].IndexOf('#'), s[i].Length - s[i].IndexOf('#'));
            }
            System.IO.File.WriteAllLines("F:/MrRobot/bin/Debug/words.txt", s);*/
                ////////
            /*string html = "https://ru.wikipedia.org/wiki/";
            string[] st = System.IO.File.ReadAllLines("F:/MrRobot/bin/Debug/123.txt", Encoding.Default);
            string req;
            HtmlDocument HD = new HtmlDocument();
            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8,
            };
            for (int i = 0; i < st.Length; i++)
            {
                req = st[i];
                html = html + req;
                try
                {
                    web.Load(html);
                }
                catch
                {
                    st[i] = string.Empty;
                }
            }
            System.IO.File.WriteAllLines("F:/MrRobot/bin/Debug/123.txt", st);
            ////////*/
                l = label1;
            consoleInput textConsole = new consoleInput();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            speechText.speech("привет, я компьютер. Что ты хотел?");
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //this.Hide(); // скрывает основную форму
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //не удалять функцию!
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dialogModule.start();
        }
        /**/
    }
}
