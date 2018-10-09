using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CmdFactoryElement : MonoBehaviour, IPointerClickHandler
{
    private Configuration.CommandType element;
    private Image img;

    public void SetCmdType(Configuration.CommandType id)
    {
        img = this.GetComponent<Image>();
        element = id;

        switch (id)
        {
            case Configuration.CommandType.GoForward:
                img.sprite = Resources.Load<Sprite>(Configuration.forwardIcon);
                break;
            case Configuration.CommandType.TurnRight:
                img.sprite = Resources.Load<Sprite>(Configuration.rightIcon);
                break;
            case Configuration.CommandType.TurnLeft:
                img.sprite = Resources.Load<Sprite>(Configuration.leftIcon);
                break;
            case Configuration.CommandType.Activate:
                img.sprite = Resources.Load<Sprite>(Configuration.activateIcon);
                break;
            case Configuration.CommandType.FV1:
                img.sprite = Resources.Load<Sprite>(Configuration.fv1IconLocation);
                break;
            case Configuration.CommandType.FV2:
                img.sprite = Resources.Load<Sprite>(Configuration.fv2IconLocation);
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
        if (Configuration.inStart)
        {
            return;
        }
        Image img = this.GetComponent<Image>();

        if (Configuration.chosenImage != null)
        {
            Configuration.chosenImage.color = Color.white;
        }
        if (Configuration.chosenImage == img)
        {
            Configuration.chosenImage = null;
            Configuration.chosenCommand = Configuration.CommandType.Null;
            return;
        }

        img.color = Color.yellow;
        Configuration.chosenCommand = element;
        Configuration.chosenImage = this.GetComponent<Image>();
    }
}
