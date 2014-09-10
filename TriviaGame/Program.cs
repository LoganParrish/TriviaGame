using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //The logic for your trivia game happens here
            List<Trivia> AllQuestions = GetTriviaList();
            Random rng = new Random();

            int score = 5;
            int correct = 0;
            int incorrect = 0;


            while (score > 0)
            {

                Console.WriteLine(GetTriviaList()[rng.Next(0, 5001)].Question);
                string input = Console.ReadLine();

                if (input == )
                {
                    Console.WriteLine("Correct!");
                }
                Console.WriteLine("The answer was " + );
            }

            Console.ReadKey();
        }


        //This functions gets the full list of trivia questions from the Trivia.txt document
        static List<Trivia> GetTriviaList()
        {
            //Get Contents from the file.  Remove the special char "\r".  Split on each line.  Convert to a list.
            List<string> contents = File.ReadAllText("trivia.txt").Replace("\r", "").Split('\n').ToList();

            //Each item in list "contents" is now one line of the Trivia.txt document.
            
            //make a new list to return all trivia questions
            List<Trivia> returnList = new List<Trivia>();
            // TODO: go through each line in contents of the trivia file and make a trivia object.
            //       add it to our return list.
            // Example: Trivia newTrivia = new Trivia("what is my name?*question");
            //Return the full list of trivia questions
            foreach (var item in contents)
            {
                Trivia bestTrivia = new Trivia(item);
                returnList.Add(bestTrivia);
            }

            return returnList;
        }
    }
}
