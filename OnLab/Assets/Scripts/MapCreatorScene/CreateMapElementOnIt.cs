using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class CreateMapElementOnIt : MonoBehaviour
{

    public int Row { get; set; }
    public int Column { get; set; }

    public bool ElementOnIt
    {
        get
        {
            return elementOnIt;
        }

        set
        {
            elementOnIt = value;
        }
    }

    public bool edgeMapElementPlace = false;

    private DesignerManager designerManager = null;
    private MapElementFactory mapElementFactory = null;

    private bool elementOnIt = false;

#if UNITY_STANDALONE_WIN
    private MeshRenderer meshRenderer;
    private Color enableColor = Color.green;
    private Color disableColor = Color.red;
    private Color originalColor = Color.white;
#endif

    // Use this for initialization
    void Start()
    {
#if UNITY_STANDALONE_WIN
            meshRenderer = GetComponent<MeshRenderer>();
#endif
        designerManager = DesignerManager.GetInstance();
        if (designerManager == null)
        {
            Debug.Log("CreateMapElementOnIt: designerManager is null!");
        }
        mapElementFactory = MapElementFactory.GetInstance();
        if (mapElementFactory == null)
        {
            Debug.Log("CreateMapElementOnIt: mapElementFactory is null!");
        }
    }

#if UNITY_STANDALONE_WIN
    private void OnMouseEnter()
    {
        Color matColor;
        if(mapElementFactory.chosedMapElement == MapElement.Null)
        {
            return;
        }
        if (designerManager.joeOnIt(Row, Column) && mapElementFactory.chosedMapElement == MapElement.Box)
        {
            matColor = disableColor;
        }
        else if (mapElementFactory.chosedMapElement == MapElement.Joe && designerManager.GetMapElement(Row, Column) == MapElement.Edge)
        {
            matColor = disableColor;
        }
        else if ((mapElementFactory.chosedMapElement == MapElement.LaserGate || mapElementFactory.chosedMapElement == MapElement.Door) && (edgeMapElementPlace || !designerManager.ThreePlace(Row, Column)))
        {
            matColor = disableColor;
        }
        else
        {
            matColor = enableColor;
        }

        Color color = meshRenderer.material.color;
        color = matColor;
        color.a = 255f;
        meshRenderer.material.color = color;
    }

    private void OnMouseExit()
    {
        Color color = meshRenderer.material.color;
        color = originalColor;
        color.a = 0;
        meshRenderer.material.color = color;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (mapElementFactory.DeleteMode)
            {
                designerManager.DeleteMapElement(Row, Column);
            }
            if (mapElementFactory.chosedMapElement == MapElement.Null)
            {
                return;
            }
            if ((mapElementFactory.chosedMapElement == MapElement.LaserGate || mapElementFactory.chosedMapElement == MapElement.Door) && (edgeMapElementPlace || !designerManager.ThreePlace(Row, Column)))
            {
                return;
            }
            if (ElementOnIt && (mapElementFactory.chosedMapElement != MapElement.Box && mapElementFactory.chosedMapElement != MapElement.Joe))
            {
                return;
            }
            ElementOnIt = designerManager.BuildMapElement(Row, Column);
            Color color = meshRenderer.material.color;
            color.a = 0f;
            meshRenderer.material.color = color;
        }
        else if(Input.GetMouseButtonDown(1))
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
        if(mapElementFactory.chosedMapElement == MapElement.Null)
        {
            return;
        }
        else
        {
            if ((mapElementFactory.chosedMapElement == MapElement.LaserGate || mapElementFactory.chosedMapElement == MapElement.Door) && (edgeMapElementPlace || !designerManager.ThreePlace(Row, Column)))
            {
                return;
            }
            if (ElementOnIt && (mapElementFactory.chosedMapElement != MapElement.Box && mapElementFactory.chosedMapElement != MapElement.Joe))
            {
                return;
            }
            ElementOnIt = designerManager.BuildMapElement(Row, Column);
        }
    }
#endif
}
