using UnityEngine;

public class Map {

    //Map(Vector3 charPosition, )

    public Vector3 charPosition;
    public int width;
    public int heigth;
    public Vector3 startPosition;
    public int[,] mapMatrix;
    public int boxNumber;
    public Vector3[] boxLocations;
    public int Scarab3PartNumber;
    public int Scarab2PartNumber;
    public int itemType; // 1: Key, 2: Gem
}
