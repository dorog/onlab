using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
    private MapElementBox joeModel;

    [SerializeField]
    private WebCreator webCreator;
    [SerializeField]
    private float boxAboveElemValue = 26;
    [SerializeField]
    private float joeAboveValue = 26;
    [Header("Camera change settings")]
    [SerializeField]
    private ChangeCamera changeCamera;
    [Header("Android Camera change settings")]
    [SerializeField]
    private GameObject androidPanel;
    [SerializeField]
    private Button androidClear;
    [SerializeField]
    private Button androidDelete;
    [Header("Windows Camera change settings")]
    [SerializeField]
    private GameObject windowsPanel;
    [SerializeField]
    private Button windowsClear;
    [SerializeField]
    private Button windowsDelete;
    [Header("Android Save settings")]
    [SerializeField]
    private Button androidSaveBtn;
    [SerializeField]
    private GameObject androidSavePanel;
    [SerializeField]
    private Text androidSaveName;
    [SerializeField]
    private Text androidScarab3part;
    [SerializeField]
    private Text androidScarab2part;
    [Header("Windows Save settings")]
    [SerializeField]
    private Button windowsSaveBtn;
    [SerializeField]
    private GameObject windowsSavePanel;
    [SerializeField]
    private Text windowsSaveName;
    [SerializeField]
    private Text windowsScarab3part;
    [SerializeField]
    private Text windowsScarab2part;


    private Button saveBtn;
    private GameObject savePanel;
    private Text saveName;
    private Text scarab3part;
    private Text scarab2part;

    private MapElement[,] actMap;
    private GameObject[,] objectMap;
    private List<GameObject> boxes = new List<GameObject>();
    private MapElementBox joeMEB = null;
    private MapElement itemType = MapElement.Null;

    private Vector3 startPosition;

    private MapElementFactory mapElementFactory;

    private static DesignerManager instance;

    string deviceCreatedMapFileLocation;


    private GameObject panel;
    private Button clear;
    private Button delete;

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

    void Start()
    {

#if UNITY_ANDROID
        saveBtn = androidSaveBtn;
        savePanel = androidSavePanel;
        saveName = androidSaveName;
        scarab3part = androidScarab3part;
        scarab2part = androidScarab2part;

        panel = androidPanel;
        clear = androidClear;
        delete = androidDelete;
#else
        saveBtn = windowsSaveBtn;
        savePanel = windowsSavePanel;
        saveName = windowsSaveName;
        scarab3part = windowsScarab3part;
        scarab2part = windowsScarab2part;

        panel = windowsPanel;
        clear = windowsClear;
        delete = windowsDelete;
#endif

        deviceCreatedMapFileLocation = Application.persistentDataPath + SharedData.deviceCreatedMapFileLocation;

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

    public bool BuildMapElement(int row, int column)
    {
        if(actMap[row, column] == MapElement.Edge && mapElementFactory.chosedMapElement == MapElement.Joe)
        {
            return false;
        }
        if (mapElementFactory.chosedMapElement != MapElement.Box && mapElementFactory.chosedMapElement != MapElement.Joe)
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
                mapElementFactory.ItemPlaced();
                itemType = MapElement.Key;
                break;
            case MapElement.StoneLifter:
                elem = Instantiate(stoneLifterModel.gameObject, placePosition + new Vector3(0, stoneLifterModel.ModelGround, 0), stoneLifterModel.GetQuat(), transform);
                break;
            case MapElement.RisingStone:
                elem = Instantiate(risingStoneModel.gameObject, placePosition + new Vector3(0, risingStoneModel.ModelGround, 0), risingStoneModel.GetQuat(), transform);
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
                mapElementFactory.ItemPlaced();
                itemType = MapElement.Gem;
                break;
            case MapElement.Relic:
                elem = Instantiate(relicModel.gameObject, placePosition + new Vector3(0, relicModel.ModelGround, 0), relicModel.GetQuat(), transform);
                mapElementFactory.ItemPlaced();
                itemType = MapElement.Relic;
                break;
            case MapElement.Box:
                MapElementData boxOnIt = objectMap[row, column].GetComponent<MapElementData>();
                if (boxOnIt.joeOnIt)
                {
                    return true;
                }
                GameObject box = Instantiate(boxModel.gameObject, placePosition + new Vector3(0, SharedData.hight_0_Ground + (boxOnIt.Height + boxOnIt.BoxOnItCount) * SharedData.heightUnit + boxAboveElemValue, 0), boxModel.GetQuat(), transform);
                boxOnIt.BoxOnItCount++;
                boxes.Add(box);
                boxOnIt.AddBox(box);
                MapElementBox mapElementBox = box.GetComponent<MapElementBox>();
                mapElementBox.Column = column;
                mapElementBox.Row = row;
                mapElementBox.PlaceHeight = SharedData.hight_0_Ground + (boxOnIt.Height + boxOnIt.BoxOnItCount) * SharedData.heightUnit + boxAboveElemValue;
                return true;
            case MapElement.Joe:
                MapElementData joePlace = objectMap[row, column].GetComponent<MapElementData>();
                GameObject joe = Instantiate(joeModel.gameObject, placePosition + new Vector3(0, SharedData.hight_0_Ground + (joePlace.Height + joePlace.BoxOnItCount) * SharedData.heightUnit + joeAboveValue, 0), joeModel.GetQuat(), transform);
                mapElementFactory.JoePlaced();
                joePlace.joeOnIt = joe;
                MapElementBox joeMEB = joe.GetComponent<MapElementBox>();
                joeMEB.Column = column;
                joeMEB.Row = row;
                joeMEB.PlaceHeight = SharedData.hight_0_Ground + (joePlace.Height + joePlace.BoxOnItCount) * SharedData.heightUnit + joeAboveValue;
                this.joeMEB = joeMEB;
                saveBtn.interactable = true;
                return true;
            default:
                break;
        }

        MapElementData mapElementData = elem.GetComponent<MapElementData>();
        mapElementData.Row = row;
        mapElementData.Column = column;
        Destroy(objectMap[row, column]);
        objectMap[row, column] = elem;
        return true;
    }

    public void DeleteMapElement(int row, int column)
    {
        MapElementData mapElementData = objectMap[row, column].GetComponent<MapElementData>();
        if (mapElementData.joeOnIt != null)
        {
            Destroy(mapElementData.joeOnIt);
            mapElementData.joeOnIt = null;
            mapElementFactory.JoeRemoved();
            joeMEB = null;
            saveBtn.interactable = false;
        }
        else if (mapElementData.BoxOnItCount > 0)
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
                if (actMap[row, column] == MapElement.Key || actMap[row, column] == MapElement.Relic || actMap[row, column] == MapElement.Gem)
                {
                    mapElementFactory.ItemRemoved();
                    itemType = MapElement.Null;
                }
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

    public void Clear()
    {
        mapElementFactory.JoeRemoved();
        mapElementFactory.ItemRemoved();

        for(int i=0; i<transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
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
        webCreator.Clear();
        boxes.Clear();
    }

    public void ChangeCamera()
    {
        bool state = !panel.activeSelf;
        panel.SetActive(state);
        clear.interactable = state;
        delete.interactable = state;
        changeCamera.SwitchCamera();
    }

    public void SaveClick()
    {
        mapElementFactory.DiselectMapElement();
        savePanel.SetActive(true);
    }

    public void CancelClick()
    {
        savePanel.SetActive(false);
    }

    public void SaveMap()
    {
        MapSer map = new MapSer();

        map.name = saveName.text;
        map.Scarab2PartNumber = Convert.ToInt32(scarab2part.text);
        map.Scarab3PartNumber = Convert.ToInt32(scarab3part.text);

        int plusEdges = boxes.Count+1;

        MapElement[,] mapElements = new MapElement[webCreator.RowCount+2*plusEdges, webCreator.ColumnCount+2*plusEdges];
        for(int i = plusEdges; i < webCreator.RowCount + plusEdges; i++)
        {
            for(int j = plusEdges; j < webCreator.ColumnCount + plusEdges; j++)
            {
                mapElements[i, j] = actMap[i - plusEdges, j - plusEdges];
            }
        }

        map.startPosition = new Vector3Ser(startPosition.x - plusEdges * SharedData.widhtUnit, startPosition.y, startPosition.z + plusEdges * SharedData.widhtUnit);

        Vector3 extraDistance = new Vector3(-1, 0, 1) * plusEdges * SharedData.widhtUnit;

        float charPositionX = startPosition.x + (joeMEB.Column + plusEdges) * SharedData.widhtUnit + extraDistance.x;
        float charPositionY = startPosition.y + joeMEB.PlaceHeight;
        float charPositionZ = startPosition.z - (joeMEB.Row + plusEdges) * SharedData.widhtUnit + extraDistance.z;

        map.charPosition = new Vector3Ser(charPositionX, charPositionY, charPositionZ);
        map.mapMatrix = mapElements;
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = boxes.Count;
        map.boxLocations = new Vector3Ser[boxes.Count];
        for(int i=0; i<boxes.Count; i++)
        {
            MapElementBox boxME = boxes[i].GetComponent<MapElementBox>();
            float boxLocationX = startPosition.x + (boxME.Column + plusEdges) * SharedData.widhtUnit + extraDistance.x;
            float boxLocationY = startPosition.y + boxME.PlaceHeight;
            float boxLocationZ = startPosition.z - (boxME.Row + plusEdges) * SharedData.widhtUnit + extraDistance.z;
            map.boxLocations[i] = new Vector3Ser(boxLocationX, boxLocationY, boxLocationZ);
        }

        if (itemType == MapElement.Key)
        {
            map.itemType = SharedData.KeyType;
        }
        else if (itemType == MapElement.Gem)
        {
            map.itemType = SharedData.GemType;
        }
        else if (itemType == MapElement.Relic)
        {
            map.itemType = SharedData.RelicType;
        }
        else
        {
            map.itemType = SharedData.DefaultType;
        }

        MapCollection.CalculateItemsMapSer(map);

        Save(map);

        SceneLoader.LoadSceneStatic(GameStructure.extraSceneName);
    }

    private void Save(MapSer map)
    {
        MapSer[] datas = Read();
        datas[datas.Length - 1] = map;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(deviceCreatedMapFileLocation, FileMode.Open);
        CreatedMaps data = (CreatedMaps)bf.Deserialize(file);
        file.Close();

        data.maps = datas;

        FileStream fileForSave = File.Create(deviceCreatedMapFileLocation);
        bf.Serialize(fileForSave, data);
        fileForSave.Close();
    }

    private MapSer[] Read()
    {
        if (File.Exists(deviceCreatedMapFileLocation))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(deviceCreatedMapFileLocation, FileMode.Open);
            CreatedMaps maps = (CreatedMaps)bf.Deserialize(file);
            file.Close();

            MapSer[] datas;
            if (maps.maps == null)
            {
                datas = new MapSer[1];
                return datas;
            }
            else{
                datas = new MapSer[maps.maps.Length + 1];
            }
            for (int i = 0; i < maps.maps.Length; i++)
            {
                datas[i] = maps.maps[i];
            }
            return datas;
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(deviceCreatedMapFileLocation, FileMode.Create);
            CreatedMaps data = new CreatedMaps();
            data.maps = new MapSer[1];
            bf.Serialize(file, data);
            file.Close();

            return new MapSer[1];
        }
    }

    public void GoToExtraScene()
    {
        SceneLoader.LoadSceneStatic(GameStructure.extraSceneName);
    }

    public bool joeOnIt(int row, int column)
    {
        MapElementData mapElementData = objectMap[row, column].GetComponent<MapElementData>();
        return mapElementData.joeOnIt;
    }

    public MapElement GetMapElement(int row, int column)
    {
        return actMap[row, column];
    }
}
