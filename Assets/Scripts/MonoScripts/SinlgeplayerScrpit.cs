using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SinlgeplayerScrpit : MonoBehaviour
{


    void Start()
    {

    }

    void Update()
    {

    }

    public void ChooseSingleplayer()
    {
        SceneManager.LoadScene("CreateRoom");
    }
}
