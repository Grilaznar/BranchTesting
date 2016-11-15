using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.CSModelLayer;

public class SaveQuestionScript : MonoBehaviour
{

    public Text[] inputs;
    QuestionsDB qDB;

    void Start()
    {
        qDB = new QuestionsDB();
    }

    public void MakeTestData()
    {
        for (int i = 0; i < 200; i++)
        {
            qDB.SaveQuestionToJson(new Question("TestQuestion" + i, new[] { "Answer" + i, "Wrong" + i, "Wrong" + i, "Wrong" + i }, 0), "TestData");
        }
    }

    public void SaveQuestion()
    {
        if (inputs[0].text.Equals(""))
        {
            MakeTestData();
            return;
        }
        string[] answers = new string[4];
        for (int i = 0; i < 4; i++)
        {
            answers[i] = inputs[i + 2].text;
        }
        Question question = new Question(inputs[1].text, answers, 0);
        qDB.SaveQuestionToJson(question, inputs[0].text);
    }

    public void REEEAAAD()
    {
        //qDB.ReadQuestionV2();
        qDB.ReadQuestion(inputs[0].text, 1);
    }
}
