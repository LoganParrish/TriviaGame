using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGame
{
    public class Trivia
    {
        //TODO: Fill out the Trivia Object
        
        //The Trivia Object will have 2 properties
        // at a minimum, Question and Answer

        public string Answer { get; set; }
        public string Question { get; set; }
        public string Category { get; set; }

        //The Constructor for the Trivia object will
        // accept only 1 string parameter.  You will
        // split the question from the answer in your
        // constructor and assign them to the Question
        // and Answer properties
        public Trivia(string answer)
        {
            List<string> split = new List<string>();
            split = answer.Split('*').ToList();

            this.Answer = split[1];
            this.Question = split[0];
            //List<string> split2 = new List<string>();
            //if (temp.Contains(":"))
            //{
            //    split2 = temp.Split(':').ToList();
            //    this.Category = split2[0];
            //    this.Question = split2[1];
            //}
            //else
            //{
            //    this.Category = "Common";
            //    this.Question = temp;
            //}
        }


    }
}
