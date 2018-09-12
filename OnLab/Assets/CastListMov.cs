using UnityEngine;

public class CastListMov : MonoBehaviour {

    private RectTransform rt;
    public int speed;

	// Use this for initialization
	void Start () {
        rt = this.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        if(rt.anchoredPosition.y < (Screen.height / 2 + rt.sizeDelta[1] / 2))
        {
            rt.anchoredPosition = new Vector3(0, rt.anchoredPosition.y + Time.deltaTime * speed, 0);
        }
        else
        {
            this.transform.parent.gameObject.SetActive(false);
        }
	}
}
