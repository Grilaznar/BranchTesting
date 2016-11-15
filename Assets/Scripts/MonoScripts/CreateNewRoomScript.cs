using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class CreateNewRoomScript : MonoBehaviour
{

    public GameObject[] toggleButtons;
    public GameObject diffeculty;

    void Start()
    {
        //test1();
        test2();
    }

    void test1()
    {
        Toggle[] toggles1 = (Toggle[])FindObjectsOfType(typeof(Toggle));
        Debug.Log(toggles1.Length);
        for (int i = 0; i < toggles1.Length; i++)
        {
            Debug.Log(toggles1[i].GetComponentInChildren<Text>().text);
        }
    }

    void test2()
    {
        Toggle[] toggles = transform.parent.GetComponentsInChildren<Toggle>();
        Debug.Log(toggles.Length);
        for (int i = 0; i < toggles.Length; i++)
        {
            Debug.Log(toggles[i].GetComponentInChildren<Text>().text);
        }
    }

    List<string> ListCategories()
    {
        List<string> categories = new List<string>();

        Toggle[] toggles = transform.parent.GetComponentsInChildren<Toggle>();

        for(int i = 0; i < toggles.Length; i++)
        {
            string text = toggles[i].GetComponentInChildren<Text>().text;
            if (toggles[i].isOn && !text.Equals("Toggle"))
            {
                categories.Add(text);
            }
        }
        for (int i = 0; i < categories.Count; i++)
        {
            print(categories[i]);
        }

            return categories;
    }

    public void CreateNewRoom()
    {
        /*
        string container = "";
        string[] array;

        for (int i = 0; i < toggleButtons.Length; i++)
        {
            Toggle button = toggleButtons[i].GetComponent<Toggle>();
            string buttonText = button.GetComponentInChildren<Text>().text;
            if (button.isOn && !buttonText.Equals("Toggle"))
            {
                if (container.Length > 0)
                {
                    container += " ";
                }
                container += buttonText;
            }
        }
        array = container.Split(' ');
        for (int i = 0; i < array.Length; i++)
        {
            array[i].Trim();
            Debug.Log(array[i].ToString());
        }
        */

        int diffecultyValue = diffeculty.GetComponent<Dropdown>().value + 1;
        Debug.Log(diffecultyValue);

        if (GameControl.control != null)
        {
            GameControl.control.categories = ListCategories().ToArray();
            GameControl.control.diffeculty = diffecultyValue;
        }
        SceneManager.LoadScene("GameRoom");
    }
}
