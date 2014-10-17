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


            while (score > 0 && score < 15)
            {

                var userQuestionAnswer = GetTriviaList()[rng.Next(0, 5001)];

                Console.WriteLine("Total score : " + score + "   Number correct : " + correct + "   Number incorrect : " + incorrect);
                Console.WriteLine("_______________________________________________________________________________\n\n");

                Console.WriteLine(userQuestionAnswer.Question + "\n");

                string input = Console.ReadLine();

                if (input == userQuestionAnswer.Answer.ToLower())
                {
                    Console.WriteLine("Correct!\n");
                    correct++;
                    score += 1;
                }
                else
                {
                    Console.WriteLine("Incorrect!\n");
                    incorrect++;
                    score -= 1;
                }
                Console.WriteLine("\nThe answer was " + userQuestionAnswer.Answer);
                Console.WriteLine("\nPress any key to continue!");
                Console.ReadKey();
                Console.Clear();
                if (score <= 0)
                {
                    Console.WriteLine("You lose. You're terrible. You're just so bad.");
                    Console.WriteLine("On your way to a total score of " + score + ", you got " + correct + " correct and " + incorrect + " incorrect.");
                }
                else if (score >= 15)
                {
                    Console.WriteLine("I have no idea how you managed to win. You are literally jesus.");
                    Console.WriteLine("On your way to a total score of " + score + ", you got " + correct + " correct and " + incorrect + " incorrect.");
                }
                
            }
            AddHighScore(correct);
            DisplayHighScore();
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
        static void AddHighScore(int playerScore)
        {
            Console.WriteLine("\n\nAdd your name to the highscores: ");
            string playerName = Console.ReadLine();

            LoganEntities1 db = new LoganEntities1();

            HighScore newHighScore = new HighScore();
            newHighScore.DateCreated = DateTime.Now;
            newHighScore.Name = playerName;
            newHighScore.Game = "TriviaGame";
            newHighScore.Score = playerScore;

            db.HighScores.Add(newHighScore);

            
            
            db.SaveChanges();

        }
        static void DisplayHighScore()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n==================== HIGH SCORES ====================");
            Console.WriteLine("=====================================================");
            Console.WriteLine("\n");
            Console.ResetColor();

            //create a new connection to the database
            LoganEntities1 db = new LoganEntities1();
            List<HighScore> highScoreList = db.HighScores.Where(x => x.Game == "TriviaGame").OrderByDescending(x => x.Score).Take(10).ToList();

            foreach (HighScore highScore in highScoreList)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("{0}. {1} - {2} - {3}", highScoreList.IndexOf(highScore) + 1, highScore.Name, highScore.Score, highScore.DateCreated.Value.ToShortDateString());
                Console.ResetColor();
            }
        }
    }
}
