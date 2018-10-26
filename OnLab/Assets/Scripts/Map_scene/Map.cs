using UnityEngine;

public class Map {

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
