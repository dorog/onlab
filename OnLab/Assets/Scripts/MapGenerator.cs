using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class MapGenerator : MonoBehaviour
{

    private bool used;
    private GameObject door;
    private GameObject Joe;
    private int count = 0;
    // public GameObject Joe;               //ID:
    public GameObject diamondModel;         // -4
    public GameObject doorEdgeModel;        // -3
    public GameObject KeyModel;             // -2
    public GameObject doorModel;            // -1
    public GameObject brickModel;           // 0
    public GameObject EdgeModel;            // 1   
    public GameObject trapModel;            // 2
    public GameObject buttonModel;          // 3
    public GameObject holeModel;            // 4
    public GameObject BridgeMakeModel;      // 5
    public GameObject BridgeElementModel;   // 6
    public GameObject laserGateModel;       // 7
    public GameObject laserGateEdgeModel;   // 8
    public GameObject laserSwitchModel;     // 9

    public GameObject boxModel;     // 

    private int BoxID = 10;

    private Vector3 joePosition;

    public int mapNumber = 0;
    GameObject parent;

    private int[,] actMap;
    private int[,] originalMap;
    private GameObject[,] objectMap;

    private int EdgeChild = 3;
    private const int BrickChild = 0;
    private int TrapChild = 2;
    private int ButtonChild = 1;
    private int BoxChild = 4;
    private int BridgeChild = 5;
    private int LaserSwitchChild = 6;
    private int LaserGateChild = 7;
    private int DoorChild = 8;

    private Vector3 doorPosition;

    private List<GameObject> notStaticElements = new List<GameObject>();
    private List<int> notStaticElementsID = new List<int>();
    private List<Vector3> notStaticElementsPosition = new List<Vector3>();
    private List<LaserGate> laserGates = new List<LaserGate>();
    private List<RiseElement> bridgeElements = new List<RiseElement>();

    private Vector3 startPosition;

    private int charMatrixPositionX;
    private int charMatrixPositionZ;

    private int originMatrixPositionX;
    private int originMatrixPositionZ;

    private int summSwitches;

    private string doorAnimName = "OpenWalledDoor";
    private float doorOpenSpeed = 2f;

    // Use this for initialization
    void Start()
    {
        used = false;
        parent = GameObject.Find(Configuration.mapGeneratorName);
        mapNumber = CurrentGameDatas.mapNumber;
        Joe = GameObject.Find(Configuration.characterName);
        summSwitches = 0;
        CreateMap(mapNumber);
    }

    public void CreateMap(int number)
    {
        try
        {
            Map map = initMap(number);

            for (int i = 0; i < map.heigth; i++)
            {
                for (int j = 0; j < map.width; j++)
                {

                    Vector3 placePosition = startPosition + new Vector3(Configuration.unit * j, 0, i * -1 * Configuration.unit);
                    int id = map.mapMatrix[i, j];
                    actMap[i, j] = id;
                    switch (id)
                    {
                        case 0:
                            GameObject brick = Instantiate(brickModel, placePosition + new Vector3(0, Configuration.brickGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(BrickChild));
                            objectMap[i, j] = brick;
                            break;
                        case 1:
                            GameObject edge = Instantiate(EdgeModel, placePosition + new Vector3(0, Configuration.edgeGround, 0), Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(EdgeChild));
                            objectMap[i, j] = edge;
                            break;
                        case 2:
                            GameObject trap = Instantiate(trapModel, placePosition + new Vector3(0, Configuration.trapGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(TrapChild)) as GameObject;
                            objectMap[i, j] = trap;
                            notStaticElementsID.Add(2);
                            notStaticElementsPosition.Add(new Vector3(placePosition.x, placePosition.y + Configuration.trapGround, placePosition.z));
                            notStaticElements.Add(trap);
                            break;
                        case 3:
                            GameObject doorButton = Instantiate(buttonModel, placePosition + new Vector3(0, Configuration.buttonGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(ButtonChild)) as GameObject;
                            objectMap[i, j] = doorButton;
                            notStaticElementsID.Add(3);
                            notStaticElementsPosition.Add(new Vector3(placePosition.x, placePosition.y + Configuration.buttonGround, placePosition.z));
                            notStaticElements.Add(doorButton);
                            count++;
                            break;
                        case 4:
                            GameObject hole = Instantiate(holeModel, placePosition + new Vector3(0, Configuration.holeGround, -25), Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(BrickChild));
                            objectMap[i, j] = hole;
                            break;
                        case -1:
                            door = Instantiate(doorModel, placePosition + new Vector3(0, Configuration.doorGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(DoorChild)) as GameObject;
                            objectMap[i, j] = door;
                            notStaticElements.Add(door);
                            doorPosition = placePosition;
                            break;
                        case -2:
                            GameObject Key = Instantiate(KeyModel, placePosition + new Vector3(0, Configuration.keyGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
                            objectMap[i, j] = Key;
                            notStaticElementsID.Add(-2);
                            notStaticElementsPosition.Add(new Vector3(placePosition.x, placePosition.y + Configuration.keyGround, placePosition.z));
                            notStaticElements.Add(Key);
                            break;
                        case -3:
                            GameObject doorEdge = Instantiate(doorEdgeModel, placePosition + new Vector3(0, Configuration.doorEdgeGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(DoorChild)) as GameObject;
                            objectMap[i, j] = doorEdge;
                            break;
                        case 5:
                            GameObject BridgeMaker = Instantiate(BridgeMakeModel, placePosition + new Vector3(0, Configuration.bridgeMakeGround, -25), Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(BridgeChild)) as GameObject;
                            objectMap[i, j] = BridgeMaker;
                            notStaticElementsID.Add(5);
                            notStaticElementsPosition.Add(placePosition + new Vector3(0, Configuration.bridgeMakeGround, -25));
                            notStaticElements.Add(BridgeMaker);
                            originalMap[i, j] = 5;
                            break;
                        case 6:
                            GameObject BridgeElement = Instantiate(BridgeElementModel, placePosition + new Vector3(0, Configuration.bridgeElementGround, -25), Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(BridgeChild));
                            objectMap[i, j] = BridgeElement;
                            notStaticElementsID.Add(6);
                            notStaticElementsPosition.Add(placePosition + new Vector3(0, Configuration.bridgeElementGround, -25));
                            notStaticElements.Add(BridgeElement);
                            bridgeElements.Add(BridgeElement.GetComponent<RiseElement>());
                            break;
                        case 7:
                            GameObject laserGate = Instantiate(laserGateModel, placePosition + new Vector3(0, Configuration.laserGateGround, 0), Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(LaserGateChild)) as GameObject;
                            objectMap[i, j] = laserGate;
                            laserGates.Add(laserGate.GetComponent<LaserGate>());
                            break;
                        case 8:
                            GameObject laserGateEdge = Instantiate(laserGateEdgeModel, placePosition + new Vector3(0, Configuration.laserGateEdgeGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(LaserGateChild)) as GameObject;
                            objectMap[i, j] = laserGateEdge;
                            break;
                        case 9:
                            GameObject laserSwitch = Instantiate(laserSwitchModel, placePosition + new Vector3(0, Configuration.laserSwitchGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(LaserSwitchChild)) as GameObject;
                            objectMap[i, j] = laserSwitch;
                            notStaticElementsID.Add(9);
                            notStaticElementsPosition.Add(new Vector3(placePosition.x, placePosition.y + Configuration.laserSwitchGround, placePosition.z));
                            notStaticElements.Add(laserSwitch);
                            summSwitches++;
                            break;
                        case -4:
                            GameObject Gem = Instantiate(diamondModel, placePosition + new Vector3(0, Configuration.keyGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
                            objectMap[i, j] = Gem;
                            notStaticElementsID.Add(-4);
                            notStaticElementsPosition.Add(new Vector3(placePosition.x, placePosition.y + Configuration.keyGround, placePosition.z));
                            notStaticElements.Add(Gem);
                            break;
                        default:
                            break;
                    }
                }
            }

            int boxNumber = map.boxNumber;
            for (int i = 0; i < boxNumber; i++)
            {
                Vector3 position = map.boxLocations[i];
                GameObject box = Instantiate(boxModel, position, Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(BoxChild)) as GameObject;
                objectMap[(int)(startPosition.z - position.z) / Configuration.unit, (int)(position.x - startPosition.x) / Configuration.unit].GetComponent<HighData>().boxes.Add(box);
                notStaticElements.Add(box);
                notStaticElementsID.Add(BoxID);
                notStaticElementsPosition.Add(position);
            }
            for (int i = 0; i < laserGates.Count; i++)
            {
                laserGates[i].summSwitches = summSwitches;
                laserGates[i].activeSwitches = summSwitches;
                laserGates[i].setted = true;
            }
        }
        catch (Exception e)
        {
            Debug.Log("The map could not be read:");
            Debug.Log(e.Message);
        }
    }

    private void Update()
    {
        if (count == 0 && !used)
        {
            used = true;
            Animation anim = door.GetComponent<Animation>();
            anim[doorAnimName].speed = doorOpenSpeed;
            anim.Play();
            door.transform.GetChild(door.transform.childCount - 1).gameObject.SetActive(true);
            door.transform.GetComponent<DoorHighData>().opened = true;
        }
    }

    public void lessCount()
    {
        count--;
    }

    public void moreCount()
    {
        if (count == 0)
        {
            used = false;
            Animation anim = door.GetComponent<Animation>();
            anim[doorAnimName].speed = -doorOpenSpeed;
            anim[doorAnimName].time = anim[doorAnimName].length;
            anim.Play(doorAnimName);
            door.transform.GetChild(door.transform.childCount - 1).gameObject.SetActive(false);
            door.transform.GetComponent<DoorHighData>().opened = false;
        }
        count++;
    }

    public void restartMap(int number)
    {
        bridgeElements.Clear();

        for (int i = 0; i < laserGates.Count; i++)
        {
            laserGates[i].GetComponent<LaserGate>().resetLaserGate();
        }

        charMatrixPositionX = originMatrixPositionX;
        charMatrixPositionZ = originMatrixPositionZ;
        count = 0;

        for (int i = 0; i < objectMap.GetLength(0); i++)
        {
            for (int j = 0; j < objectMap.GetLength(1); j++)
            {
                objectMap[i, j].GetComponent<HighData>().boxes.Clear();
            }
        }

        for (int i = notStaticElements.Count - 1; i > -1; i--)
        {
            GameObject.Destroy(notStaticElements[i]);
        }

        used = false;

        door = Instantiate(doorModel, doorPosition, Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
        objectMap[(int)(startPosition.z - doorPosition.z) / Configuration.unit, (int)(doorPosition.x - startPosition.x) / Configuration.unit] = door;
        notStaticElements.Add(door);

        for (int i = 0; i < notStaticElementsID.Count; i++)
        {
            switch (notStaticElementsID[i])
            {
                case 2:
                    GameObject trap = Instantiate(trapModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(TrapChild)) as GameObject;
                    notStaticElements.Add(trap);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit] = trap;
                    break;
                case 3:
                    GameObject doorButton = Instantiate(buttonModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(ButtonChild)) as GameObject;
                    notStaticElements.Add(doorButton);
                    count++;
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit] = doorButton;
                    break;
                case 10:
                    GameObject box = Instantiate(boxModel, notStaticElementsPosition[i], Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(BoxChild)) as GameObject;
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit].GetComponent<HighData>().boxes.Add(box);
                    notStaticElements.Add(box);
                    break;
                case -2:
                    GameObject Key = Instantiate(KeyModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
                    notStaticElements.Add(Key);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit] = Key;
                    break;
                case 5:
                    GameObject BridgeMaker = Instantiate(BridgeMakeModel, notStaticElementsPosition[i], Quaternion.AngleAxis(0, Vector3.right), parent.transform) as GameObject;
                    notStaticElements.Add(BridgeMaker);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit] = BridgeMaker;
                    break;
                case 6:
                    GameObject BridgeElement = Instantiate(BridgeElementModel, notStaticElementsPosition[i], Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(BridgeChild));
                    notStaticElements.Add(BridgeElement);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit] = BridgeElement;
                    bridgeElements.Add(BridgeElement.GetComponent<RiseElement>());
                    break;
                case 9:
                    GameObject laserSwitch = Instantiate(laserSwitchModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(LaserSwitchChild));
                    notStaticElements.Add(laserSwitch);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit] = laserSwitch;
                    break;
                case -4:
                    GameObject Gem = Instantiate(diamondModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
                    notStaticElements.Add(Gem);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit] = Gem;
                    break;
                default:
                    break;
            }
        }
        CurrentGameDatas.HaveItem = false;
    }

    public void RiseBridgeElements()
    {
        RiseElements();
        for (int i = 0; i < this.transform.GetChild(BridgeChild).childCount; i++)
        {
            this.transform.GetChild(BridgeChild).transform.GetChild(i).GetComponent<HighData>().baseHigh++;
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
        else if (Joe.transform.forward == Vector3.right)
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
        if (objectMap[z, x].GetComponent<HighData>().HeightCalculate() - objectMap[charMatrixPositionZ, charMatrixPositionX].GetComponent<HighData>().HeightCalculate() <= 0)
        {
            int diff = objectMap[z, x].GetComponent<HighData>().HeightCalculate() - objectMap[charMatrixPositionZ, charMatrixPositionX].GetComponent<HighData>().HeightCalculate();
            Configuration.fallSpeed = -diff * Configuration.unit * Configuration.fallSpeedBoost;
            Joe.GetComponent<JoeCommandControl>().GoForward();
            charMatrixPositionX = x;
            charMatrixPositionZ = z;
        }
        else if (objectMap[z, x].GetComponent<HighData>().HeightCalculate() - objectMap[charMatrixPositionZ, charMatrixPositionX].GetComponent<HighData>().HeightCalculate() == 1)
        {
            if (objectMap[z, x].GetComponent<HighData>().boxes.Count > 0)
            {
                //there is a box, and he can push it
                if (objectMap[z + reCalc[1], x + reCalc[0]].GetComponent<HighData>().HeightCalculate() - objectMap[z, x].GetComponent<HighData>().HeightCalculate() < 0)
                {
                    objectMap[z, x].GetComponent<HighData>().boxes[objectMap[z, x].GetComponent<HighData>().boxes.Count - 1].GetComponent<BoxController>().MoveToThere(Joe.transform.forward);
                    objectMap[z + reCalc[1], x + reCalc[0]].GetComponent<HighData>().boxes.Add(objectMap[z, x].GetComponent<HighData>().boxes[objectMap[z, x].GetComponent<HighData>().boxes.Count - 1]);
                    objectMap[z, x].GetComponent<HighData>().boxes.RemoveAt(objectMap[z, x].GetComponent<HighData>().boxes.Count - 1);
                    Joe.GetComponent<JoeCommandControl>().GoForward();
                    charMatrixPositionX = x;
                    charMatrixPositionZ = z;
                }
                //there is a box, but next element as high as it, or higher
                else
                {
                    return; //TODO: animation
                }

            }
            else
            {
                return; //TODO: animation: no box
            }
        }
        else
        {
            return; //TODO: animation
        }
    }

    public void LaserSwitchOff()
    {
        for (int i = 0; i < laserGates.Count; i++)
        {
            laserGates[i].GetComponent<LaserGate>().SwitchedOffOne();
        }
    }

    public void LaserSwitchOn()
    {
        for (int i = 0; i < laserGates.Count; i++)
        {
            laserGates[i].GetComponent<LaserGate>().SwitchedOnOne();
        }
    }

    public void Activate()
    {
        int x = charMatrixPositionX;
        int z = charMatrixPositionZ;
        SolvedButton sbutton = objectMap[z, x].GetComponent<SolvedButton>();
        if (sbutton != null)
        {
            sbutton.ActivateButton();
        }
    }

    private Map initMap(int number)
    {
        Map map = MapCollection.ReadMap(number);
        Joe.transform.position = map.charPosition;
        actMap = new int[map.heigth, map.width];
        originalMap = new int[map.heigth, map.width];
        objectMap = new GameObject[map.heigth, map.width];
        startPosition = map.startPosition;
        charMatrixPositionZ = (int)(startPosition.z - map.charPosition.z) / Configuration.unit;
        charMatrixPositionX = (int)(map.charPosition.x - startPosition.x) / Configuration.unit;
        originMatrixPositionZ = charMatrixPositionZ;
        originMatrixPositionX = charMatrixPositionX;

        CurrentGameDatas.Scarab3PartCmd = map.Scarab3PartNumber;
        CurrentGameDatas.Scarab2PartCmd = map.Scarab2PartNumber;
        CurrentGameDatas.solvedMap.itemType = map.itemType;
        return map;
    }

    public void RiseElements()
    {
        for(int i=0; i< bridgeElements.Count; i++)
        {
            bridgeElements[i].Rise();
        }
    }
}
