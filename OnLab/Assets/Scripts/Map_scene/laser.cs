using UnityEngine;

public class laser : MonoBehaviour {

    private LineRenderer lr;
    public Vector3 start;
    public Vector3 aim;

	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        lr.SetPosition(0, start);
        lr.SetPosition(1, aim);
	}
}
