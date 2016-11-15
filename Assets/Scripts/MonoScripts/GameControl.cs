using UnityEngine;
using System.Collections;

using LitJson;
using System.IO;
using System.Collections.Generic;
using Assets.Scripts.CSModelLayer;

public class GameControl : MonoBehaviour
{

    public static GameControl control;
    public string username;

    public string[] categories;
    public int diffeculty;
    public int score;

    void Awake()
    {
        string libTest = "" + (int)'æ' + (int)'ø' + (int)'å';
        if (!libTest.Equals("230248229"))
        {
            Debug.Log("Problem med Æ Ø Å!!");
        }
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            //Destroy(gameObject);
        }
    }

    public void ResetGameData()
    {
        score = 0;
        categories = null;
    }

    void OnGUI()
    {
        if (username != null)
        {
            //GUI.Label(new Rect(20, 20, 100, 30), username + " " + score);
        }
        //GUI.Label(new Rect(100, 100, 100, 30), "" + Time.deltaTime);
    }

    public void testjson()
    {
        //string fileName = Application.dataPath;
        string fileName = @"F:\Martin 14\Temp\test";
        List<Question> list = new List<Question>();
        string[] array = { "svenønsdal", "næh", "måske", "knud" };
        for (int i = 0; i < 10; i++)
        {
            list.Add(new Question("knud er en neger?", array,0));
        }
        JsonData data = JsonMapper.ToJson(list);
        Debug.Log(Application.dataPath + (int)'æ' + (int)'ø' + (int)'å');
        Debug.Log(data.ToString());
        File.WriteAllText(fileName, data.ToString());
        string content = File.ReadAllText(fileName);
        List<Question> q = JsonMapper.ToObject<List<Question>>(new JsonReader(content));
        Debug.Log("" + q[0].questionText + " " + q[0].answers[0] + q[0].answers[1] + q[0].answers[2] + q[0].answers[3]);
    }
}

/*
public void testjson()
{
    List<Knud> list = new List<Knud>();
    for (int i = 0; i < 10; i++)
    {
        list.Add(new Knud());
    }
    string content = "";
    string fileName = @"F:\Martin 14\Temp\test";
    try
    {
        string writecontent = "";
        for (int i = 0; i < list.Count; i++)
        {
            writecontent += JsonUtility.ToJson(list[i]);
        }
        File.WriteAllText(fileName, writecontent);
        content = File.ReadAllText(fileName);
        content = content.Split('{')[1];
    }
    catch(IOException E)
    {
        Debug.Log("IO FUckup" + E.Message);
    }
    Debug.Log(content);
}




    Question question = new Question("This is a stupid question", new string[] { "Blå", "asdasd", "fsfddf<", "safsdf" }, 0);
    questionJson = JsonMapper.ToJson(question);
    File.WriteAllText(Application.dataPath + "/Questions.json", questionJson.ToString());
    Debug.Log(questionJson);

public class Knud
{
static int i = 0;
[SerializeField]
int k;
public string content;
public Knud()
{
    k = i;
    i++;
    content = "Denne indeholder " + k;
}
}
*/
