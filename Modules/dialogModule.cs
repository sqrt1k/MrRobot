using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word2Vec.Net;

namespace MrRobot
{
    class dialogModule
    {
        public static void getString(string s)
        {
            //search(s);
            //speechText.speech("Очень хорошо");
            BestWord[] bw = search(s);
            string[] words =  s.Split(' ');
            if (bw != null)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    try
                    {
                        Console.WriteLine(bw[i].Word);
                        speechText.speech(bw[i].Word);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Ошибка: "+ex);
                        speechText.speech("Я не знаю такого слова");
                    }
                }
            }
           
        }
        public static void start()
        {
            string trainfile = "F:/MrRobot_2_0/MrRobot/bin/Debug/data.txt";
            string outputFileName = "F:/output.bin";
            var word2Vec = Word2VecBuilder.Create()
                .WithTrainFile(trainfile)// Use text data to train the model;
                .WithOutputFile(outputFileName)//Use to save the resulting word vectors / word clusters
                .WithSize(300)//Set size of word vectors; default is 100
                .WithSaveVocubFile("F:/MrRobot_2_0/MrRobot/bin/Debug/list.txt")//The vocabulary will be saved to <file> //поменять
                .WithDebug(2)//Set the debug mode (default = 2 = more info during training)
                .WithBinary(1)//Save the resulting vectors in binary moded; default is 0 (off) //поменять
                .WithCBow(0)//Use the continuous bag of words model; default is 1 (use 0 for skip-gram model)
                .WithAlpha(0.025f)//Set the starting learning rate; default is 0.025 for skip-gram and 0.05 for CBOW
                .WithWindow(5)//Set max skip length between words; default is 5
                .WithSample((float)1e-5)//Set threshold for occurrence of words. Those that appear with higher frequency in the training data twill be randomly down-sampled; default is 1e-3, useful range is (0, 1e-5)
                .WithHs(0)//Use Hierarchical Softmax; default is 0 (not used)
                .WithNegative(5)//Number of negative examples; default is 5, common values are 3 - 10 (0 = not used)
                .WithThreads(5)//Use <int> threads (default 12)
                .WithIter(5)//Run more training iterations (default 5)
                .WithMinCount(5)//This will discard words that appear less than <int> times; default is 5
                .WithClasses(0)//Output word classes rather than word vectors; default number of classes is 0 (vectors are written)
                .Build();

            word2Vec.TrainModel();

            /*var distance = new Distance(outputFileName);
            BestWord[] bestwords = distance.Search("some_word");
            */
        }
        static BestWord[] search(string s)
        {
           var distance = new Distance("F:/output.bin");
           BestWord[] bestwords = distance.Search(s);
            if (bestwords != null)
            {
                foreach (BestWord bw in bestwords)
                {
                    //Console.Write(bw.Word+"    ");
                    //Console.WriteLine(bw.Distance);
                }
            }
            else
            {
                return null;
            }
            return bestwords;
            //var analogy = new WordAnalogy("X:/output.bin");
            //BestWord[] bestwords = analogy.Search(s);
        }
    }
}
