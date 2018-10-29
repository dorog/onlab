using System;
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
    private HighData gemModel;
    [SerializeField]
    private HighData doorEdgeModel;
    [SerializeField]
    private HighData keyModel;
    [SerializeField]
    private HighData relicModel;
    [SerializeField]
    private HighData doorModel;
    [SerializeField]
    private HighData columnModel;
    [SerializeField]
    private HighData edgeModel;
    [SerializeField]
    private HighData trapModel;
    [SerializeField]
    private HighData buttonModel;
    [SerializeField]
    private HighData holeModel;
    [SerializeField]
    private HighData stoneLifterModel;
    [SerializeField]
    private HighData risingStoneModel;
    [SerializeField]
    private HighData laserGateModel;
    [SerializeField]
    private HighData laserGateEdgeModel;
    [SerializeField]
    private HighData laserSwitchModel;
    [SerializeField]
    private HighData lowRisingStoneModel;
    [SerializeField]
    private BoxController boxModel;

    private MapElement[,] actMap;
    private GameObject[,] objectMap;

    [Header("Model's parents")]
    [SerializeField]
    private Transform ColumnsParent;
    [SerializeField]
    private Transform ButtonsParent;
    [SerializeField]
    private Transform TrapsParent;
    [SerializeField]
    private Transform EdgesParent;
    [SerializeField]
    private Transform BoxesParent;
    [SerializeField]
    private Transform RisingStonesParent;
    [SerializeField]
    private Transform LaserSwitchesParent;
    [SerializeField]
    private Transform LaserGatesParent;
    [SerializeField]
    private Transform DoorsParent;

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
                        GameObject brick = Instantiate(columnModel.gameObject, placePosition + new Vector3(0, columnModel.ModelGround, 0), columnModel.GetQuat(), ColumnsParent);
                        objectMap[i, j] = brick;
                        break;
                    case MapElement.Edge:
                        GameObject edge = Instantiate(edgeModel.gameObject, placePosition + new Vector3(0, edgeModel.ModelGround, 0), edgeModel.GetQuat(), EdgesParent);
                        objectMap[i, j] = edge;
                        break;
                    case MapElement.Trap:
                        GameObject trap = Instantiate(trapModel.gameObject, placePosition + new Vector3(0, trapModel.ModelGround, 0), trapModel.GetQuat(), TrapsParent) as GameObject;
                        objectMap[i, j] = trap;
                        AddToNotStaticElements(trap, new Vector3(placePosition.x, placePosition.y + trapModel.ModelGround, placePosition.z), MapElement.Trap);
                        break;
                    case MapElement.Button:
                        GameObject Button = Instantiate(buttonModel.gameObject, placePosition + new Vector3(0, buttonModel.ModelGround, 0), buttonModel.GetQuat(), ButtonsParent) as GameObject;
                        objectMap[i, j] = Button;
                        AddToNotStaticElements(Button, new Vector3(placePosition.x, placePosition.y + buttonModel.ModelGround, placePosition.z), MapElement.Button);
                        break;
                    case MapElement.Hole:
                        GameObject hole = Instantiate(holeModel.gameObject, placePosition + new Vector3(0, holeModel.ModelGround, 0), holeModel.GetQuat(), ColumnsParent);
                        objectMap[i, j] = hole;
                        break;
                    case MapElement.Door:
                        GameObject door = Instantiate(doorModel.gameObject, placePosition + new Vector3(0, doorModel.ModelGround, 0), doorModel.GetQuat(), DoorsParent) as GameObject;
                        objectMap[i, j] = door;
                        AddToNotStaticElements(door, new Vector3(placePosition.x, placePosition.y + doorModel.ModelGround, placePosition.z), MapElement.Door);
                        Door doorScript = door.GetComponent<Door>();
                        doorScript.SetCount(map.buttonCount);
                        doors.Add(door.GetComponent<Door>());
                        break;
                    case MapElement.Key:
                        GameObject Key = Instantiate(keyModel.gameObject, placePosition + new Vector3(0, keyModel.ModelGround, 0), keyModel.GetQuat(), mapGeneratorGO.transform) as GameObject;
                        objectMap[i, j] = Key;
                        AddToNotStaticElements(Key, new Vector3(placePosition.x, placePosition.y + keyModel.ModelGround, placePosition.z), MapElement.Key);
                        break;
                    case MapElement.DoorEdge:
                        GameObject doorEdge = Instantiate(doorEdgeModel.gameObject, placePosition + new Vector3(0, doorEdgeModel.ModelGround, 0), doorEdgeModel.GetQuat(), DoorsParent) as GameObject;
                        objectMap[i, j] = doorEdge;
                        break;
                    case MapElement.StoneLifter:
                        GameObject StoneLifter = Instantiate(stoneLifterModel.gameObject, placePosition + new Vector3(0, stoneLifterModel.ModelGround, 0), stoneLifterModel.GetQuat(), RisingStonesParent) as GameObject;
                        objectMap[i, j] = StoneLifter;
                        AddToNotStaticElements(StoneLifter, placePosition + new Vector3(0, stoneLifterModel.ModelGround, 0), MapElement.StoneLifter);
                        break;
                    case MapElement.RisingStone:
                        GameObject RisingStone = Instantiate(risingStoneModel.gameObject, placePosition + new Vector3(0, risingStoneModel.ModelGround, 0), risingStoneModel.GetQuat(), RisingStonesParent);
                        objectMap[i, j] = RisingStone;
                        AddToNotStaticElements(RisingStone, placePosition + new Vector3(0, risingStoneModel.ModelGround, 0), MapElement.RisingStone);
                        RisingStones.Add(RisingStone.GetComponent<RiseElement>());
                        break;
                    case MapElement.LowRisingStone:
                        GameObject LowRisingStone = Instantiate(lowRisingStoneModel.gameObject, placePosition + new Vector3(0, lowRisingStoneModel.ModelGround, 0), lowRisingStoneModel.GetQuat(), RisingStonesParent);
                        objectMap[i, j] = LowRisingStone;
                        AddToNotStaticElements(LowRisingStone, placePosition + new Vector3(0, lowRisingStoneModel.ModelGround, 0), MapElement.LowRisingStone);
                        RisingStones.Add(LowRisingStone.GetComponent<RiseElement>());
                        break;
                    case MapElement.LaserGate:
                        GameObject laserGate = Instantiate(laserGateModel.gameObject, placePosition + new Vector3(0, laserGateModel.ModelGround, 0), laserGateModel.GetQuat(), LaserGatesParent) as GameObject;
                        objectMap[i, j] = laserGate;
                        LaserGate laserGateScript = laserGate.GetComponent<LaserGate>();
                        laserGateScript.SetLasers(map.laserSwitchCount, laserGateModel.ModelGround);
                        laserGates.Add(laserGateScript);
                        break;
                    case MapElement.LaserGateEdge:
                        GameObject laserGateEdge = Instantiate(laserGateEdgeModel.gameObject, placePosition + new Vector3(0, laserGateEdgeModel.ModelGround, 0), laserGateEdgeModel.GetQuat(), LaserGatesParent) as GameObject;
                        objectMap[i, j] = laserGateEdge;
                        break;
                    case MapElement.LaserSwitch:
                        GameObject laserSwitch = Instantiate(laserSwitchModel.gameObject, placePosition + new Vector3(0, laserSwitchModel.ModelGround, 0), laserSwitchModel.GetQuat(), LaserSwitchesParent) as GameObject;
                        objectMap[i, j] = laserSwitch;
                        AddToNotStaticElements(laserSwitch, new Vector3(placePosition.x, placePosition.y + laserSwitchModel.ModelGround, placePosition.z), MapElement.LaserSwitch);
                        break;
                    case MapElement.Gem:
                        GameObject Gem = Instantiate(gemModel.gameObject, placePosition + new Vector3(0, gemModel.ModelGround, 0), gemModel.GetQuat(), mapGeneratorGO.transform) as GameObject;
                        objectMap[i, j] = Gem;
                        AddToNotStaticElements(Gem, new Vector3(placePosition.x, placePosition.y + gemModel.ModelGround, placePosition.z), MapElement.Gem);
                        break;
                    case MapElement.Relic:
                        GameObject Relic = Instantiate(relicModel.gameObject, placePosition + new Vector3(0, relicModel.ModelGround, 0), relicModel.GetQuat(), mapGeneratorGO.transform) as GameObject;
                        objectMap[i, j] = Relic;
                        AddToNotStaticElements(Relic, new Vector3(placePosition.x, placePosition.y + relicModel.ModelGround, placePosition.z), MapElement.Relic);
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
            GameObject box = Instantiate(boxModel.gameObject, position, boxModel.GetQuat(), BoxesParent) as GameObject;
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

        for(int i=0; i<boxesCollider.Count; i++)
        {
            boxesCollider[i].enabled = false;
        }
        boxesCollider.Clear();

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
                    GameObject trap = Instantiate(trapModel.gameObject, notStaticElementsPosition[i], trapModel.GetQuat(), TrapsParent) as GameObject;
                    notStaticElements.Add(trap);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit] = trap;
                    break;
                case MapElement.Button:
                    GameObject Button = Instantiate(buttonModel.gameObject, notStaticElementsPosition[i], buttonModel.GetQuat(), ButtonsParent) as GameObject;
                    notStaticElements.Add(Button);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit] = Button;
                    break;
                case MapElement.Box:
                    GameObject box = Instantiate(boxModel.gameObject, notStaticElementsPosition[i], boxModel.GetQuat(), BoxesParent) as GameObject;
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit].GetComponent<HighData>().AddBox(box);
                    Transform onIt = objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit].GetComponent<HighData>().transform;
                    int onItNumber = objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit].GetComponent<HighData>().GetBoxCount();
                    box.GetComponent<BoxController>().InitOnIt(onIt, onItNumber);
                    boxesCollider.Add(box.GetComponent<BoxCollider>());
                    notStaticElements.Add(box);
                    break;
                case MapElement.Key:
                    GameObject Key = Instantiate(keyModel.gameObject, notStaticElementsPosition[i], keyModel.GetQuat(), mapGeneratorGO.transform) as GameObject;
                    notStaticElements.Add(Key);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit] = Key;
                    break;
                case MapElement.StoneLifter:
                    GameObject StoneLifter = Instantiate(stoneLifterModel.gameObject, notStaticElementsPosition[i], stoneLifterModel.GetQuat(), RisingStonesParent) as GameObject;
                    notStaticElements.Add(StoneLifter);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit] = StoneLifter;
                    break;
                case MapElement.RisingStone:
                    GameObject RisingStone = Instantiate(risingStoneModel.gameObject, notStaticElementsPosition[i], risingStoneModel.GetQuat(), RisingStonesParent);
                    notStaticElements.Add(RisingStone);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit] = RisingStone;
                    RisingStones.Add(RisingStone.GetComponent<RiseElement>());
                    break;
                case MapElement.LowRisingStone:
                    GameObject LowRisingStone = Instantiate(lowRisingStoneModel.gameObject, notStaticElementsPosition[i], lowRisingStoneModel.GetQuat(), RisingStonesParent);
                    notStaticElements.Add(LowRisingStone);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit] = LowRisingStone;
                    RisingStones.Add(LowRisingStone.GetComponent<RiseElement>());
                    break;
                case MapElement.LaserSwitch:
                    GameObject laserSwitch = Instantiate(laserSwitchModel.gameObject, notStaticElementsPosition[i], laserSwitchModel.GetQuat(), LaserSwitchesParent);
                    notStaticElements.Add(laserSwitch);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit] = laserSwitch;
                    break;
                case MapElement.Gem:
                    GameObject Gem = Instantiate(gemModel.gameObject, notStaticElementsPosition[i], gemModel.GetQuat(), mapGeneratorGO.transform) as GameObject;
                    notStaticElements.Add(Gem);
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit] = Gem;
                    break;
                case MapElement.Door:
                    GameObject door = Instantiate(doorModel.gameObject, notStaticElementsPosition[i], doorModel.GetQuat(), DoorsParent) as GameObject;
                    objectMap[(int)(startPosition.z - notStaticElementsPosition[i].z) / SharedData.widhtUnit, (int)(notStaticElementsPosition[i].x - startPosition.x) / SharedData.widhtUnit] = door;
                    notStaticElements.Add(door);
                    Door doorScript = door.GetComponent<Door>();
                    doorScript.SetCount(buttonCount);
                    doors.Add(doorScript);
                    break;
                case MapElement.Relic:
                    GameObject Relic = Instantiate(relicModel.gameObject, notStaticElementsPosition[i], relicModel.GetQuat(), mapGeneratorGO.transform) as GameObject;
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

        Vector3 forward = Joe.transform.forward.normalized;
        reCalc[0] = Convert.ToInt32(forward.x);
        reCalc[1] = -Convert.ToInt32(forward.z);
        x += reCalc[0];
        z += reCalc[1];

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
        //HighData check
        if (gemModel == null)
        {
            Debug.LogError("MapGenerator: gemModel is null!");
        }
        if (doorEdgeModel == null)
        {
            Debug.LogError("MapGenerator: doorEdgeModel is null!");
        }
        if (keyModel == null)
        {
            Debug.LogError("MapGenerator: keyModel is null!");
        }
        if (doorModel == null)
        {
            Debug.LogError("MapGenerator: doorModel is null!");
        }
        if (columnModel == null)
        {
            Debug.LogError("MapGenerator: columnModel is null!");
        }
        if (edgeModel == null)
        {
            Debug.LogError("MapGenerator: edgeModel is null!");
        }
        if (trapModel == null)
        {
            Debug.LogError("MapGenerator: trapModel is null!");
        }
        if (buttonModel == null)
        {
            Debug.LogError("MapGenerator: buttonModel is null!");
        }
        if (holeModel == null)
        {
            Debug.LogError("MapGenerator: holeModel is null!");
        }
        if (stoneLifterModel == null)
        {
            Debug.LogError("MapGenerator: stoneLifterModel is null!");
        }
        if (risingStoneModel == null)
        {
            Debug.LogError("MapGenerator: risingStoneModel is null!");
        }
        if (laserGateModel == null)
        {
            Debug.LogError("MapGenerator: laserGateModel is null!");
        }
        if (laserGateEdgeModel == null)
        {
            Debug.LogError("MapGenerator: laserGateModel is null!");
        }
        if (laserSwitchModel == null)
        {
            Debug.LogError("MapGenerator: laserSwitchModel is null!");
        }
        if (relicModel == null)
        {
            Debug.LogError("MapGenerator: relicModel is null!");
        }
        if (lowRisingStoneModel == null)
        {
            Debug.LogError("MapGenerator: lowRisingStoneModel is null!");
        }

        //Spec scripts
        if (boxModel == null)
        {
            Debug.LogError("MapGenerator: boxModel is null!");
            if (boxModel.gameObject.GetComponent<BoxCollider>() == null)
            {
                Debug.LogError("MapGenerator: boxModel must have a boxcollider!");
            }
        }
        if (laserGateModel.gameObject.GetComponent<LaserGate>() == null)
        {
            Debug.LogError("MapGenerator: laserGateModel has to have LaserGate script!");
        }
        if (risingStoneModel.gameObject.GetComponent<RiseElement>() == null)
        {
            Debug.LogError("MapGenerator: risingStoneModel has to have RiseElement script!");
        }
        if (doorModel.gameObject.GetComponent<Door>() == null)
        {
            Debug.LogError("MapGenerator: doorModel has to have Door script!");
        }
        JoeControl = Joe.GetComponent<JoeCommandControl>();
        if (JoeControl == null)
        {
            Debug.LogError("MapGenerator: Joe has to have JoeCommandControl!");
        }
    }

}
