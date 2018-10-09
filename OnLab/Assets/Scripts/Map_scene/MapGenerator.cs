using System;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private GameObject mapGeneratorGO;
    private int mapNumber = 0;
    private int summSwitches = 0;
    private int buttonCount = 0;
    private Vector3 startPosition;

    //Character data
    public GameObject Joe;
    private Vector3 joePosition;
    private Vector3 joeForward;
    private int charMatrixPositionX;
    private int charMatrixPositionZ;

    private int originMatrixPositionX;
    private int originMatrixPositionZ;


    //ID:
    public GameObject gemModel;             // -4
    public GameObject doorEdgeModel;        // -3
    public GameObject keyModel;             // -2
    public GameObject doorModel;            // -1
    public GameObject columnModel;          //  0
    public GameObject edgeModel;            //  1   
    public GameObject trapModel;            //  2
    public GameObject buttonModel;          //  3
    public GameObject holeModel;            //  4
    public GameObject stoneLifterModel;     //  5
    public GameObject risingStoneModel;     //  6
    public GameObject laserGateModel;       //  7
    public GameObject laserGateEdgeModel;   //  8
    public GameObject laserSwitchModel;     //  9
    public GameObject boxModel;             // 10 

    private const int GemID = Configuration.GemID;
    private const int DoorEdgeID = Configuration.DoorEdgeID;
    private const int KeyID = Configuration.KeyID;
    private const int DoorID = Configuration.DoorID;
    private const int ColumnID = Configuration.ColumnID;
    private const int EdgeID = Configuration.EdgeID;
    private const int TrapID = Configuration.TrapID;
    private const int ButtonID = Configuration.ButtonID;
    private const int HoleID = Configuration.HoleID;
    private const int StoneLifterID = Configuration.StoneLifterID;
    private const int RisingStoneID = Configuration.RisingStoneID;
    private const int LaserGateID = Configuration.LaserGateID;
    private const int LaserGateEdgeID = Configuration.LaserGateEdgeID;
    private const int LaserSwitchID = Configuration.LaserSwitchID;
    private const int BoxID = Configuration.BoxID;

    private int[,] actMap;
    private GameObject[,] objectMap;

    private const int ColumnChild = 0;
    private const int ButtonChild = 1;
    private const int TrapChild = 2;
    private const int EdgeChild = 3;
    private const int BoxChild = 4;
    private const int RisingStoneChild = 5;
    private const int LaserSwitchChild = 6;
    private const int LaserGateChild = 7;
    private const int DoorChild = 8;


    private List<GameObject> notStaticElements = new List<GameObject>();
    private List<int> notStaticElementsID = new List<int>();
    private List<Vector3> notStaticElementsPosition = new List<Vector3>();
    private List<BoxCollider> boxesCollider = new List<BoxCollider>();

    private List<LaserGate> laserGates = new List<LaserGate>();
    private List<RiseElement> RisingStones = new List<RiseElement>();
    private List<Door> doors = new List<Door>();

    public bool RiseGecc = false;

    // Use this for initialization
    void Start()
    {
        mapGeneratorGO = this.gameObject;
        mapNumber = CurrentGameDatas.mapNumber;
        summSwitches = 0;
        CreateMap(mapNumber);
    }

    private void Update()
    {
        if (RiseGecc)
        {
            RiseGecc = false;
            RiseRisingStones();
        }
    }

    public void CreateMap(int number)
    {
        Map map = InitMap(number);

        for (int i = 0; i < map.heigth; i++)
        {
            for (int j = 0; j < map.width; j++)
            {

                Vector3 placePosition = startPosition + new Vector3(Configuration.unit * j, 0, i * -1 * Configuration.unit);
                int id = map.mapMatrix[i, j];
                actMap[i, j] = id;
                switch (id)
                {
                    case ColumnID:
                        GameObject brick = Instantiate(columnModel, placePosition + new Vector3(0, Configuration.columnGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(ColumnChild));
                        objectMap[i, j] = brick;
                        break;
                    case EdgeID:
                        GameObject edge = Instantiate(edgeModel, placePosition + new Vector3(0, Configuration.edgeGround, 0), Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(EdgeChild));
                        objectMap[i, j] = edge;
                        break;
                    case TrapID:
                        GameObject trap = Instantiate(trapModel, placePosition + new Vector3(0, Configuration.trapGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(TrapChild)) as GameObject;
                        objectMap[i, j] = trap;
                        AddToNotStaticElements(trap, new Vector3(placePosition.x, placePosition.y + Configuration.trapGround, placePosition.z), TrapID);
                        break;
                    case ButtonID:
                        GameObject Button = Instantiate(buttonModel, placePosition + new Vector3(0, Configuration.buttonGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(ButtonChild)) as GameObject;
                        objectMap[i, j] = Button;
                        AddToNotStaticElements(Button, new Vector3(placePosition.x, placePosition.y + Configuration.buttonGround, placePosition.z), ButtonID);
                        buttonCount++;
                        break;
                    case HoleID:
                        GameObject hole = Instantiate(holeModel, placePosition + new Vector3(0, Configuration.holeGround, 0), Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(ColumnChild));
                        objectMap[i, j] = hole;
                        break;
                    case DoorID:
                        GameObject door = Instantiate(doorModel, placePosition + new Vector3(0, Configuration.doorGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(DoorChild)) as GameObject;
                        objectMap[i, j] = door;
                        AddToNotStaticElements(door, new Vector3(placePosition.x, placePosition.y + Configuration.doorGround, placePosition.z), DoorID);
                        doors.Add(door.GetComponent<Door>());
                        break;
                    case KeyID:
                        GameObject Key = Instantiate(keyModel, placePosition + new Vector3(0, Configuration.keyGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform) as GameObject;
                        objectMap[i, j] = Key;
                        AddToNotStaticElements(Key, new Vector3(placePosition.x, placePosition.y + Configuration.keyGround, placePosition.z), KeyID);
                        break;
                    case DoorEdgeID:
                        GameObject doorEdge = Instantiate(doorEdgeModel, placePosition + new Vector3(0, Configuration.doorEdgeGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(DoorChild)) as GameObject;
                        objectMap[i, j] = doorEdge;
                        break;
                    case StoneLifterID:
                        GameObject StoneLifter = Instantiate(stoneLifterModel, placePosition + new Vector3(0, Configuration.stoneLifterGround, 0), Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(RisingStoneChild)) as GameObject;
                        objectMap[i, j] = StoneLifter;
                        AddToNotStaticElements(StoneLifter, placePosition + new Vector3(0, Configuration.stoneLifterGround, 0), StoneLifterID);
                        break;
                    case RisingStoneID:
                        GameObject RisingStone = Instantiate(risingStoneModel, placePosition + new Vector3(0, Configuration.risingStoneGround, 0), Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(RisingStoneChild));
                        objectMap[i, j] = RisingStone;
                        AddToNotStaticElements(RisingStone, placePosition + new Vector3(0, Configuration.risingStoneGround, 0), RisingStoneID);
                        RisingStones.Add(RisingStone.GetComponent<RiseElement>());
                        break;
                    case LaserGateID:
                        GameObject laserGate = Instantiate(laserGateModel, placePosition + new Vector3(0, Configuration.laserGateGround, 0), Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(LaserGateChild)) as GameObject;
                        objectMap[i, j] = laserGate;
                        laserGates.Add(laserGate.GetComponent<LaserGate>());
                        break;
                    case LaserGateEdgeID:
                        GameObject laserGateEdge = Instantiate(laserGateEdgeModel, placePosition + new Vector3(0, Configuration.laserGateEdgeGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(LaserGateChild)) as GameObject;
                        objectMap[i, j] = laserGateEdge;
                        break;
                    case LaserSwitchID:
                        GameObject laserSwitch = Instantiate(laserSwitchModel, placePosition + new Vector3(0, Configuration.laserSwitchGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(LaserSwitchChild)) as GameObject;
                        objectMap[i, j] = laserSwitch;
                        AddToNotStaticElements(laserSwitch, new Vector3(placePosition.x, placePosition.y + Configuration.laserSwitchGround, placePosition.z), LaserSwitchID);
                        summSwitches++;
                        break;
                    case GemID:
                        GameObject Gem = Instantiate(gemModel, placePosition + new Vector3(0, Configuration.keyGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform) as GameObject;
                        objectMap[i, j] = Gem;
                        AddToNotStaticElements(Gem, new Vector3(placePosition.x, placePosition.y + Configuration.keyGround, placePosition.z), GemID);
                        break;
                    default:
                        break;
                }
            }
        }

        for (int i = 0; i < doors.Count; i++)
        {
            doors[i].SetCount(buttonCount);
        }

        int boxNumber = map.boxNumber;
        for (int i = 0; i < boxNumber; i++)
        {
            Vector3 position = map.boxLocations[i];
            GameObject box = Instantiate(boxModel, position, Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(BoxChild)) as GameObject;
            objectMap[(int)(startPosition.z - position.z) / Configuration.unit, (int)(position.x - startPosition.x) / Configuration.unit].GetComponent<HighData>().AddBox(box);

            //New try
            Transform onIt =  objectMap[(int)(startPosition.z - position.z) / Configuration.unit, (int)(position.x - startPosition.x) / Configuration.unit].transform;
            int onItNumber = objectMap[(int)(startPosition.z - position.z) / Configuration.unit, (int)(position.x - startPosition.x) / Configuration.unit].GetComponent<HighData>().GetBoxCount();
            box.GetComponent<BoxController>().InitOnIt(onIt, onItNumber);
            //--

            boxesCollider.Add(box.GetComponent<BoxCollider>());
            AddToNotStaticElements(box, position, BoxID);
        }
        for (int i = 0; i < laserGates.Count; i++)
        {
            laserGates[i].SetLasers(summSwitches);
        }
    }

    public void RestartMap(int number)
    {
        Configuration.fallDistance = Configuration.unit * 2;
        //Joe.GetComponent<CharacterController>().enabled = false;
        //Joe.GetComponent<JoeCommandControl>().gravityOff = true;
        Joe.transform.position = joePosition;
        Joe.transform.forward = joeForward;
        charMatrixPositionX = originMatrixPositionX;
        charMatrixPositionZ = originMatrixPositionZ;

        RisingStones.Clear();
        doors.Clear();

        for (int i = 0; i < laserGates.Count; i++)
        {
            laserGates[i].GetComponent<LaserGate>().ResetLaserGate();
        }

        for (int i = 0; i < objectMap.GetLength(0); i++)
        {
            for (int j = 0; j < objectMap.GetLength(1); j++)
            {
                objectMap[i, j].GetComponent<HighData>().RemoveAllBox();
            }
        }

        for (int i = notStaticElements.Count - 1; i > -1; i--)
        {
            GameObject.Destroy(notStaticElements[i]);
        }

        for (int i = 0; i < notStaticElementsID.Count; i++)
        {
            switch (notStaticElementsID[i])
            {
                case TrapID:
                    GameObject trap = Instantiate(trapModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(TrapChild)) as GameObject;
                    notStaticElements.Add(trap);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit] = trap;
                    break;
                case ButtonID:
                    GameObject Button = Instantiate(buttonModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(ButtonChild)) as GameObject;
                    notStaticElements.Add(Button);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit] = Button;
                    break;
                case BoxID:
                    GameObject box = Instantiate(boxModel, notStaticElementsPosition[i], Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(BoxChild)) as GameObject;
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit].GetComponent<HighData>().AddBox(box);
                    //New
                    Transform onIt = objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit].GetComponent<HighData>().transform;
                    int onItNumber = objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit].GetComponent<HighData>().GetBoxCount();
                    box.GetComponent<BoxController>().InitOnIt(onIt, onItNumber);
                    //--
                    notStaticElements.Add(box);
                    break;
                case KeyID:
                    GameObject Key = Instantiate(keyModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform) as GameObject;
                    notStaticElements.Add(Key);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit] = Key;
                    break;
                case StoneLifterID:
                    GameObject StoneLifter = Instantiate(stoneLifterModel, notStaticElementsPosition[i], Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(RisingStoneChild)) as GameObject;
                    notStaticElements.Add(StoneLifter);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit] = StoneLifter;
                    break;
                case RisingStoneID:
                    GameObject RisingStone = Instantiate(risingStoneModel, notStaticElementsPosition[i], Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(RisingStoneChild));
                    notStaticElements.Add(RisingStone);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit] = RisingStone;
                    RisingStones.Add(RisingStone.GetComponent<RiseElement>());
                    break;
                case LaserSwitchID:
                    GameObject laserSwitch = Instantiate(laserSwitchModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(LaserSwitchChild));
                    notStaticElements.Add(laserSwitch);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit] = laserSwitch;
                    break;
                case GemID:
                    GameObject Gem = Instantiate(gemModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform) as GameObject;
                    notStaticElements.Add(Gem);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit] = Gem;
                    break;
                case DoorID:
                    GameObject door = Instantiate(doorModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(DoorChild)) as GameObject;
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / Configuration.unit, (int)(notStaticElementsPosition[i].x - startPosition.x) / Configuration.unit] = door;
                    notStaticElements.Add(door);
                    doors.Add(door.GetComponent<Door>());
                    break;
                default:
                    break;
            }
        }

        for (int i = 0; i < doors.Count; i++)
        {
            doors[i].SetCount(buttonCount);
        }
        CurrentGameDatas.HaveItem = false;
        //Joe.GetComponent<CharacterController>().enabled = true;
        //Joe.GetComponent<JoeCommandControl>().gravityOff = false;
    }

    public void RiseRisingStones()
    {
        for (int i = 0; i < RisingStones.Count; i++)
        {
            RisingStones[i].Rise();
        }
    }

    public void RightToMove()
    {
        int x = charMatrixPositionX;
        int z = charMatrixPositionZ;
        int[] reCalc = new int[2];

        //Bugg
        /*reCalc[0] = Convert.ToInt32(Joe.transform.GetComponent<JoeCommandControl>().joeForward.x);
        reCalc[1] = -Convert.ToInt32(Joe.transform.GetComponent<JoeCommandControl>().joeForward.z);
        Debug.Log(reCalc[0] + " " + reCalc[1]);
        x += reCalc[0];
        z += reCalc[1];*/
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
        int fromHeight = objectMap[charMatrixPositionZ, charMatrixPositionX].GetComponent<HighData>().HeighCalculateFrom();
        Configuration.CanGoForward result = objectMap[z, x].GetComponent<HighData>().HeightCalculateTo(fromHeight);
        if (result == Configuration.CanGoForward.Go)
        {
            Joe.GetComponent<JoeCommandControl>().GoForward();
            charMatrixPositionX = x;
            charMatrixPositionZ = z;
        }
        else if (result == Configuration.CanGoForward.OneDiff)
        {
            //there is a box, and he can push it
            int fromHeightBox = objectMap[z, x].GetComponent<HighData>().HeighCalculateFrom();
            bool boxPushResult = objectMap[z + reCalc[1], x + reCalc[0]].GetComponent<HighData>().HeightCalculateToBox(fromHeightBox-1);
            if (boxPushResult)
            {
                objectMap[z, x].GetComponent<HighData>().GetTopBox().GetComponent<BoxController>().MoveToThere(Joe.transform.forward);
                objectMap[z + reCalc[1], x + reCalc[0]].GetComponent<HighData>().AddBox(objectMap[z, x].GetComponent<HighData>().GetTopBox());

                //New:
                Transform onIt = objectMap[z + reCalc[1], x + reCalc[0]].GetComponent<HighData>().transform;
                int onItNumber = objectMap[z + reCalc[1], x + reCalc[0]].GetComponent<HighData>().GetBoxCount();
                objectMap[z, x].GetComponent<HighData>().GetTopBox().GetComponent<BoxController>().InitOnIt(onIt, onItNumber);

                objectMap[z, x].GetComponent<HighData>().RemoveTopBox();
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
        ButtonElement sbutton = objectMap[z, x].GetComponent<ButtonElement>();
        if (sbutton != null)
        {
            sbutton.ActivateButton();
        }
    }

    private Map InitMap(int number)
    {
        Map map = MapCollection.ReadMap(number);
        Joe.transform.position = map.charPosition;
        joePosition = map.charPosition;
        Joe.transform.forward = map.charForward;
        joeForward = map.charForward;
        //Joe.GetComponent<JoeCommandControl>().joeForward = map.charForward;
        actMap = new int[map.heigth, map.width];
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

    public void ButtonActivated()
    {
        for (int i = 0; i < doors.Count; i++)
        {
            doors[i].LessCount();
        }
    }

    public void ButtonDeactivated()
    {
        for (int i = 0; i < doors.Count; i++)
        {
            doors[i].MoreCount();
        }
    }

    void AddToNotStaticElements(GameObject item, Vector3 position, int id)
    {
        notStaticElements.Add(item);
        notStaticElementsID.Add(id);
        notStaticElementsPosition.Add(position);
    }
}
