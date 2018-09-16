using UnityEngine;

public class LaserGate : MonoBehaviour {

    public int activeSwitches { get; set; }
    public int summSwitches { get; set; }
    private int originSummSwitches;
    public bool setted = false;
    public GameObject laserModel;
    public int middleColumn = 190;
    public int laserPlaceInterval = 150;
    private Transform parent;

	// Use this for initialization
	void Start () {
        parent = this.transform.GetChild(this.transform.childCount - 1).transform;

    }
	
	// Update is called once per frame
	void Update () {
        if (setted)
        {
            SetLasers();
            setted = false;
        }
	}

    private void SetLasers()
    {
        originSummSwitches = summSwitches;
        if (summSwitches % 2 == 1)
        {
            GameObject laser = Instantiate(laserModel, new Vector3(0, 0, 0), Quaternion.AngleAxis(0, new Vector3(0, 0, 0)));
            laser.transform.SetParent(parent);
            laser laserScript = laser.GetComponent<laser>();
            laserScript.aim = new Vector3(this.transform.position.x, middleColumn+Configuration.laserGateGround, this.transform.position.z-50);
            laserScript.start = new Vector3(this.transform.position.x, middleColumn+Configuration.laserGateGround, this.transform.position.z + 50);
        }
        if (summSwitches == 0)
        {
            return;
        }
        float placeBetweenLasers = laserPlaceInterval / summSwitches;

        for(int i=0; i<summSwitches/2; i++)
        {
            GameObject laser = Instantiate(laserModel, new Vector3(0, 0, 0), Quaternion.AngleAxis(0, new Vector3(0, 0, 0)));
            laser.transform.SetParent(parent);
            laser laserScript = laser.GetComponent<laser>();
            laserScript.aim = new Vector3(this.transform.position.x, middleColumn + Configuration.laserGateGround + (i+1)*placeBetweenLasers, this.transform.position.z - 50);
            laserScript.start = new Vector3(this.transform.position.x, middleColumn + Configuration.laserGateGround + (i + 1) * placeBetweenLasers, this.transform.position.z + 50);

            GameObject laser2 = Instantiate(laserModel, new Vector3(0, 0, 0), Quaternion.AngleAxis(0, new Vector3(0, 0, 0)));
            laser2.transform.SetParent(parent);
            laser laserScript2 = laser2.GetComponent<laser>();
            laserScript2.aim = new Vector3(this.transform.position.x, middleColumn + Configuration.laserGateGround - (i + 1) * placeBetweenLasers, this.transform.position.z - 50);
            laserScript2.start = new Vector3(this.transform.position.x, middleColumn + Configuration.laserGateGround - (i + 1) * placeBetweenLasers, this.transform.position.z + 50);
        }
    }

    public void SwitchedOffOne()
    {
        activeSwitches--;
        parent.GetChild(activeSwitches).gameObject.SetActive(false);
    }

    public void SwitchedOnOne()
    {
        parent.GetChild(activeSwitches).gameObject.SetActive(true);
        activeSwitches++;
    }

    public void resetLaserGate()
    {
        for(int i=0; i<parent.childCount; i++)
        {
            parent.GetChild(i).gameObject.SetActive(true);
        }
        activeSwitches = originSummSwitches;
    }
}
