using UnityEngine;
using System;

[Serializable]
public class Map {

    public string name;
    public Vector3 charPosition;
    public Vector3 charForward = new Vector3(1, 0, 0);
    public int width;
    public int heigth;
    public Vector3 startPosition;
    public MapElement[,] mapMatrix;
    public int boxNumber;
    public Vector3[] boxLocations;
    public int Scarab3PartNumber;
    public int Scarab2PartNumber;
    public int itemType;

    public int laserSwitchCount = 0;
    public int buttonCount = 0;
}

[Serializable]
public class CreatedMaps
{
    public MapSer[] maps;
}

[Serializable]
public class MapSer
{
    public string name;
    public Vector3Ser charPosition;
    public Vector3Ser charForward = new Vector3Ser(1f, 0f, 0f);
    public int width;
    public int heigth;
    public Vector3Ser startPosition;
    public MapElement[,] mapMatrix;
    public int boxNumber;
    public Vector3Ser[] boxLocations;
    public int Scarab3PartNumber;
    public int Scarab2PartNumber;
    public int itemType;

    public int laserSwitchCount = 0;
    public int buttonCount = 0;
}

[Serializable]
public class Vector3Ser{
    public float x, y, z;

    public Vector3Ser(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}
