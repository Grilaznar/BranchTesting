using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionTextScript : MonoBehaviour
{

    //Not in use!

    string theQuestion = "knud";
    Text screenText;

    void Start()
    {
        screenText = gameObject.GetComponent<Text>();
        GetNewQuestion();
    }

    void GetNewQuestion()
    {
        //theQuestion = GameControl.control.FetchNewQuestion("");
        screenText.text = theQuestion;
    }
}
