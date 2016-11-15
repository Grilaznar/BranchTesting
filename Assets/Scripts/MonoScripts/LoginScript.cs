using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{

    public Text UsernameField;
    public Text PasswordField;
    

    public void Login()
    {
        GameControl.control.username = UsernameField.text;
        SceneManager.LoadScene("Lobby");
    }
}
