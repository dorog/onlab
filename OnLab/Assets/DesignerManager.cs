using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesignerManager : MonoBehaviour
{

    [Header("Models for Instantiate")]
    [SerializeField]
    private GameObject joe;
    [SerializeField]
    private MapElementData gemModel;
    [SerializeField]
    private MapElementData doorEdgeModel;
    [SerializeField]
    private MapElementData keyModel;
    [SerializeField]
    private MapElementData relicModel;
    [SerializeField]
    private MapElementData doorModel;
    [SerializeField]
    private MapElementData columnModel;
    [SerializeField]
    private MapElementData edgeModel;
    [SerializeField]
    private MapElementData trapModel;
    [SerializeField]
    private MapElementData buttonModel;
    [SerializeField]
    private MapElementData holeModel;
    [SerializeField]
    private MapElementData stoneLifterModel;
    [SerializeField]
    private MapElementData risingStoneModel;
    [SerializeField]
    private MapElementData laserGateModel;
    [SerializeField]
    private MapElementData laserGateEdgeModel;
    [SerializeField]
    private MapElementData laserSwitchModel;
    [SerializeField]
    private MapElementData lowRisingStoneModel;
    [SerializeField]
    private MapElementBox boxModel;

    [SerializeField]
    private WebCreator webCreator;
    [SerializeField]
    private float boxAboveElemValue = 20;

    private MapElement[,] actMap;
    private GameObject[,] objectMap;
    private List<GameObject> boxes = new List<GameObject>();

    private Vector3 startPosition;

    private MapElementFactory mapElementFactory;

    private static DesignerManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }

    public static DesignerManager GetInstance()
    {
        return instance;
    }

    // Use this for initialization
    void Start()
    {
        mapElementFactory = MapElementFactory.GetInstance();
        if (mapElementFactory == null)
        {
            Debug.LogError("DesignerManager: mapElementFactory is null!");
        }

        startPosition = webCreator.StartPosition;
        objectMap = new GameObject[webCreator.RowCount, webCreator.ColumnCount];
        actMap = new MapElement[webCreator.RowCount, webCreator.ColumnCount];
        for (int i = 0; i < actMap.GetLength(0); i++)
        {
            for (int j = 0; j < actMap.GetLength(1); j++)
            {
                actMap[i, j] = MapElement.Edge;
                Vector3 placePosition = new Vector3(startPosition.x + j * SharedData.widhtUnit + SharedData.widhtUnit / 2, 0, startPosition.z - i * SharedData.widhtUnit - SharedData.widhtUnit / 2);
                GameObject edge = Instantiate(edgeModel.gameObject, placePosition + new Vector3(0, edgeModel.ModelGround, 0), edgeModel.GetQuat(), transform);
                objectMap[i, j] = edge;
            }
        }
    }

    public void BuildMapElement(int row, int column)
    {
        if (mapElementFactory.chosedMapElement != MapElement.Box)
        {
            actMap[row, column] = mapElementFactory.chosedMapElement;
        }
        GameObject elem = null;
        Vector3 placePosition = new Vector3(startPosition.x + column * SharedData.widhtUnit + SharedData.widhtUnit / 2, 0, startPosition.z - row * SharedData.widhtUnit - SharedData.widhtUnit / 2);

        switch (mapElementFactory.chosedMapElement)
        {
            case MapElement.Column:
                elem = Instantiate(columnModel.gameObject, placePosition + new Vector3(0, columnModel.ModelGround, 0), columnModel.GetQuat(), transform);
                break;
            case MapElement.Trap:
                elem = Instantiate(trapModel.gameObject, placePosition + new Vector3(0, trapModel.ModelGround, 0), trapModel.GetQuat(), transform);
                break;
            case MapElement.Button:
                elem = Instantiate(buttonModel.gameObject, placePosition + new Vector3(0, buttonModel.ModelGround, 0), buttonModel.GetQuat(), transform);
                break;
            case MapElement.Hole:
                elem = Instantiate(holeModel.gameObject, placePosition + new Vector3(0, holeModel.ModelGround, 0), holeModel.GetQuat(), transform);
                break;
            case MapElement.Door:
                elem = Instantiate(doorModel.gameObject, placePosition + new Vector3(0, doorModel.ModelGround, 0), doorModel.GetQuat(), transform);
                GameObject doorEdge1 = Instantiate(doorEdgeModel.gameObject, placePosition + new Vector3(0, doorEdgeModel.ModelGround, SharedData.widhtUnit), doorEdgeModel.GetQuat(), transform);
                GameObject doorEdge2 = Instantiate(doorEdgeModel.gameObject, placePosition + new Vector3(0, doorEdgeModel.ModelGround, -SharedData.widhtUnit), doorEdgeModel.GetQuat(), transform);
                webCreator.EnableMapPlace(row + 1, column);
                webCreator.EnableMapPlace(row - 1, column);
                MapElementData doorEdge1MED = doorEdge1.GetComponent<MapElementData>();
                doorEdge1MED.Row = row - 1;
                doorEdge1MED.Column = column;
                MapElementData doorEdge2MED = doorEdge2.GetComponent<MapElementData>();
                doorEdge2MED.Row = row + 1;
                doorEdge2MED.Column = column;
                actMap[row + 1, column] = MapElement.DoorEdge;
                actMap[row - 1, column] = MapElement.DoorEdge;
                objectMap[row + 1, column] = doorEdge2;
                objectMap[row - 1, column] = doorEdge1;
                break;
            case MapElement.Key:
                elem = Instantiate(keyModel.gameObject, placePosition + new Vector3(0, keyModel.ModelGround, 0), keyModel.GetQuat(), transform);
                break;
            case MapElement.StoneLifter:
                elem = Instantiate(stoneLifterModel.gameObject, placePosition + new Vector3(0, stoneLifterModel.ModelGround, 0), stoneLifterModel.GetQuat(), transform);
                break;
            case MapElement.RisingStone:
                elem = Instantiate(risingStoneModel.gameObject, placePosition + new Vector3(0, risingStoneModel.ModelGround, 0), risingStoneModel.GetQuat(), transform);
                break;
            case MapElement.LowRisingStone:
                elem = Instantiate(lowRisingStoneModel.gameObject, placePosition + new Vector3(0, lowRisingStoneModel.ModelGround, 0), lowRisingStoneModel.GetQuat(), transform);
                break;
            case MapElement.LaserGate:
                elem = Instantiate(laserGateModel.gameObject, placePosition + new Vector3(0, laserGateModel.ModelGround, 0), laserGateModel.GetQuat(), transform);
                GameObject laserGateEdge1 = Instantiate(laserGateEdgeModel.gameObject, placePosition + new Vector3(0, laserGateEdgeModel.ModelGround, SharedData.widhtUnit), laserGateEdgeModel.GetQuat(), transform);
                GameObject laserGateEdge2 = Instantiate(laserGateEdgeModel.gameObject, placePosition + new Vector3(0, laserGateEdgeModel.ModelGround, -SharedData.widhtUnit), laserGateEdgeModel.GetQuat(), transform);
                MapElementData laserGateEdge1MED = laserGateEdge1.GetComponent<MapElementData>();
                laserGateEdge1MED.Row = row - 1;
                laserGateEdge1MED.Column = column;
                MapElementData laserGateEdge2MED = laserGateEdge2.GetComponent<MapElementData>();
                laserGateEdge2MED.Row = row + 1;
                laserGateEdge2MED.Column = column;
                webCreator.DisableMapPlace(row + 1, column);
                webCreator.DisableMapPlace(row - 1, column);
                actMap[row + 1, column] = MapElement.LaserGateEdge;
                actMap[row - 1, column] = MapElement.LaserGateEdge;
                objectMap[row + 1, column] = laserGateEdge2;
                objectMap[row - 1, column] = laserGateEdge1;
                break;
            case MapElement.LaserSwitch:
                elem = Instantiate(laserSwitchModel.gameObject, placePosition + new Vector3(0, laserSwitchModel.ModelGround, 0), laserSwitchModel.GetQuat(), transform);
                break;
            case MapElement.Gem:
                elem = Instantiate(gemModel.gameObject, placePosition + new Vector3(0, gemModel.ModelGround, 0), gemModel.GetQuat(), transform);
                break;
            case MapElement.Relic:
                elem = Instantiate(relicModel.gameObject, placePosition + new Vector3(0, relicModel.ModelGround, 0), relicModel.GetQuat(), transform);
                break;
            case MapElement.Box:
                MapElementData boxOnIt = objectMap[row, column].GetComponent<MapElementData>();
                GameObject box = Instantiate(boxModel.gameObject, placePosition + new Vector3(0, SharedData.hight_0_Ground + (boxOnIt.Height + boxOnIt.BoxOnItCount) * SharedData.heightUnit + boxAboveElemValue, 0), boxModel.GetQuat(), transform);
                boxOnIt.BoxOnItCount++;
                boxes.Add(box);
                boxOnIt.AddBox(box);
                MapElementBox mapElementBox = box.GetComponent<MapElementBox>();
                mapElementBox.Column = column;
                mapElementBox.Row = row;
                return;
            default:
                break;
        }

        MapElementData mapElementData = elem.GetComponent<MapElementData>();
        mapElementData.Row = row;
        mapElementData.Column = column;
        objectMap[row, column] = elem;
    }

    public void DeleteMapElement(int row, int column)
    {
        MapElementData mapElementData = objectMap[row, column].GetComponent<MapElementData>();
        if (mapElementData.BoxOnItCount > 0)
        {
            GameObject topBox = mapElementData.GetTopBox();
            boxes.Remove(topBox);
            mapElementData.RemoveLast();
            mapElementData.BoxOnItCount--;
            Destroy(topBox);

            if (mapElementData.BoxOnItCount == 0 && actMap[row, column] == MapElement.Edge)
            {
                webCreator.EnableMapPlace(row, column);
            }
        }
        else
        {
            if (actMap[row, column] == MapElement.Door || actMap[row, column] == MapElement.LaserGate)
            {
                DeleteThreeElement(row, column);
            }
            else if (actMap[row, column] == MapElement.LaserGateEdge || actMap[row, column] == MapElement.DoorEdge)
            {
                if(actMap[row-1, column] == MapElement.LaserGate || actMap[row - 1, column] == MapElement.Door)
                {
                    DeleteThreeElement(row-1, column);
                }
                else
                {
                    DeleteThreeElement(row + 1, column);
                }
            }
            else
            {
                actMap[row, column] = MapElement.Edge;
                webCreator.EnableMapPlace(row, column);
                Destroy(objectMap[row, column]);

                Vector3 placePosition = new Vector3(startPosition.x + column * SharedData.widhtUnit + SharedData.widhtUnit / 2, 0, startPosition.z - row * SharedData.widhtUnit - SharedData.widhtUnit / 2);
                GameObject edge = Instantiate(edgeModel.gameObject, placePosition + new Vector3(0, edgeModel.ModelGround, 0), edgeModel.GetQuat(), transform);
                objectMap[row, column] = edge;
            }
        }
    }

    public bool ThreePlace(int row, int column)
    {
        if (actMap[row - 1, column] != MapElement.Edge || actMap[row + 1, column] != MapElement.Edge)
        {
            return false;
        }
        return true;
    }

    private void DeleteThreeElement(int row, int column)
    {
        Debug.Log(actMap[row, column]);
        MapElementData neighEdge1 = objectMap[row - 1, column].GetComponent<MapElementData>();
        MapElementData neighEdge2 = objectMap[row + 1, column].GetComponent<MapElementData>();
        MapElementData obj = objectMap[row, column].GetComponent<MapElementData>();
        if (neighEdge1.BoxOnItCount > 0 || neighEdge2.BoxOnItCount > 0 || obj.BoxOnItCount > 0)
        {
            return;
        }
        Destroy(objectMap[row - 1, column]);
        Destroy(objectMap[row + 1, column]);

        actMap[row - 1, column] = MapElement.Edge;
        actMap[row + 1, column] = MapElement.Edge;
        webCreator.EnableMapPlace(row - 1, column);
        webCreator.EnableMapPlace(row + 1, column);

        Vector3 placePosition1 = new Vector3(startPosition.x + column * SharedData.widhtUnit + SharedData.widhtUnit / 2, 0, startPosition.z - (row + 1) * SharedData.widhtUnit - SharedData.widhtUnit / 2);
        GameObject edge1 = Instantiate(edgeModel.gameObject, placePosition1 + new Vector3(0, edgeModel.ModelGround, 0), edgeModel.GetQuat(), transform);
        objectMap[row + 1, column] = edge1;

        Vector3 placePosition2 = new Vector3(startPosition.x + column * SharedData.widhtUnit + SharedData.widhtUnit / 2, 0, startPosition.z - (row - 1) * SharedData.widhtUnit - SharedData.widhtUnit / 2);
        GameObject edge2 = Instantiate(edgeModel.gameObject, placePosition2 + new Vector3(0, edgeModel.ModelGround, 0), edgeModel.GetQuat(), transform);
        objectMap[row - 1, column] = edge2;


        actMap[row, column] = MapElement.Edge;
        webCreator.EnableMapPlace(row, column);
        Destroy(objectMap[row, column]);

        Vector3 placePosition = new Vector3(startPosition.x + column * SharedData.widhtUnit + SharedData.widhtUnit / 2, 0, startPosition.z - row * SharedData.widhtUnit - SharedData.widhtUnit / 2);
        GameObject edge = Instantiate(edgeModel.gameObject, placePosition + new Vector3(0, edgeModel.ModelGround, 0), edgeModel.GetQuat(), transform);
        objectMap[row, column] = edge;
    }
}
