using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapElementFactory : MonoBehaviour {

    private static MapElementFactory instance = null;

    [SerializeField]
    private MapElement[] MapElements;
    [SerializeField]
    private MapElementIcon MapElementIcon;
    [SerializeField]
    private SingletonMapElement singletonMapElement;
    [SerializeField]
    private GameObject deleteModDisable;

    public MapElement chosedMapElement = MapElement.Null;
    public Image chosedMapImage = null;

    private List<SingletonMapElement> MapElementItems = new List<SingletonMapElement>();

    private SingletonMapElement joeMapElement = null;

    private bool deleteMode = false;

    public bool DeleteMode
    {
        get
        {
            return deleteMode;
        }

        set
        {
            deleteMode = value;
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }

    void Start () {
		for(int i=0; i<MapElements.Length; i++)
        {
            if (MapElements[i]==MapElement.Key || MapElements[i] == MapElement.Gem || MapElements[i] == MapElement.Relic)
            {
                GameObject mapElementIcon = Instantiate(singletonMapElement.gameObject, transform);
                SingletonMapElement itemMEIScript = mapElementIcon.GetComponent<SingletonMapElement>();
                itemMEIScript.SetMapElementType(MapElements[i]);
                MapElementItems.Add(itemMEIScript);
            }
            else if (MapElements[i] == MapElement.Joe)
            {
                GameObject mapElementIcon = Instantiate(singletonMapElement.gameObject, transform);
                SingletonMapElement itemMEIScript = mapElementIcon.GetComponent<SingletonMapElement>();
                itemMEIScript.SetMapElementType(MapElements[i]);
                if (joeMapElement == null && MapElements[i] == MapElement.Joe)
                {
                    joeMapElement = mapElementIcon.GetComponent<SingletonMapElement>();
                }
                else if (joeMapElement != null && MapElements[i] == MapElement.Joe)
                {
                    Debug.LogError("MapElementFactory: There is more than one Joe MapElement!");
                }
            }
            else
            {
                GameObject mapElementIcon = Instantiate(MapElementIcon.gameObject, transform);
                MapElementIcon mapElementScript = mapElementIcon.GetComponent<MapElementIcon>();
                mapElementScript.SetMapElementType(MapElements[i]);
            }
        }
        if (joeMapElement == null)
        {
            Debug.LogError("MapElementFactory: There is no Joe MapElement!");
        }
	}

    public static MapElementFactory GetInstance()
    {
        return instance;
    }

    public void ChangeDeleteMode(Image img)
    {
        img.color = !DeleteMode ? Color.red : Color.white;
        DeleteMode = !DeleteMode;
        deleteModDisable.SetActive(DeleteMode);

        DiselectMapElement();
    }

    public void ItemPlaced()
    {
        DiselectMapElement();

        for (int i=0; i< MapElementItems.Count; i++)
        {
            MapElementItems[i].SetDisable();
        }
    }

    public void ItemRemoved()
    {
        for (int i = 0; i < MapElementItems.Count; i++)
        {
            MapElementItems[i].SetEnable();
        }
    }

    public void JoePlaced()
    {
        DiselectMapElement();
        joeMapElement.SetDisable();
    }

    public void JoeRemoved()
    {
        joeMapElement.SetEnable();
    }

    public void DiselectMapElement()
    {
        chosedMapElement = MapElement.Null;
        if (chosedMapImage != null)
        {
            chosedMapImage.color = Color.white;
        }
        chosedMapImage = null;
    }
}
