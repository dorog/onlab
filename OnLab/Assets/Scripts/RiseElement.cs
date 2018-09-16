using System.Collections.Generic;
using UnityEngine;

public class RiseElement : MonoBehaviour {

    private bool rising = false;
    private float rising_time = 0.5f;
    public float originRisingTime;
    private Vector3 aimPosition;

    public int x;
    public int z;

    public List<GameObject> boxes = new List<GameObject>();
	
	// Update is called once per frame
	void Update () {
        if (rising)
        {
            if (rising_time - Time.deltaTime >= 0)
            {
                this.transform.GetComponent<Rigidbody>().MovePosition(this.transform.position+new Vector3(0, Configuration.unit * Time.deltaTime * 2, 0));
                rising_time -= Time.deltaTime;
            }
            else if (rising_time > 0)
            {
                this.transform.GetComponent<Rigidbody>().MovePosition(aimPosition);
                rising_time = 0;
                rising = false;
            }
            //this.transform.GetComponent<Rigidbody>().MovePosition(this.transform.position+ new Vector3(0, 0.1f, 0));
        }
	}

    public void Rise()
    {
        rising_time = originRisingTime;
        HighData myData = this.GetComponent<HighData>();
        for(int i=0; i<myData.boxes.Count; i++)
        {
            myData.boxes[myData.boxes.Count-i-1].GetComponent<BoxController>().RiseBox(rising_time);
        }
        aimPosition = this.transform.position + new Vector3(0, Configuration.unit, 0);
        rising = true;
    }
}
