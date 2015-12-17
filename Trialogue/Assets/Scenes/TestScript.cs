using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour
{

    Mesh testmesh;

    Vector3[] newVertices;
    int[] newTriangles;

    void Create_Test_Mesh()
    {
        newVertices = new Vector3[4];
        newTriangles = new int[6];
        testmesh = new Mesh();
        newVertices[0].x = 0;
        newVertices[0].y = 0;
        newVertices[0].z = 0;
        newVertices[1].x = 10;
        newVertices[1].y = 0;
        newVertices[1].z = 0;
        newVertices[2].x = 0;
        newVertices[2].y = 10;
        newVertices[2].z = 0;
        newVertices[3].x = 0;
        newVertices[3].y = 0;
        newVertices[3].z = 10;

        newTriangles[0] = 0;
        newTriangles[1] = 1;
        newTriangles[2] = 2;
        newTriangles[3] = 2;
        newTriangles[4] = 1;
        newTriangles[5] = 0;
        GetComponent<MeshFilter>().mesh = testmesh;
        testmesh.vertices = newVertices;
        testmesh.triangles = newTriangles;
    }

    void Start()
    {
        Create_Test_Mesh();
    }

}