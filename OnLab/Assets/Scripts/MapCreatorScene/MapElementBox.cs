using UnityEngine;

public class MapElementBox : MonoBehaviour {

    [SerializeField]
    private Vector3 QuatVector = Vector3.right;
    [SerializeField]
    private float QuatFloat;

    public int Row { get; set; }
    public int Column { get; set; }
    public float PlaceHeight { get; set; } //Csak doboznak kell, leszarmazottnak nem, nem jo itt

    private Color disableColor = Color.red;
    private Color enableColor = Color.green;
    private MeshRenderer meshRenderer;
    private Color[] originalColor;

    public Quaternion GetQuat()
    {
        return Quaternion.AngleAxis(QuatFloat, QuatVector);
    }

    private DesignerManager designerManager = null;
    private MapElementFactory mapElementFactory = null;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        Material[] mats = meshRenderer.materials;
        originalColor = new Color[mats.Length];
        for (int i=0; i<mats.Length; i++)
        {
            originalColor[i] = mats[i].color;
        }

        designerManager = DesignerManager.GetInstance();
        if (designerManager == null)
        {
            Debug.Log("MapElement: DesignerManager is null!");
        }
        mapElementFactory = MapElementFactory.GetInstance();
        if (mapElementFactory == null)
        {
            Debug.Log("MapElement: mapElementFactory is null!");
        }
    }

#if UNITY_STANDALONE_WIN

    private void OnMouseEnter()
    {
        Color matColor;
        if (mapElementFactory.chosedMapElement == MapElement.Null)
        {
            return;
        }
        if (!designerManager.joeOnIt(Row, Column) && mapElementFactory.chosedMapElement == MapElement.Box)
        {
            matColor = enableColor;
        }
        else if (mapElementFactory.chosedMapElement == MapElement.Joe && designerManager.GetMapElement(Row, Column)!=MapElement.Edge)
        {
            matColor = enableColor;
        }
        else
        {
            matColor = disableColor;
        }
        Material[] mats = meshRenderer.materials;
        for(int i=0; i<mats.Length; i++)
        {
            mats[i].color = matColor;
        }
    }

    private void OnMouseExit()
    {
        Material[] mats = meshRenderer.materials;
        for (int i = 0; i < mats.Length; i++)
        {
            mats[i].color = originalColor[i];
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (mapElementFactory.DeleteMode)
            {
                designerManager.DeleteMapElement(Row, Column);
            }
            else if (mapElementFactory.chosedMapElement == MapElement.Box || mapElementFactory.chosedMapElement == MapElement.Joe)
            {
                designerManager.BuildMapElement(Row, Column);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            designerManager.DeleteMapElement(Row, Column);
        }
    }
#endif

#if UNITY_ANDROID
    private void OnMouseDown()
    {
        if (mapElementFactory.DeleteMode)
        {
            designerManager.DeleteMapElement(Row, Column);
        }
        else
        {
            if (mapElementFactory.chosedMapElement == MapElement.Box || mapElementFactory.chosedMapElement == MapElement.Joe)
            {
                designerManager.BuildMapElement(Row, Column);
            }
        }
    }
#endif
}
