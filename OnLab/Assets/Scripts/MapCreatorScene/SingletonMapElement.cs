using UnityEngine.UI;
using UnityEngine;

public class SingletonMapElement : MapElementIcon
{
    private bool itemOnMap = false;

    protected override void OnPointerClick()
    {
        if (itemOnMap)
        {
            return;
        }
        base.OnPointerClick();
    }

    public void SetDisable()
    {
        itemOnMap = true;
        Image img = GetComponent<Image>();
        img.color = Color.grey;
    }

    public void SetEnable()
    {
        itemOnMap = false;
        Image img = GetComponent<Image>();
        img.color = Color.white;
    }
}
