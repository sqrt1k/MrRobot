using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrRobot
{
    class calculatorModule : Modules
    {
        public static void calculate(string s)
        {
            float result = 0.0f;
            string[] param = s.Split(new char[] { '+','-','*','/' }, StringSplitOptions.RemoveEmptyEntries);
            float[] parameters = new float[param.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '+')
                {
                    for(int j = 0;j<param.Length;j++)
                    {
                        parameters[j] = float.Parse(param[j]);
                    }
                    result = plus(parameters);
                }
                else if (s[i] == '-')
                {
                    for (int j = 0; j < param.Length; j++)
                    {
                        parameters[j] = float.Parse(param[j]);
                    }
                    result = minus(parameters);
                }
                else if (s[i] == '*')
                {
                    for (int j = 0; j < param.Length; j++)
                    {
                        parameters[j] = float.Parse(param[j]);
                    }
                    result = multiply(parameters);
                }
                else if (s[i] == '/')
                {
                    for (int j = 0; j < param.Length; j++)
                    {
                        parameters[j] = float.Parse(param[j]);
                    }
                    result = division(parameters);
                }
            }
            Console.WriteLine(s + " = " + result);
            speechText.speech(s + " = " + result);
        }
        protected static float plus(float[] param)
        {
            float res = 0.0f;
            for(int i = 0;i<param.Length;i++)
            {
                res += param[i];
            }
            return res;
        }
        protected static float minus(float[] param)
        {
            float res = 0.0f;
            for (int i = 0; i < param.Length; i++)
            {
                try
                {
                    res = param[i] - param[i + 1];
                }
                catch
                {
                    if (param.Length != 2)
                    {
                        res -= param[i];
                    }
                }
            }
            return res;
        }
        protected static float multiply(float[] param)
        {
            float res = 0.0f;
            for (int i = 0; i < param.Length; i++)
            {
                try
                {
                    res = param[i] * param[i + 1];
                }
                catch
                {
                    if (param.Length != 2)
                    {
                        res *= param[i];
                    }
                }
            }
            return res;
        }
        protected static float division(float[] param)
        {
            float res = 0.0f;
            for (int i = 0; i < param.Length; i++)
            {
                try
                {
                    res = param[i] / param[i + 1];
                }
                catch
                {
                    if (param.Length != 2)
                    {
                        res /= param[i];
                    }
                }
            }
            return res;
        }
    }
}
