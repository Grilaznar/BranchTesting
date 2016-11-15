using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JoinScript : MonoBehaviour
{
    void Update()
    {
        if (RoomListScript.highlighted == null)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }

    public void EnterRoom()
    {
        SceneManager.LoadScene("GameRoom");
    }
}
