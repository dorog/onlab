using UnityEngine;

public class KeyEffects : MonoBehaviour {

    public float rotationSpeed = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
	}

    private void OnTriggerEnter(Collider other)
    {
        CurrentGameDatas.HaveKey = true;
        //Debug.Log("RIP");
        Destroy(this.transform.gameObject);
    }
}
