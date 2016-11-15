using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnswerButtonScript : MonoBehaviour
{

    public QuestionControl questionControl;
    Text text;

    static int nextID;
    int localID;

    void Start()
    {
        //gameObject.GetComponentInChildren<Text>().text = "knud";
        //localID = questionControl.ButtonCheckIn(gameObject.GetComponentInChildren<Text>());

        localID = nextID;
        nextID++;

        text = gameObject.GetComponentInChildren<Text>();
        if (text == null)
        {
            Button button = gameObject.GetComponentInChildren<Button>(true);

            text = button.GetComponentInChildren<Text>();
        }

        
    }

    public int SetAnswer(string answerText)
    {
        text.text = answerText;
        return localID;
    }

    public void GiveAnswer()
    {
        questionControl.GiveAnswer(localID);
    }
}
