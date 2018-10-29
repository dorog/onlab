using UnityEngine;

public class MapElementBox : MonoBehaviour {

    [SerializeField]
    private Vector3 QuatVector = Vector3.right;
    [SerializeField]
    private float QuatFloat;

    public int Row { get; set; }
    public int Column { get; set; }

    public Quaternion GetQuat()
    {
        return Quaternion.AngleAxis(QuatFloat, QuatVector);
    }

    private DesignerManager designerManager = null;
    private MapElementFactory mapElementFactory = null;

    void Start()
    {
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
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (mapElementFactory.chosedMapElement == MapElement.Box)
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
            if (mapElementFactory.chosedMapElement == MapElement.Box)
            {
                designerManager.BuildMapElement(Row, Column);
            }
        }
    }
#endif
}
