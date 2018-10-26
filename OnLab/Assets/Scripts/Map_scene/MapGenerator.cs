using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private static MapGenerator instance = null;

    private GameObject mapGeneratorGO;
    private int mapNumber = 0;
    private int buttonCount = 0;
    private Vector3 startPosition;

    [Header("Character")]
    [SerializeField]
    private GameObject Joe;
    private JoeCommandControl JoeControl;
    private Vector3 joePosition;
    private Vector3 joeForward;
    private int charMatrixPositionX;
    private int charMatrixPositionZ;

    private int originMatrixPositionX;
    private int originMatrixPositionZ;

    [Header("Models for Instantiate")]
    [SerializeField]
    private GameObject gemModel;
    [SerializeField]
    private GameObject doorEdgeModel;
    [SerializeField]
    private GameObject keyModel;
    [SerializeField]
    private GameObject relicModel;
    [SerializeField]
    private GameObject doorModel;
    [SerializeField]
    private GameObject columnModel;
    [SerializeField]
    private GameObject edgeModel;
    [SerializeField]
    private GameObject trapModel;
    [SerializeField]
    private GameObject buttonModel;
    [SerializeField]
    private GameObject holeModel;
    [SerializeField]
    private GameObject stoneLifterModel;
    [SerializeField]
    private GameObject risingStoneModel;
    [SerializeField]
    private GameObject laserGateModel;
    [SerializeField]
    private GameObject laserGateEdgeModel;
    [SerializeField]
    private GameObject laserSwitchModel;
    [SerializeField]
    private GameObject boxModel;

    private MapElement[,] actMap;
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

    private readonly float columnGround = -90;
    private readonly float holeGround = -65;
    private readonly float risingStoneGround = -65;
    private readonly float stoneLifterGround = -65;
    private readonly float doorGround = -90;
    private readonly float doorEdgeGround = -90;
    private readonly float keyGround = -90;
    private readonly float gemGround = -90;
    private readonly float relicGround = -90;
    private readonly float trapGround = -90;
    private readonly float buttonGround = 0;
    private readonly float edgeGround = 0;
    private readonly float laserGateGround = -90;
    private readonly float laserGateEdgeGround = -90;
    private readonly float laserSwitchGround = -90;

    private List<GameObject> notStaticElements = new List<GameObject>();
    private List<MapElement> notStaticElementsID = new List<MapElement>();
    private List<Vector3> notStaticElementsPosition = new List<Vector3>();
    private List<BoxCollider> boxesCollider = new List<BoxCollider>();

    private List<LaserGate> laserGates = new List<LaserGate>();
    private List<RiseElement> RisingStones = new List<RiseElement>();
    private List<Door> doors = new List<Door>();

    //Del it
    public bool RiseGecc = false;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }

    public static MapGenerator GetMapGenerator()
    {
        return instance;
    }

    void Start()
    {
        CheckGameObjects();

        mapGeneratorGO = gameObject;
        mapNumber = ActualMapData.mapNumber;
        CreateMap(mapNumber);
    }

    //Del it 
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
        buttonCount = map.buttonCount;

        for (int i = 0; i < map.heigth; i++)
        {
            for (int j = 0; j < map.width; j++)
            {

                Vector3 placePosition = startPosition + new Vector3(SharedData.widhtUnit * j, 0, i * -1 * SharedData.widhtUnit);
                MapElement id = map.mapMatrix[i, j];
                actMap[i, j] = id;
                switch (id)
                {
                    case MapElement.Column:
                        GameObject brick = Instantiate(columnModel, placePosition + new Vector3(0, columnGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(ColumnChild));
                        objectMap[i, j] = brick;
                        break;
                    case MapElement.Edge:
                        GameObject edge = Instantiate(edgeModel, placePosition + new Vector3(0, edgeGround, 0), Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(EdgeChild));
                        objectMap[i, j] = edge;
                        break;
                    case MapElement.Trap:
                        GameObject trap = Instantiate(trapModel, placePosition + new Vector3(0, trapGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(TrapChild)) as GameObject;
                        objectMap[i, j] = trap;
                        AddToNotStaticElements(trap, new Vector3(placePosition.x, placePosition.y + trapGround, placePosition.z), MapElement.Trap);
                        break;
                    case MapElement.Button:
                        GameObject Button = Instantiate(buttonModel, placePosition + new Vector3(0, buttonGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(ButtonChild)) as GameObject;
                        objectMap[i, j] = Button;
                        AddToNotStaticElements(Button, new Vector3(placePosition.x, placePosition.y + buttonGround, placePosition.z), MapElement.Button);
                        break;
                    case MapElement.Hole:
                        GameObject hole = Instantiate(holeModel, placePosition + new Vector3(0, holeGround, 0), Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(ColumnChild));
                        objectMap[i, j] = hole;
                        break;
                    case MapElement.Door:
                        GameObject door = Instantiate(doorModel, placePosition + new Vector3(0, doorGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(DoorChild)) as GameObject;
                        objectMap[i, j] = door;
                        AddToNotStaticElements(door, new Vector3(placePosition.x, placePosition.y + doorGround, placePosition.z), MapElement.Door);
                        Door doorScript = door.GetComponent<Door>();
                        doorScript.SetCount(map.buttonCount);
                        doors.Add(door.GetComponent<Door>());
                        break;
                    case MapElement.Key:
                        GameObject Key = Instantiate(keyModel, placePosition + new Vector3(0, keyGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform) as GameObject;
                        objectMap[i, j] = Key;
                        AddToNotStaticElements(Key, new Vector3(placePosition.x, placePosition.y + keyGround, placePosition.z), MapElement.Key);
                        break;
                    case MapElement.DoorEdge:
                        GameObject doorEdge = Instantiate(doorEdgeModel, placePosition + new Vector3(0, doorEdgeGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(DoorChild)) as GameObject;
                        objectMap[i, j] = doorEdge;
                        break;
                    case MapElement.StoneLifter:
                        GameObject StoneLifter = Instantiate(stoneLifterModel, placePosition + new Vector3(0, stoneLifterGround, 0), Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(RisingStoneChild)) as GameObject;
                        objectMap[i, j] = StoneLifter;
                        AddToNotStaticElements(StoneLifter, placePosition + new Vector3(0, stoneLifterGround, 0), MapElement.StoneLifter);
                        break;
                    case MapElement.RisingStone:
                        GameObject RisingStone = Instantiate(risingStoneModel, placePosition + new Vector3(0, risingStoneGround, 0), Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(RisingStoneChild));
                        objectMap[i, j] = RisingStone;
                        AddToNotStaticElements(RisingStone, placePosition + new Vector3(0, risingStoneGround, 0), MapElement.RisingStone);
                        RisingStones.Add(RisingStone.GetComponent<RiseElement>());
                        break;
                    case MapElement.LaserGate:
                        GameObject laserGate = Instantiate(laserGateModel, placePosition + new Vector3(0, laserGateGround, 0), Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(LaserGateChild)) as GameObject;
                        objectMap[i, j] = laserGate;
                        LaserGate laserGateScript = laserGate.GetComponent<LaserGate>();
                        laserGateScript.SetLasers(map.laserSwitchCount, laserGateGround);
                        laserGates.Add(laserGateScript);
                        break;
                    case MapElement.LaserGateEdge:
                        GameObject laserGateEdge = Instantiate(laserGateEdgeModel, placePosition + new Vector3(0, laserGateEdgeGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(LaserGateChild)) as GameObject;
                        objectMap[i, j] = laserGateEdge;
                        break;
                    case MapElement.LaserSwitch:
                        GameObject laserSwitch = Instantiate(laserSwitchModel, placePosition + new Vector3(0, laserSwitchGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(LaserSwitchChild)) as GameObject;
                        objectMap[i, j] = laserSwitch;
                        AddToNotStaticElements(laserSwitch, new Vector3(placePosition.x, placePosition.y + laserSwitchGround, placePosition.z), MapElement.LaserSwitch);
                        break;
                    case MapElement.Gem:
                        GameObject Gem = Instantiate(gemModel, placePosition + new Vector3(0, gemGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform) as GameObject;
                        objectMap[i, j] = Gem;
                        AddToNotStaticElements(Gem, new Vector3(placePosition.x, placePosition.y + gemGround, placePosition.z), MapElement.Gem);
                        break;
                    case MapElement.Relic:
                        GameObject Relic = Instantiate(relicModel, placePosition + new Vector3(0, relicGround, 0), Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform) as GameObject;
                        objectMap[i, j] = Relic;
                        AddToNotStaticElements(Relic, new Vector3(placePosition.x, placePosition.y + relicGround, placePosition.z), MapElement.Gem);
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
            GameObject box = Instantiate(boxModel, position, Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(BoxChild)) as GameObject;
            objectMap[(int)(startPosition.z - position.z) / SharedData.widhtUnit, (int)(position.x - startPosition.x) / SharedData.widhtUnit].GetComponent<HighData>().AddBox(box);

            Transform onIt =  objectMap[(int)(startPosition.z - position.z) / SharedData.widhtUnit, (int)(position.x - startPosition.x) / SharedData.widhtUnit].transform;
            int onItNumber = objectMap[(int)(startPosition.z - position.z) / SharedData.widhtUnit, (int)(position.x - startPosition.x) / SharedData.widhtUnit].GetComponent<HighData>().GetBoxCount();
            box.GetComponent<BoxController>().InitOnIt(onIt, onItNumber);

            boxesCollider.Add(box.GetComponent<BoxCollider>());
            AddToNotStaticElements(box, position, MapElement.Box);
        }
    }

    public void RestartMap(int number)
    {
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
            Destroy(notStaticElements[i]);
        }

        for (int i = 0; i < notStaticElementsID.Count; i++)
        {
            switch (notStaticElementsID[i])
            {
                case MapElement.Trap:
                    GameObject trap = Instantiate(trapModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(TrapChild)) as GameObject;
                    notStaticElements.Add(trap);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit] = trap;
                    break;
                case MapElement.Button:
                    GameObject Button = Instantiate(buttonModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(ButtonChild)) as GameObject;
                    notStaticElements.Add(Button);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit] = Button;
                    break;
                case MapElement.Box:
                    GameObject box = Instantiate(boxModel, notStaticElementsPosition[i], Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(BoxChild)) as GameObject;
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit].GetComponent<HighData>().AddBox(box);
                    Transform onIt = objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit].GetComponent<HighData>().transform;
                    int onItNumber = objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit].GetComponent<HighData>().GetBoxCount();
                    box.GetComponent<BoxController>().InitOnIt(onIt, onItNumber);
                    notStaticElements.Add(box);
                    break;
                case MapElement.Key:
                    GameObject Key = Instantiate(keyModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform) as GameObject;
                    notStaticElements.Add(Key);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit] = Key;
                    break;
                case MapElement.StoneLifter:
                    GameObject StoneLifter = Instantiate(stoneLifterModel, notStaticElementsPosition[i], Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(RisingStoneChild)) as GameObject;
                    notStaticElements.Add(StoneLifter);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit] = StoneLifter;
                    break;
                case MapElement.RisingStone:
                    GameObject RisingStone = Instantiate(risingStoneModel, notStaticElementsPosition[i], Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(RisingStoneChild));
                    notStaticElements.Add(RisingStone);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit] = RisingStone;
                    RisingStones.Add(RisingStone.GetComponent<RiseElement>());
                    break;
                case MapElement.LaserSwitch:
                    GameObject laserSwitch = Instantiate(laserSwitchModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(LaserSwitchChild));
                    notStaticElements.Add(laserSwitch);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit] = laserSwitch;
                    break;
                case MapElement.Gem:
                    GameObject Gem = Instantiate(gemModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform) as GameObject;
                    notStaticElements.Add(Gem);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit] = Gem;
                    break;
                case MapElement.Door:
                    GameObject door = Instantiate(doorModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform.GetChild(DoorChild)) as GameObject;
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit] = door;
                    notStaticElements.Add(door);
                    Door doorScript = door.GetComponent<Door>();
                    doorScript.SetCount(buttonCount);
                    doors.Add(doorScript);
                    break;
                case MapElement.Relic:
                    GameObject Relic = Instantiate(relicModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), mapGeneratorGO.transform) as GameObject;
                    notStaticElements.Add(Relic);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit] = Relic;
                    break;
                default:
                    break;
            }
        }

        ActualMapData.HaveItem = false;
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
        CanGoForward result = objectMap[z, x].GetComponent<HighData>().HeightCalculateTo(fromHeight);
        if (result == CanGoForward.Go)
        {
            JoeControl.GoForward();
            charMatrixPositionX = x;
            charMatrixPositionZ = z;
        }
        else if (result == CanGoForward.OneDiff)
        {
            //there is a box, and he can push it
            int fromHeightBox = objectMap[z, x].GetComponent<HighData>().HeighCalculateFrom();
            bool boxPushResult = objectMap[z + reCalc[1], x + reCalc[0]].GetComponent<HighData>().HeightCalculateToBox(fromHeightBox-1);
            if (boxPushResult)
            {
                objectMap[z, x].GetComponent<HighData>().GetTopBox().GetComponent<BoxController>().MoveToThere(Joe.transform.forward);
                objectMap[z + reCalc[1], x + reCalc[0]].GetComponent<HighData>().AddBox(objectMap[z, x].GetComponent<HighData>().GetTopBox());

                Transform onIt = objectMap[z + reCalc[1], x + reCalc[0]].GetComponent<HighData>().transform;
                int onItNumber = objectMap[z + reCalc[1], x + reCalc[0]].GetComponent<HighData>().GetBoxCount();
                objectMap[z, x].GetComponent<HighData>().GetTopBox().GetComponent<BoxController>().InitOnIt(onIt, onItNumber);

                objectMap[z, x].GetComponent<HighData>().RemoveTopBox();
                JoeControl.GoForward();
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

        actMap = new MapElement[map.heigth, map.width];
        objectMap = new GameObject[map.heigth, map.width];

        startPosition = map.startPosition;

        charMatrixPositionZ = (int)(startPosition.z - map.charPosition.z) / SharedData.widhtUnit;
        charMatrixPositionX = (int)(map.charPosition.x - startPosition.x) / SharedData.widhtUnit;

        originMatrixPositionZ = charMatrixPositionZ;
        originMatrixPositionX = charMatrixPositionX;

        ActualMapData.Scarab3PartCmd = map.Scarab3PartNumber;
        ActualMapData.Scarab2PartCmd = map.Scarab2PartNumber;
        ActualMapData.solvedMap.ItemType = map.itemType;

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

    void AddToNotStaticElements(GameObject item, Vector3 position, MapElement mapElement)
    {
        notStaticElements.Add(item);
        notStaticElementsID.Add(mapElement);
        notStaticElementsPosition.Add(position);
    }

    public void CharacterTurnLeft()
    {
        JoeControl.TurnLeft();
    }

    public void CharacterTurnRight()
    {
        JoeControl.TurnRight();
    }

    private void CheckGameObjects()
    {
        JoeControl = Joe.GetComponent<JoeCommandControl>();
        if (JoeControl == null)
        {
            Debug.LogError("MapGenerator: Joe has to have JoeCommandControl!");
        }
        if (gemModel.GetComponent<HighData>() == null)
        {
            Debug.LogError("MapGenerator: gemModel has to have HighData script!");
        }
        if (doorEdgeModel.GetComponent<HighData>() == null)
        {
            Debug.LogError("MapGenerator: doorEdgeModel has to have HighData script!");
        }
        if (keyModel.GetComponent<HighData>() == null)
        {
            Debug.LogError("MapGenerator: keyModel has to have HighData script!");
        }
        if (doorModel.GetComponent<HighData>() == null)
        {
            Debug.LogError("MapGenerator: doorModel has to have HighData script!");
        }
        if (columnModel.GetComponent<HighData>() == null)
        {
            Debug.LogError("MapGenerator: columnModel has to have HighData script!");
        }
        if (edgeModel.GetComponent<HighData>() == null)
        {
            Debug.LogError("MapGenerator: edgeModel has to have HighData script!");
        }
        if (trapModel.GetComponent<HighData>() == null)
        {
            Debug.LogError("MapGenerator: trapModel has to have HighData script!");
        }
        if (buttonModel.GetComponent<HighData>() == null)
        {
            Debug.LogError("MapGenerator: buttonModel has to have HighData script!");
        }
        if (holeModel.GetComponent<HighData>() == null)
        {
            Debug.LogError("MapGenerator: holeModel has to have HighData script!");
        }
        if (stoneLifterModel.GetComponent<HighData>() == null)
        {
            Debug.LogError("MapGenerator: stoneLifterModel has to have HighData script!");
        }
        if (risingStoneModel.GetComponent<HighData>() == null)
        {
            Debug.LogError("MapGenerator: risingStoneModel has to have HighData script!");
        }
        if (laserGateModel.GetComponent<HighData>() == null)
        {
            Debug.LogError("MapGenerator: laserGateModel has to have HighData script!");
        }
        if (laserSwitchModel.GetComponent<HighData>() == null)
        {
            Debug.LogError("MapGenerator: laserSwitchModel has to have HighData script!");
        }
        if (boxModel.GetComponent<BoxController>() == null)
        {
            Debug.LogError("MapGenerator: boxModel has to have BoxController script!");
        }
        if (laserGateModel.GetComponent<LaserGate>() == null)
        {
            Debug.LogError("MapGenerator: laserGateModel has to have LaserGate script!");
        }
        if (risingStoneModel.GetComponent<RiseElement>() == null)
        {
            Debug.LogError("MapGenerator: risingStoneModel has to have RiseElement script!");
        }
        if (doorModel.GetComponent<Door>() == null)
        {
            Debug.LogError("MapGenerator: doorModel has to have Door script!");
        }
    }

}
