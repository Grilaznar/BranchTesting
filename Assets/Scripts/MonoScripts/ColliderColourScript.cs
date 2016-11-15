using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ColliderColourScript : MonoBehaviour
{

    PolygonCollider2D pc2;

    // Use this for initialization
    void Start()
    {
        pc2 = gameObject.GetComponent<PolygonCollider2D>();
        //Render thing
        int pointCount = 0;
        pointCount = pc2.GetTotalPointCount();
        MeshFilter mf = GetComponent<MeshFilter>();

        Mesh mesh = new Mesh();
        mesh.Clear();
        mesh.name = "knud's mesh";
        List<Color> colorList = new List<Color>();

        Vector2[] points = pc2.points;
        Vector3[] vertices = new Vector3[pointCount];
        for (int j = 0; j < pointCount; j++)
        {
            Vector2 actual = points[j];
            vertices[j] = new Vector3(actual.x, actual.y, 0);
            colorList.Add(new Color(.5f, .1f, .1f, 1f));
        }

        Triangulator tr = new Triangulator(points);
        int[] triangles = tr.Triangulate();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        //mesh.SetColors(colorList);
        mf.mesh = mesh;
        print(mesh.vertexCount);
        print(pointCount);
        print(colorList.Count);
        foreach(Vector3 v3 in vertices)
        {
            print(v3);
        }
        if (GetComponent<RawImage>() != null)
        {
            GetComponent<RawImage>().color = new Color(.6f, .2f, .2f, .8f);
        }
        //Render thing
    }

    // Update is called once per frame
    void Update()
    {

    }
}
