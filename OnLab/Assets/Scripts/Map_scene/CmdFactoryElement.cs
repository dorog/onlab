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
        element = id;
        img = GetComponent<Image>();

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
        Click();
    }

    public void Click()
    {
        if (StartActions.inStart)
        {
            return;
        }

        if (CommandFactory.chosenImage != null)
        {
            CommandFactory.chosenImage.color = Color.white;
        }
        if (CommandFactory.chosenImage == img)
        {
            CommandFactory.chosenImage = null;
            CommandFactory.chosenCommand = CommandType.Null;
            return;
        }

        img.color = Color.yellow;
        CommandFactory.chosenCommand = element;
        CommandFactory.chosenImage = img;
    }
}
