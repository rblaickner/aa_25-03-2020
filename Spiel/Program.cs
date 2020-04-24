using Quiz.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel
{
    class Program
    {
        static void Main(string[] args)
        {
            Game spiel = new Game();
            Question frage1 = new Question("Wie viel ist 2 + 2?");
            frage1.AddAnswer(new Answer("5"));
            frage1.AddAnswer(new Answer("4", true));
            spiel.AddQuestion(frage1);

            Question frage2 = new Question("Wie viel ist 5 + 5?");
            frage2.AddAnswer(new Answer("10", true));
            frage2.AddAnswer(new Answer("11"));
            spiel.AddQuestion(frage2);

            Question frage3 = new Question("Wie viel ist 4 + 4?");
            frage3.AddAnswer(new Answer("9"));
            frage3.AddAnswer(new Answer("8", true));
            spiel.AddQuestion(frage3);

            while (spiel.Status == GameStatus.Active)
            {
                var frage = spiel.NextQuestion;
                var antworten = frage.Answers;

                foreach(var item in antworten)
                {
                    Console.WriteLine(item.Text);
                }

                Console.Write("Eingabe: ");
                string eingabe = Console.ReadLine();

                foreach (var item in antworten)
                {
                    Convert.ToInt32(item);

                    if(eingabe == item.Text)
                    {
                        item.IsChecked = true;
                    }
                }

                spiel.ValidateCurrentQuestion();
            }

            Console.WriteLine(spiel.Status);

        }
    }
}
