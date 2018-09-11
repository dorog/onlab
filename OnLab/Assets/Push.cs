using UnityEngine;

public class Push : MonoBehaviour {

    public float push = 1000;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.right * push);
        }
	}
}
