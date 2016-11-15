using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class RoomListComponentScript : MonoBehaviour
{

    public RawImage[] starPictures;
    public RawImage lockPicture;
    public Image background;
    public Text roomNameText;
    public Text playerNumberText;

    public Color notSelected;
    public Color selected;

    string[] categories;
    string gameRoomName;
    bool locked;
    int numberOfPlayers;
    int maxPlayers;
    int difficulty;

    int counter;

    // Use this for initialization
    void Start()
    {
        counter = 0;
        //gameRoomName = "Testroom";
        //difficulty = 2;
        //maxPlayers = 3;
    }

    /// <summary>
    /// Sets values of the object
    /// </summary>
    /// <param name="roomName">Name of the gameroom</param>
    /// <param name="currentPlayers">Number of players currently in the room</param>
    /// <param name="maxPlayers">Maximum number of players</param>
    /// <param name="difficulty">Difficulty of the room, from 1(easy) to 3(hard)</param>
    public void SetValues(string roomName, int currentPlayers, int maxPlayers, bool locked, int difficulty, string[] categories)
    {
        GetComponent<BoxCollider2D>().size = GetComponent<RectTransform>().rect.size;
        gameRoomName = roomName;
        numberOfPlayers = currentPlayers;
        this.locked = locked;
        this.maxPlayers = maxPlayers;
        this.difficulty = difficulty;
        Deselect();
        SetDiffeculty();
        SetLocked();
        SetCategories(categories);
        UpdateGUI();
    }

    public void Select()
    {
        if (notSelected.Equals(selected))
        {
            background.color = new Color(.8f, .8f, .8f);
        }
        else
        {
            background.color = selected;
        }
    }

    public void Deselect()
    {
        if (notSelected.Equals(selected))
        {
            background.color = new Color(.5f, .5f, .5f);
        }
        else
        {
            background.color = notSelected;
        }
    }

    void UpdateGUI()
    {
        roomNameText.text = gameRoomName;
        playerNumberText.text = "" + numberOfPlayers + "/" + maxPlayers;
    }

    void SetCategories(string[] categories)
    {
        for (int i = 0; i < categories.Length; i++)
        {
            try
            {
                GameObject.Find(categories[i]).GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
            catch(NullReferenceException e)
            {
                Debug.Log("Category not found: " + categories[i] + "\n" + e.Message);
            }
            //switch (categories[i])
            //{
            //    case "Matematik":
            //        //aktiver en farve
            //        continue;
            //    case "Farve":
            //        //aktiver anden farve
            //        continue;
            //    default:
            //        Debug.Log("Unavialable category detected: " + categories[i]);
            //        continue;
            //}
        }
    }

    void SetLocked()
    {
        if (!locked)
        {
            lockPicture.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    void SetDiffeculty()
    {
        if (difficulty < 3)
        {
            for (int i = starPictures.Length - 1; i >= difficulty; i--)
            {
                starPictures[i].transform.localScale = new Vector3(0, 0, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 100)
        {
            numberOfPlayers++;
        }
        counter++;
        UpdateGUI();
    }
}
