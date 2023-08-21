using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//seprate thread for data file
//meshdata is the data of the mesh that how mesh looks in the world
public class MeshData
{
    //list of vertices
    public List<Vector3> pointsv = new List<Vector3>();
    public List<int> triangles = new List<int>();
    public List<Vector2> uv = new List<Vector2>();


    //  use for water block so that it cannot colide with  player
    public List<Vector3> colliderPointsv = new List<Vector3>();
    public List<int> colliderTriangles = new List<int>();

    public MeshData waterMesh;

    // create the constructer
    private bool isMainMesh = true;

    public MeshData(bool isMainMesh)
    {
        if (isMainMesh)
        {
            waterMesh = new MeshData(false);
        }
    }

    

    // add vertices to our verticies list
    // bool is used if we have the collider type of air then we dont want a collider
    public void AddVertex(Vector3 vertex, bool vertexGeneratesCollider)
    {
        pointsv.Add(vertex);
        if (vertexGeneratesCollider)
        {
            colliderPointsv.Add(vertex);
        }

    }

    // craete quard for render only one face
    /// <summary>
    /// https://youtu.be/OIGg7Yql1jM
    /// time stape is 8:21 to last
    /// </summary>
    /// <param name="quadGeneratesCollider"></param>
    public void AddQuadTriangles(bool quadGeneratesCollider)
    {
        triangles.Add(pointsv.Count - 4);
        triangles.Add(pointsv.Count - 3);
        triangles.Add(pointsv.Count - 2);

        triangles.Add(pointsv.Count - 4);
        triangles.Add(pointsv.Count - 2);
        triangles.Add(pointsv.Count - 1);

        if (quadGeneratesCollider)
        {
            colliderTriangles.Add(colliderPointsv.Count - 4);
            colliderTriangles.Add(colliderPointsv.Count - 3);
            colliderTriangles.Add(colliderPointsv.Count - 2);
            colliderTriangles.Add(colliderPointsv.Count - 4);
            colliderTriangles.Add(colliderPointsv.Count - 2);
            colliderTriangles.Add(colliderPointsv.Count - 1);
        }
    }
}