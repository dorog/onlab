using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class CastListMov : MonoBehaviour {

    private RectTransform rt;

    [SerializeField]
    private int speed;

	void Start () {
        rt = GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector3(0, -Screen.height / 2 + -rt.sizeDelta[1]/2, 0);
	}
	
	void Update () {
        if(rt.anchoredPosition.y < (Screen.height / 2 + rt.sizeDelta[1] / 2))
        {
            rt.anchoredPosition = new Vector3(0, rt.anchoredPosition.y + Time.deltaTime * speed, 0);
        }
        else
        {
            transform.parent.gameObject.SetActive(false);
        }
	}
}
