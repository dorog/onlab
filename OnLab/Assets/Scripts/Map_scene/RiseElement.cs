using System.Collections.Generic;
using UnityEngine;

public class RiseElement : MonoBehaviour {

    private bool rising = false;
    private float rising_time = 0.5f;
    private float originRisingTime;

    public GameObject underThis;
    private int rised = 1;

    private float speed;

    private Vector3 aimPosition; 

    public List<GameObject> boxes = new List<GameObject>();

    void Start()
    {
        speed = Configuration.unit / Configuration.timeForAnimation;
        originRisingTime = Configuration.timeForAnimation;
    }
	
	// Update is called once per frame
	void Update () {
        if (rising)
        {
            if (rising_time - Time.deltaTime >= 0)
            {
                this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                rising_time -= Time.deltaTime;
            }
            else if (rising_time > 0)
            {
                this.transform.position = aimPosition;
                rising_time = 0;
                rising = false;
            }
        }
	}

    public void Rise()
    {
        Instantiate(underThis, this.transform.position + Vector3.down * Configuration.unit * rised, this.transform.rotation, this.transform);
        aimPosition = this.transform.position + new Vector3(0, Configuration.unit, 0);
        rised++;
        rising_time = originRisingTime;
        HighData myData = this.GetComponent<HighData>();
        myData.baseHigh++;
        for(int i=0; i<myData.GetBoxCount(); i++)
        {
            myData.GetBox(myData.GetBoxCount()-i-1).GetComponent<BoxController>().RiseBox(Configuration.timeForAnimation);
        }
        rising = true;
    }
}
