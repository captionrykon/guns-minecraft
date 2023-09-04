using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;


// when we add script to gameobject the component  we will add automatically 
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class ChunkRenderer : MonoBehaviour
{
    MeshFilter meshFilter;
    MeshCollider meshCollider;
    Mesh mesh;
    

    //to save the change in chunks
    public ChunkData ChunkData { get; private set; }

    public bool ModifiedByThePlayer
    {
        get
        {
            return ChunkData.modifiedByThePlayer;
        }
        set
        {
            ChunkData.modifiedByThePlayer = value;
        }
    }

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshCollider = GetComponent<MeshCollider>();
        mesh = meshFilter.mesh;
    }

    public void InitializeChunk(ChunkData data)
    {
        this.ChunkData = data;
    }

    private void RenderMesh(MeshData meshData)
    {
        mesh.Clear();

        mesh.subMeshCount = 2;
        // adding verticies of mesh to vertices of water  mesh
        mesh.vertices = meshData.pointsv.Concat(meshData.waterMesh.pointsv).ToArray();
        //
        mesh.SetTriangles(meshData.triangles.ToArray(), 0);
        //1 is for water //// select is the offset to match the index in mesh.vertices array
        mesh.SetTriangles(meshData.waterMesh.triangles.Select(val => val + meshData.pointsv.Count).ToArray(), 1);

        mesh.uv = meshData.uv.Concat(meshData.waterMesh.uv).ToArray();
        mesh.RecalculateNormals();

        meshCollider.sharedMesh = null;
        Mesh collisionMesh = new Mesh();
        collisionMesh.vertices = meshData.colliderPointsv.ToArray();
        collisionMesh.triangles = meshData.colliderTriangles.ToArray();
        collisionMesh.RecalculateNormals();

        meshCollider.sharedMesh = collisionMesh;
    }

    public void UpdateChunk()
    {
        RenderMesh(Chunk.GetChunkMeshData(ChunkData));
    }

    public void UpdateChunk(MeshData data)
    {
        RenderMesh(data);
    }

}