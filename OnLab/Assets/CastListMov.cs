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
        rt.anchoredPosition = new Vector3(0, rt.anchoredPosition.y + Time.deltaTime * speed, 0);
	}
}
