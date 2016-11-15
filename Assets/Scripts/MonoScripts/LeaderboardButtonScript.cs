using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LeaderboardButtonScript : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    public void GoToLeaderboardScene()
    {
        SceneManager.LoadScene("LeaderBoard");
    }
}
