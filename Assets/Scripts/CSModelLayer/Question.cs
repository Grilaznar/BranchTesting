using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.CSModelLayer
{
    public class Question
    {
        public string questionText { get; set; }
        public string[] answers { get; set; }
        int correctAnswer { get; set; }

        public Question()
        {

        }

        public Question(string question, string[] answers, int correctAnswerIndex)
        {
            this.questionText = question;
            this.answers = answers;
            this.correctAnswer = correctAnswerIndex;
        }
    }
}
