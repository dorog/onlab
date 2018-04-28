using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class MapGenerator : MonoBehaviour {

    private bool used;
    private GameObject door;
    private GameObject Joe;
    private int count = 1;
    // public GameObject Joe;          //ID:
    public GameObject EdgeModel;    // 1    
    public GameObject brickModel;   // 0
    public GameObject doorModel;    // -1
    public GameObject KeyModel;     // 2
    public GameObject trapModel;    // 3
    public GameObject buttonModel;  // 4
    public GameObject boxModel;     // 5: box + brick under it
    public GameObject holeModel;    // 6
    public GameObject BridgeMakeModel; //7
    public GameObject BridgeElementModel; //8

    private int EdgeID = 1;
    private int BrickID = 0;
    private int DoorID = -1;
    private int KeyID = -2;
    private int TrapID = 3;
    private int ButtonID = 4;
    private int BoxID = 5;
    private int HoleID = 6;
    private int BridgeElementID = 8;
    private int TwoBoxOnBridgeElement = -3;


    private Vector3 joePosition;
    
    public int mapNumber = 0;
    GameObject parent;
    private List<GameObject> notStaticElements = new List<GameObject>();


    private int[,] actMap;
    private int[,] originalMap;

    private int EdgeChild = 3;
    private const int BrickChild = 0;
    private int TrapChild = 2;
    private int ButtonChild = 1;
    private int BoxChild = 4;
    public int BridgeChild = 5;

    private Vector3 doorPosition;

    private List<int> notStaticElementsID = new List<int>(); //clear it ?
    private List<Vector3> notStaticElementsPosition = new List<Vector3>();
    private List<GameObject> boxes = new List<GameObject>();
    private List<GameObject> bridges = new List<GameObject>();

    private Vector3 startPosition;

    private int charMatrixPositionX;
    private int charMatrixPositionZ;

    private int originMatrixPositionX;
    private int originMatrixPositionZ;

    // Use this for initialization
    void Start()
    {
        used = false;
        parent = GameObject.Find(Configuration.mapGeneratorName);
        mapNumber = CurrentGameDatas.mapNumber;
        Joe = GameObject.Find(Configuration.characterName);

        CreateMap(mapNumber);
    }

    public void CreateMap(int number)
    {
        try
        {
            using (StreamReader sr = new StreamReader("map"+number+".txt"))
            {
                //Debug.Log("usingba");
                String line = sr.ReadToEnd();
                string[] datas = line.Split('\n');
                string[] charPosition = datas[0].Split(' ');

                //character position ready
                Joe.transform.position = new Vector3(Convert.ToInt32(charPosition[0]), Convert.ToInt32(charPosition[1]), Convert.ToInt32(charPosition[2]));

                string[] matrixDatas = datas[1].Split(' ');
                actMap = new int[Convert.ToInt32(matrixDatas[0]), Convert.ToInt32(matrixDatas[1])];
                originalMap = new int[Convert.ToInt32(matrixDatas[0]), Convert.ToInt32(matrixDatas[1])];

                string[] stPos = datas[2].Split(' ');
                
                startPosition = new Vector3(Convert.ToInt32(stPos[0]), 0, Convert.ToInt32(stPos[1]));

                charMatrixPositionZ = (Convert.ToInt32(stPos[1]) - Convert.ToInt32(charPosition[2])) / Configuration.unit;
                originMatrixPositionZ = charMatrixPositionZ;
                charMatrixPositionX = (Convert.ToInt32(charPosition[0]) - Convert.ToInt32(stPos[0])) / Configuration.unit;
                originMatrixPositionX = charMatrixPositionX;


                for (int i=0; i< Convert.ToInt32(matrixDatas[0]); i++)
                {

                    string[] row = datas[i+3].Split(' ');


                    for (int j=0; j< Convert.ToInt32(matrixDatas[1]); j++)
                    {

                        Vector3 placePosition = startPosition + new Vector3(Configuration.unit*j, 0, i * -1 * Configuration.unit);
                        int id = Convert.ToInt32(row[j]);
                        actMap[i,j] = id;
                        originalMap[i, j] = id;
                        switch (id)
                        {
                            case 0:
                                Instantiate(brickModel, placePosition + new Vector3(0, Configuration.brickGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(BrickChild));
                                break;
                            case 1:
                                Instantiate(EdgeModel, placePosition+new Vector3(0, Configuration.edgeGround, 0), Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(EdgeChild));
                                break;
                            case 3:
                                GameObject trap = Instantiate(trapModel, placePosition + new Vector3(0, Configuration.trapGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(TrapChild)) as GameObject;
                                notStaticElementsID.Add(3);
                                notStaticElementsPosition.Add(new Vector3(placePosition.x, placePosition.y+Configuration.trapGround, placePosition.z));
                                notStaticElements.Add(trap);
                                break;
                            case 4:
                                GameObject doorButton = Instantiate(buttonModel, placePosition + new Vector3(0, Configuration.buttonGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(ButtonChild)) as GameObject;
                                notStaticElementsID.Add(4);
                                notStaticElementsPosition.Add(new Vector3(placePosition.x, placePosition.y+Configuration.buttonGround, placePosition.z));
                                notStaticElements.Add(doorButton);
                                count++;
                                break;
                            case 5:
                                Instantiate(brickModel, placePosition + new Vector3(0, Configuration.brickGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(BrickChild));
                                GameObject box = Instantiate(boxModel, placePosition + new Vector3(0, Configuration.boxGround, 0), Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(BoxChild)) as GameObject;
                                box.GetComponent<BoxController>().x = j;
                                box.GetComponent<BoxController>().z = i;
                                //Visszaallitasnak tudnom kene hova rakjam vissza, tolas menedzseles nincs meg
                                notStaticElementsID.Add(5);
                                notStaticElementsPosition.Add(new Vector3(placePosition.x, placePosition.y + Configuration.boxGround, placePosition.z));
                                notStaticElements.Add(box);
                                boxes.Add(box);
                                break;
                            case 6:
                                Instantiate(holeModel, placePosition + new Vector3(0, Configuration.holeGround, -25), Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(BrickChild));
                                break;
                            case -1:
                                door = Instantiate(doorModel, placePosition + new Vector3(0, Configuration.doorGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
                                notStaticElements.Add(door);
                                doorPosition = placePosition;
                                break;
                            case -2:
                                GameObject Key = Instantiate(KeyModel, placePosition + new Vector3(0, Configuration.keyGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
                                notStaticElementsID.Add(-2);
                                notStaticElementsPosition.Add(new Vector3(placePosition.x, placePosition.y + Configuration.keyGround, placePosition.z));
                                notStaticElements.Add(Key);
                                break;
                            case 7:
                                GameObject BridgeMaker = Instantiate(BridgeMakeModel, placePosition + new Vector3(0, Configuration.bridgeMakeGround, -25), Quaternion.AngleAxis(0, Vector3.right), parent.transform) as GameObject;
                                notStaticElementsID.Add(7);
                                notStaticElementsPosition.Add(placePosition + new Vector3(0, Configuration.bridgeMakeGround, -25));
                                notStaticElements.Add(BridgeMaker);
                                actMap[i, j] = EdgeID;
                                originalMap[i, j] = EdgeID;
                                break;
                            case 8:
                                GameObject BridgeElement = Instantiate(BridgeElementModel, placePosition + new Vector3(0, Configuration.holeGround, -25), Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(BridgeChild));
                                notStaticElementsID.Add(8);
                                notStaticElementsPosition.Add(placePosition + new Vector3(0, Configuration.bridgeElementGround, -25));
                                notStaticElements.Add(BridgeElement);
                                BridgeElement.GetComponent<RiseElement>().x = j;
                                BridgeElement.GetComponent<RiseElement>().z = i;
                                bridges.Add(BridgeElement);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("The file could not be read:");
            Debug.Log(e.Message);
        }
    }

    private void Update()
    {
        if (count == 0 && !used)
        {
            used = true;
            Animation anim = door.GetComponent<Animation>();
            anim.Play();
            for(int i=0; i<actMap.GetLength(0); i++)
            {
                for(int j=0; j<actMap.GetLength(1); j++)
                {
                    if(actMap[i, j] == DoorID)
                    {
                        actMap[i, j] = BrickID;
                        break;
                    }
                }
            }
        }
    }

    public void lessCount()
    {
        count--;
        //Debug.Log(count+" c");
    }

    public void restartMap(int number)
    {
        boxes.Clear();
        bridges.Clear();
        charMatrixPositionX = originMatrixPositionX;
        charMatrixPositionZ = originMatrixPositionZ;
        count = 0;
        for(int i=0; i<notStaticElements.Count; i++)
        {
            GameObject.Destroy(notStaticElements[i]);
        }
        used = false;

        door = Instantiate(doorModel, doorPosition, Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
        notStaticElements.Add(door);

        for(int i=0; i<notStaticElementsID.Count; i++)
        {
            switch (notStaticElementsID[i])
            {
                case 3:
                    GameObject trap = Instantiate(trapModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(TrapChild)) as GameObject;
                    notStaticElements.Add(trap);
                    break;
                case 4:
                    GameObject doorButton = Instantiate(buttonModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(ButtonChild)) as GameObject;
                    notStaticElements.Add(doorButton);
                    count++;
                    break;
                case 5:
                    GameObject box = Instantiate(boxModel, notStaticElementsPosition[i], Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(BoxChild)) as GameObject;
                    box.GetComponent<BoxController>().x = (int)(notStaticElementsPosition[i].x - startPosition.x)/Configuration.unit;
                    box.GetComponent<BoxController>().z = (int)(startPosition.z-notStaticElementsPosition[i].z)/Configuration.unit;
                    notStaticElements.Add(box);
                    boxes.Add(box);
                    break;
                case -2:
                    GameObject Key = Instantiate(KeyModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
                    notStaticElements.Add(Key);
                    break;
                case 7:
                    GameObject BridgeMaker = Instantiate(BridgeMakeModel, notStaticElementsPosition[i], Quaternion.AngleAxis(0, Vector3.right), parent.transform) as GameObject;
                    notStaticElements.Add(BridgeMaker);
                    break;
                case 8:
                    GameObject BridgeElement = Instantiate(BridgeElementModel, notStaticElementsPosition[i], Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(BridgeChild));
                    notStaticElements.Add(BridgeElement);
                    bridges.Add(BridgeElement);
                    break;
                default:
                    break;
            }
        }

        for(int i=0; i<originalMap.GetLength(0); i++)
        {
           for(int j=0; j<originalMap.GetLength(1); j++)
            {
                actMap[i, j] = originalMap[i, j];
            }
        }
    }

    public void RiseBridgeElements()
    {
        for(int i=0; i<bridges.Count; i++)
        {
            if (bridges[i].GetComponent<RiseElement>().boxOnIt == 0)
            {
                actMap[bridges[i].GetComponent<RiseElement>().z, bridges[i].GetComponent<RiseElement>().x] = BrickID;
            }
            else if(bridges[i].GetComponent<RiseElement>().boxOnIt == 1)
            {
                actMap[bridges[i].GetComponent<RiseElement>().z, bridges[i].GetComponent<RiseElement>().x] = BoxID;
            }
            else
            {
                actMap[bridges[i].GetComponent<RiseElement>().z, bridges[i].GetComponent<RiseElement>().x] = TwoBoxOnBridgeElement;
            }
        }
    }

    public void RightToMove()
    {
        int x = charMatrixPositionX;
        int z = charMatrixPositionZ;
        int[] reCalc = new int[2];
        if (Joe.transform.forward == Vector3.left)
        {
            x--;
            reCalc[0] = -1;
            reCalc[1] = 0;
        }
        else if(Joe.transform.forward == Vector3.right)
        {
            x++;
            reCalc[0] = 1;
            reCalc[1] = 0;
        }
        else if (Joe.transform.forward == Vector3.back)
        {
            z++;
            reCalc[0] = 0;
            reCalc[1] = 1;
        }
        else
        {
            z--;
            reCalc[0] = 0;
            reCalc[1] = -1;
        }

        if(actMap[charMatrixPositionZ, charMatrixPositionX] == HoleID)
        {
            if(actMap[z, x] == HoleID || actMap[z, x]==EdgeID)
            {
                Joe.GetComponent<JoeCommandControl>().GoForward();
                charMatrixPositionX = x;
                charMatrixPositionZ = z;
            }
            else
            {
                return; //In the Hole and he cant go forward
            }
        }
        else if (actMap[z, x] == DoorID || actMap[z, x] == TwoBoxOnBridgeElement )
        {
            return; //TODO: valami animaciot adni neki
        }
        else if (actMap[z, x] == BoxID) 
        {
            if(actMap[z+reCalc[1], x + reCalc[0]] < 0 || actMap[z + reCalc[1], x + reCalc[0]] == BoxID) //static element: <0
            {
                return; //TODO: valami animaciot adni neki
            }
            else if(actMap[z + reCalc[1], x + reCalc[0]] == EdgeID) //edge
            {
                int i = 0;
                while (!(boxes[i].GetComponent<BoxController>().x == x && boxes[i].GetComponent<BoxController>().z == z))
                {
                    i++;
                }
                actMap[z, x] = BrickID;
                actMap[z + reCalc[1], x + reCalc[0]] = HoleID;
                boxes[i].GetComponent<BoxController>().x += reCalc[0];
                boxes[i].GetComponent<BoxController>().z += reCalc[1];
                boxes[i].GetComponent<BoxController>().MoveToThere(Joe.transform.forward);
                Joe.GetComponent<JoeCommandControl>().GoForward();
                charMatrixPositionX = x;
                charMatrixPositionZ = z;

            }
            else if(actMap[z + reCalc[1], x + reCalc[0]] == TrapID)
            {
                int i = 0;
                while (!(boxes[i].GetComponent<BoxController>().x == x && boxes[i].GetComponent<BoxController>().z == z))
                {
                    i++;
                }
                actMap[z, x] = BrickID;
                boxes[i].GetComponent<BoxController>().x = -1; // he cant push now, i didnt want to move it
                boxes[i].GetComponent<BoxController>().z = -1;
                boxes[i].GetComponent<BoxController>().MoveToThere(Joe.transform.forward);
                Joe.GetComponent<JoeCommandControl>().GoForward();
                charMatrixPositionX = x;
                charMatrixPositionZ = z;
            }
            else if(actMap[z + reCalc[1], x + reCalc[0]]==HoleID)
            {
                //New element
                int i = 0;
                while (!(boxes[i].GetComponent<BoxController>().x == x && boxes[i].GetComponent<BoxController>().z == z))
                {
                    i++;
                }
                actMap[z, x] = BrickID;
                actMap[z + reCalc[1], x + reCalc[0]] = BrickID;
                boxes[i].GetComponent<BoxController>().x = -1; //in the hole, he cant push it now
                boxes[i].GetComponent<BoxController>().z = -1; // -||-
                boxes[i].GetComponent<BoxController>().MoveToThere(Joe.transform.forward);
                Joe.GetComponent<JoeCommandControl>().GoForward();
                charMatrixPositionX = x;
                charMatrixPositionZ = z;
            }
            else if(actMap[z + reCalc[1], x + reCalc[0]] == BridgeElementID)
            {
                int i = 0;
                while (!(bridges[i].GetComponent<RiseElement>().x == x && bridges[i].GetComponent<RiseElement>().z == z))
                {
                    i++;
                }
                if (bridges[i].GetComponent<RiseElement>().boxOnIt < 2)
                {
                    int j = 0;
                    while (!(boxes[j].GetComponent<BoxController>().x == x && boxes[j].GetComponent<BoxController>().z == z))
                    {
                        j++;
                    }
                    actMap[z, x] = BrickID;
                    boxes[j].GetComponent<BoxController>().x += reCalc[0];
                    boxes[j].GetComponent<BoxController>().z += reCalc[1];
                    boxes[j].GetComponent<BoxController>().MoveToThere(Joe.transform.forward);
                    Joe.GetComponent<JoeCommandControl>().GoForward();
                    charMatrixPositionX = x;
                    charMatrixPositionZ = z;
                    bridges[i].GetComponent<RiseElement>().boxOnIt++;
                    bridges[i].GetComponent<RiseElement>().boxes.Add(boxes[j]);
                }
            }
            else
            {
                int i = 0;
                while (!(boxes[i].GetComponent<BoxController>().x == x && boxes[i].GetComponent<BoxController>().z == z)) {
                    i++;
                }
                actMap[z, x] = BrickID; 
                actMap[z + reCalc[1], x + reCalc[0]] = BoxID;
                boxes[i].GetComponent<BoxController>().x += reCalc[0];
                boxes[i].GetComponent<BoxController>().z += reCalc[1];
                boxes[i].GetComponent<BoxController>().MoveToThere(Joe.transform.forward);
                Joe.GetComponent<JoeCommandControl>().GoForward();
                charMatrixPositionX = x;
                charMatrixPositionZ = z;
            }
        }
        else if (actMap[z, x] == BridgeElementID)
        {
            int i = 0;
            while (!(bridges[i].GetComponent<RiseElement>().x == x && bridges[i].GetComponent<RiseElement>().z == z))
            {
                i++;
            }
            if (bridges[i].GetComponent<RiseElement>().boxOnIt<2)
            {
                Joe.GetComponent<JoeCommandControl>().GoForward();
                charMatrixPositionX = x;
                charMatrixPositionZ = z;
            }
            else
            {
                //box on it, we can push it
                //TODO: check the next for pushing box: do a function
            }
        }
        else
        {
            Joe.GetComponent<JoeCommandControl>().GoForward();
            charMatrixPositionX = x;
            charMatrixPositionZ = z;
        }
    }
}
