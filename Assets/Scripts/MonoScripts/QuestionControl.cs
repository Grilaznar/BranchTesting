using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LitJson;
using System.IO;
using System.Collections.Generic;
using Assets.Scripts.CSModelLayer;

public class QuestionControl : MonoBehaviour
{

    public Text questionText;
    public GameObject[] answerButtons;
    LocalScoreScript scoreScript;
    AnswerButtonScript[] answerScripts;

    QuestionsDB qDB;
    Question currentQuestion;
    List<Question> questions;
    //int nextButtonID;
    int correctButton;
    int questionNumber;
    public int maxQuestionNumber;
    int score;

    void Awake()
    {
        qDB = new QuestionsDB();
        //maxQuestionNumber = 15;
        questionNumber = 0;
        //nextButtonID = 0;
        answerScripts = new AnswerButtonScript[4];
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerScripts[i] = answerButtons[i].GetComponent<AnswerButtonScript>();
        }
    }

    

    void Start()
    {
        scoreScript = FindObjectOfType<LocalScoreScript>();
        score = scoreScript.GetScore(false);
        FetchQuestions();
    }

    void FetchQuestions()
    {
        if(GameControl.control.categories.Length < 1)
        {
            questions = qDB.FecthQuestions(new string[] { "TestData" }, 1);
        }
        else
        {
            questions = qDB.FecthQuestions(GameControl.control.categories, GameControl.control.diffeculty);
        }

        NewQuestion();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 50, 200, 30), "Total score: " + score);
    }

    /// <summary>
    /// Fecthes a new question from whatever source, also returns the new question
    /// </summary>
    /// <param name="category">What category you want the question from</param>
    /// <returns>The new question</returns>
    public void NewQuestion()
    {
        currentQuestion = questions[questionNumber];
        questionNumber++;

        //setQuestion();

        SetQuestionText(currentQuestion.questionText);
        SetAnswerTexts(currentQuestion.answers);
    }

    void setTestQuestion()
    {
        string[] a = { "ser", "du", "en", "neger" };
        currentQuestion.answers = a;
        currentQuestion.questionText = "This is a question";
    }

    public void GiveAnswer(int answerButtonNumber)
    {
        questionText.text = "Number " + answerButtonNumber + " has answered!";
        if (answerButtonNumber == correctButton)
        {
            score += scoreScript.GetScore(true);
        }
        else
        {
            scoreScript.GetScore(false);
        }
        if (questionNumber >= maxQuestionNumber)
        {
            EndQuestioning();
        }
        else
        {
            NewQuestion();
        }
    }

    void SetQuestionText(string question)
    {
        questionText.text = question;
    }

    void SetAnswerTexts(string[] answers)
    {
        RandomizeButtonOrder();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                correctButton = answerScripts[i].SetAnswer(answers[i]);
            }
            else
            {
                answerScripts[i].SetAnswer(answers[i]);
            }
        }
    }

    void RandomizeButtonOrder()
    {
        for(int i = answerScripts.Length - 1; i >= 0; i--)
        {
            int k = Random.Range(0, answerScripts.Length - 1);
            var value = answerScripts[k];
            answerScripts[k] = answerScripts[i];
            answerScripts[i] = value;
        }
    }

    void EndQuestioning()
    {
        if (GameControl.control != null)
        {
            GameControl.control.score += score;
        }
        SceneManager.LoadScene("GameRoom");
    }

    //public int ButtonCheckIn(Text buttonText)
    //{
    //    answerTexts[nextButtonID] = buttonText;
    //    nextButtonID++;
    //    return nextButtonID;
    //}
}
