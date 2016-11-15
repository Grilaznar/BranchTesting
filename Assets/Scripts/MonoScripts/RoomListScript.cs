using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;
using System.Collections.Generic;

public class RoomListScript : MonoBehaviour
{
    public GameObject listComponentPrefab;
    public GameObject listObject;

    public static GameObject highlighted;

    public int distanceToNextComponent;

    List<GameObject> list;
    RectTransform listRect;

    // Use this for initialization
    void Start()
    {
        listRect = listObject.GetComponent<RectTransform>();
        listObject.transform.position = new Vector3(0, 0, 0);
        list = new List<GameObject>();
        if(distanceToNextComponent == 0)
        {
            distanceToNextComponent = (int)listComponentPrefab.GetComponent<RectTransform>().rect.height;
        }
        TestData();
    }

    void TestData()
    {
        AddToList("knud", 1, 9, false, 1, new string[] { "Matematik", "Farve" });
        AddToList("Sven", 2, 3, true, 2, new string[] { "Matematik", "Farve" });
        AddToList("knud", 1, 9, false, 1, new string[] { "Matematik", "Farve" });
        AddToList("Sven", 2, 3, true, 2, new string[] { "Matematik", "Farve" });
        AddToList("knud", 1, 9, false, 1, new string[] { "Matematik", "Farve" });
        AddToList("Sven", 2, 3, true, 2, new string[] { "Matematik", "Farve" });
        AddToList("knud", 1, 9, false, 1, new string[] { "Matematik", "Farve" });
        AddToList("Sven", 2, 3, true, 2, new string[] { "Matematik", "Farve" });
    }

    void AddToList(string roomName, int currentPlayers, int maxPlayers, bool locked, int difficulty, string[] categories)
    {
        GameObject listComponent = Instantiate(listComponentPrefab);
        RoomListComponentScript listComponentScript = listComponent.GetComponent<RoomListComponentScript>();
        listComponentScript.SetValues(roomName, currentPlayers, maxPlayers, locked, difficulty, categories);
        listComponent.transform.SetParent(listObject.transform);
        list.Add(listComponent);
        RefreshList();
    }

    public void RefreshList()
    {
        listRect.sizeDelta = new Vector2(0, 10 + (distanceToNextComponent * list.Count));
        for (int i = 0; i < list.Count; i++)
        { 
            GameObject obj = list[i];
            obj.transform.position = new Vector3(0, -((distanceToNextComponent / 2) + (distanceToNextComponent * i)), 0);
            obj.name = "RoomEntry" + (i + 1);
            //listObject.transform.localScale = new Vector3(0, -(20 + 25 * i), 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.up);
            if (hit.collider != null)
            {
                if(highlighted != null)
                {
                    highlighted.GetComponent<RoomListComponentScript>().Deselect();
                }
                Debug.Log("" + hit.collider.name + " " + hit.collider.tag);
                highlighted = hit.collider.gameObject;
                highlighted.GetComponent<RoomListComponentScript>().Select();
            }
            else if (highlighted != null)
            {
                highlighted.GetComponent<RoomListComponentScript>().Deselect();
                highlighted = null;
            }
        }
    }
}
