using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PnCPictureScript : MonoBehaviour
{

    public GameObject[] colliderHolders;
    List<PolygonCollider2D> colliders;

    // Use this for initialization
    void Start()
    {
        colliders = new List<PolygonCollider2D>();
        foreach(GameObject holder in colliderHolders)
        {
            colliders.Add(holder.GetComponent<PolygonCollider2D>());
        }
        foreach(PolygonCollider2D p in colliders)
        {
            print(p);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
