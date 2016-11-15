using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MultiplayerScript : MonoBehaviour
{
    bool hasConnection;
    Button fg;
    void Start()
    {
        hasConnection = false;
        if (!hasConnection)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    void Update()
    {

    }

    public void ChooseMultiplayer()
    {
        SceneManager.LoadScene("CreateRoom");
    }
}
