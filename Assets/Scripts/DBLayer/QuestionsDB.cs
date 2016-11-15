using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;
using Assets.Scripts.CSModelLayer;

public class QuestionsDB
{

    public void SaveQuestionToJson(Question question, string category)
    {
        string path = Application.dataPath + "/Questions/" + category + ".json";

        JsonData questionJson = JsonMapper.ToJson(question);
        File.AppendAllText(path, questionJson.ToString());
        Debug.Log(questionJson);
        /*
        string path = Application.dataPath + "/" + category + ".json";
        List<Question> questionList = new List<Question>();
        if (File.Exists(path))
        {
            string text = File.ReadAllText(path);
            JsonReader reader = new JsonReader(text);
            questionList = JsonMapper.ToObject<List<Question>>(reader);
        }
        //muligvis test for duplikanter
        questionList.Add(question);
        JsonData questionJson = JsonMapper.ToJson(questionList);
        File.WriteAllText(path, questionJson.ToString());
        Debug.Log(questionJson);
        */
    }

    public List<Question> ReadQuestion(string category, int diffeculty)
    {
        if (category.Equals(""))
        {
            category = "TestData";
            Debug.Log("Loading TestData");
        }
        string path = Application.dataPath + "/Questions/" + category + " " + diffeculty + ".json";
        Debug.Log(path);

        List<Question> list = new List<Question>();

        string allText = File.ReadAllText(path);
        Debug.Log(allText);

        string[] array = allText.Split(new[] { '}' }, System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < array.Length; i++)
        {
            array[i] += "}";
            //Debug.Log(array[i]);
        }

        for (int i = 0; i < array.Length; i++)
        {
            list.Add(JsonMapper.ToObject<Question>(array[i]));
            //Debug.Log("" + list[i].questionText);
        }
        return list;
    }

    public void ReadQuestionV2()
    {
        string category = "Bevægeapperatet";
        int diffeculty = 1;

        string path = Application.dataPath + "/Questions/" + category + " " + diffeculty + ".json";
        Debug.Log(path);

        List<QuestionV2> list = new List<QuestionV2>();

        string allText = File.ReadAllText(path);
        Debug.Log(allText);

        string[] array = allText.Split(new[] { '}' }, System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < array.Length; i++)
        {
            array[i] += "}";
            //Debug.Log(array[i]);
        }

        for (int i = 0; i < array.Length; i++)
        {
            list.Add(JsonMapper.ToObject<QuestionV2>(array[i]));
            Debug.Log("" + list[i].Spørgsmål);
        }
        //return list;
    }

    public List<Question> FecthQuestions(string[] categories, int diffeculty, int numberOfQuestions = 10)
    {
        List<Question> result = new List<Question>();// { new Question("This is a stupid question", new string[] { "343242", "asdasd", "fsfddf<", "safsdf" }, 0) };
        
        List<List<Question>> questions = new List<List<Question>>();
        for (int i = 0; i < categories.Length; i++)
        {
            questions.Add(ReadQuestion(categories[i], diffeculty));
        }

        for (int i = 0; i < numberOfQuestions; i++)
        {
            int catcount = questions.Count;
            int currentCat = i % catcount;
            List<Question> currentquestionlist = questions[currentCat];
            int randomNumber = Random.Range(0, currentquestionlist.Count - 1);
            Question randomQuestion = currentquestionlist[randomNumber];
            result.Add(randomQuestion);
            //result.Add(questions[i % catcount][Random.Range(0, questions[i % questions.Count].Count - 1)]);
        }
        //int numberOfQuestionsPerCategory = totalQuestions / categories.Length;
        //int restNumberOfQUestions = totalQuestions % categories.Length;

        //for (int i = 0; i < categories.Length; i++)
        //{
        //    List<Question> questionsList = ReadQuestion(categories[i]);

        //    if(i == categories.Length - 1 && restNumberOfQUestions != 0)
        //    {
        //        for (int j = 0; j < restNumberOfQUestions; j++)
        //        {
        //            result.Add(questionsList[Random.Range(0,questionsList.Count - 1)]);
        //        }
        //    }
        //    else
        //    {
        //        for (int j = 0; j < numberOfQuestionsPerCategory; j++)
        //        {
        //            result.Add(questionsList[Random.Range(0, questionsList.Count - 1)]);
        //        }
        //    }
        //}

        ScrambleList(result);

        return result;
    }

    //Randomizer: needs to be updated
    void ScrambleList(List<Question> list)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            int k = Random.Range(0, list.Count - 1);
            var value = list[k];
            list[k] = list[i];
            list[i] = value;
        }
    }

    //public Question GetQuestion()
    //{
    //    return new Question();
    //}
}

public class Category
{
    public int id { get; set; }
    public string name { get; set; }

    public Category()
    {
        category = new List<Question>();
    }

    public List<Question> category;
}
/*
public class Question
{
    public string questionText { get; set; }
    public string[] answers { get; set; }
    public int correctAnswer { get; set; }

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
*/

