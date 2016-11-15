using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuitToLobbyScript : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    public void QuitToLobbyRoom()
    {
        if (GameControl.control != null)
        {
            GameControl.control.ResetGameData();
        }
        SceneManager.LoadScene("Lobby");
    }
}
