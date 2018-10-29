using UnityEngine;
using UnityEngine.UI;

public class MapElementFactory : MonoBehaviour {

    private static MapElementFactory instance = null;

    [SerializeField]
    private MapElement[] MapElements;
    [SerializeField]
    private MapElementIcon MapElementIcon;

    public MapElement chosedMapElement = MapElement.Null;
    public Image chosedMapImage = null;

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
            GameObject mapElementIcon = Instantiate(MapElementIcon.gameObject, transform);
            MapElementIcon mapElementScript = mapElementIcon.GetComponent<MapElementIcon>();
            mapElementScript.SetMapElementType(MapElements[i]);
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

        if (chosedMapImage != null)
        {
            chosedMapImage.color = Color.white;
        }
        chosedMapElement = MapElement.Null;
        chosedMapImage = null;
}
}
