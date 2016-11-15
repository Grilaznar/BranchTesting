using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreateScript : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    public void EnterRoomCreation()
    {
        SceneManager.LoadScene("PlayerSelection");
    }
}
