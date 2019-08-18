using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;

namespace MrRobot
{
    class speechText
    {
            static SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            public speechText()
            {
                synthesizer.SetOutputToDefaultAudioDevice();
                //synthesizer.SelectVoice("Microsoft Irina Desktop");
                //synthesizer.SelectVoice("ScanSoft Katerina_Full_22kHz");
                synthesizer.SelectVoice("IVONA 2 Tatyana");
                //synthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult); // to change VoiceGender and VoiceAge check out those links below
                synthesizer.Volume = 100;  // (0 - 100)
                synthesizer.Rate = 0;     // (-10 - 10)
        }
            public static void speech(string args)
            {
            // Asynchronous
            //var voices = synthesizer.GetInstalledVoices(new System.Globalization.CultureInfo("ru-RU"));
            if (args.IndexOf("+") >= 0)
            {
                args = args.Replace("+", "плюс");
            }
            else if (args.IndexOf("-") >= 0)
            {
                args = args.Replace("-", "минус");
            }
            else if(args.IndexOf("*") >= 0)
            {
                args = args.Replace("*", "умножить");
            }
            else if (args.IndexOf("/") >= 0)
            {
                args = args.Replace("/", "разделить");
            }
            synthesizer.SpeakAsync(args); // here args = pran
            }
            public static void stopSpeech()
            {
                var current = synthesizer.GetCurrentlySpokenPrompt();
                if (current != null) //это остановка произношения
                synthesizer.SpeakAsyncCancel(current);
        }
    }
}
