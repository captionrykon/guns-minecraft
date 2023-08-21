
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//chunk data is the data about the type of chunk of each block data 
// spliting the data and method for multithreading
public class ChunkData
{
    public BlockType[] blocks;
    public int chunkSize = 16;
    public int chunkHeight = 100;

    // what is world for chunk so the chunks can communicate with each other in the perspective to the world
    public World worldReference;

    //reference of position in the world where chunk is placed(convert world position of a point to the local coordinate system of the chunk)
    public Vector3Int worldPosition;

    //bool to save the modified chunks by the player. save inside the world class
    public bool modifiedByThePlayer = false;
    public TreeData treeData;

    //
    public ChunkData(int chunkSize, int chunkHeight, World world, Vector3Int worldPosition)
    {
        this.chunkSize = chunkSize;
        this.chunkHeight = chunkHeight;
        this.worldReference = world;
        this.worldPosition = worldPosition;
        blocks = new BlockType[chunkSize * chunkHeight * chunkSize];
    }

}