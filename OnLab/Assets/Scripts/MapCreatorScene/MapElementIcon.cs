using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MapElementIcon : MonoBehaviour, IPointerClickHandler
{
    private Image img;
    private MapElement element;
    private MapElementFactory mapElementFactory = null;

    private void Start()
    {
        mapElementFactory = MapElementFactory.GetInstance();
        if (mapElementFactory == null)
        {
            Debug.LogError("DesignerManager: mapElementFactory is null!");
        }
    }

    public void SetMapElementType(MapElement mapElement)
    {
        element = mapElement;
        img = GetComponent<Image>();

        switch (mapElement)
        {
            case MapElement.Column:
                img.sprite = Resources.Load<Sprite>(SharedData.columnIcon);
                break;
            case MapElement.Box:
                img.sprite = Resources.Load<Sprite>(SharedData.boxIcon);
                break;
            case MapElement.Button:
                img.sprite = Resources.Load<Sprite>(SharedData.buttonIcon);
                break;
            case MapElement.Door:
                img.sprite = Resources.Load<Sprite>(SharedData.doorIcon);
                break;
            case MapElement.Gem:
                img.sprite = Resources.Load<Sprite>(SharedData.gemIcon);
                break;
            case MapElement.Hole:
                img.sprite = Resources.Load<Sprite>(SharedData.holeIcon);
                break;
            case MapElement.Key:
                img.sprite = Resources.Load<Sprite>(SharedData.keyIcon);
                break;
            case MapElement.LaserGate:
                img.sprite = Resources.Load<Sprite>(SharedData.laserGateIcon);
                break;
            case MapElement.LaserSwitch:
                img.sprite = Resources.Load<Sprite>(SharedData.laserSwitchIcon);
                break;
            case MapElement.Relic:
                img.sprite = Resources.Load<Sprite>(SharedData.relicIcon);
                break;
            case MapElement.RisingStone:
                img.sprite = Resources.Load<Sprite>(SharedData.risingStoneIcon);
                break;
            case MapElement.StoneLifter:
                img.sprite = Resources.Load<Sprite>(SharedData.stoneLifterIcon);
                break;
            case MapElement.Trap:
                img.sprite = Resources.Load<Sprite>(SharedData.trapIcon);
                break;
            case MapElement.Joe:
                img.sprite = Resources.Load<Sprite>(SharedData.joeIcon);
                break;
            default:
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnPointerClick();
    }

    protected virtual void OnPointerClick()
    {
        if (mapElementFactory.DeleteMode)
        {
            return;
        }

        if (mapElementFactory.chosedMapImage != null)
        {
            mapElementFactory.chosedMapImage.color = Color.white;
        }
        if (mapElementFactory.chosedMapImage == img)
        {
            mapElementFactory.chosedMapImage = null;
            mapElementFactory.chosedMapElement = MapElement.Null;
            return;
        }

        img.color = Color.red;
        mapElementFactory.chosedMapElement = element;
        mapElementFactory.chosedMapImage = img;
    }
}
