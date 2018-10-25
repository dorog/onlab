using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CmdFactoryElement : MonoBehaviour, IPointerClickHandler
{
    private CommandType element;
    private Image img;

    public void SetCmdType(CommandType id)
    {
        img = GetComponent<Image>();
        element = id;

        switch (id)
        {
            case CommandType.GoForward:
                img.sprite = Resources.Load<Sprite>(SharedData.forwardIcon);
                break;
            case CommandType.TurnRight:
                img.sprite = Resources.Load<Sprite>(SharedData.rightIcon);
                break;
            case CommandType.TurnLeft:
                img.sprite = Resources.Load<Sprite>(SharedData.leftIcon);
                break;
            case CommandType.Activate:
                img.sprite = Resources.Load<Sprite>(SharedData.activateIcon);
                break;
            case CommandType.FV1:
                img.sprite = Resources.Load<Sprite>(SharedData.fv1Icon);
                break;
            case CommandType.FV2:
                img.sprite = Resources.Load<Sprite>(SharedData.fv2Icon);
                break;
            default:
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked();
    }

    public void Clicked()
    {
        if (StartActions.inStart)
        {
            return;
        }

        if (ActualMapData.chosenImage != null)
        {
            ActualMapData.chosenImage.color = Color.white;
        }
        if (ActualMapData.chosenImage == img)
        {
            ActualMapData.chosenImage = null;
            ActualMapData.chosenCommand = CommandType.Null;
            return;
        }

        img.color = Color.yellow;
        ActualMapData.chosenCommand = element;
        ActualMapData.chosenImage = img;
    }
}
