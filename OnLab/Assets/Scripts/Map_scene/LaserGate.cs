using UnityEngine;

public class LaserGate : MonoBehaviour {

    public int activeSwitches = 1;
    private int summSwitches;
    public GameObject laserModel;
    public int middleColumn = 190;
    public int laserPlaceInterval = 150;
    public float columnDisctanceFromPosition = 50;
    public Transform parent;

    public void SetLasers(int summSwitches)
    {
        activeSwitches = summSwitches;
        this.summSwitches = summSwitches;

        if (this.summSwitches % 2 == 1)
        {
            OddNumber();
        }
        else
        {
            EvenNumber();
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

    public void ResetLaserGate()
    {
        for(int i=0; i<parent.childCount; i++)
        {
            parent.GetChild(i).gameObject.SetActive(true);
        }
        activeSwitches = summSwitches;
    }

    private void EvenNumber()
    {
        float placeBetweenLasers = laserPlaceInterval / summSwitches;

        for (int i = 0; i < summSwitches / 2; i++)
        {
            //GameObject StoneLifter = Instantiate(BridgeMakeModel, new Vector3(0, Configuration.stoneLifterGround, -25), Quaternion.AngleAxis(0, Vector3.right), mapGeneratorGO.transform.GetChild(RisingStoneChild)) as GameObject;
            GameObject laser = Instantiate(laserModel, new Vector3(0, 0, 0), Quaternion.AngleAxis(0, Vector3.zero), parent) as GameObject;
            //laser.transform.SetParent(parent);
            laser laserScript = laser.GetComponent<laser>();
            laserScript.aim = new Vector3(this.transform.position.x, middleColumn + Configuration.laserGateGround + (i + 0.5f) * placeBetweenLasers, this.transform.position.z - columnDisctanceFromPosition);
            laserScript.start = new Vector3(this.transform.position.x, middleColumn + Configuration.laserGateGround + (i + 0.5f) * placeBetweenLasers, this.transform.position.z + columnDisctanceFromPosition);

            GameObject laser2 = Instantiate(laserModel, new Vector3(0, 0, 0), Quaternion.AngleAxis(0, Vector3.zero), parent);
            //laser2.transform.SetParent(parent);
            laser laserScript2 = laser2.GetComponent<laser>();
            laserScript2.aim = new Vector3(this.transform.position.x, middleColumn + Configuration.laserGateGround - (i + 0.5f) * placeBetweenLasers, this.transform.position.z - columnDisctanceFromPosition);
            laserScript2.start = new Vector3(this.transform.position.x, middleColumn + Configuration.laserGateGround - (i + 0.5f) * placeBetweenLasers, this.transform.position.z + columnDisctanceFromPosition);
        }
    }
    
    private void OddNumber()
    {
        GameObject middleLaser = Instantiate(laserModel, new Vector3(0, 0, 0), Quaternion.AngleAxis(0, Vector3.zero), parent);
        //middleLaser.transform.SetParent(parent);
        laser middleLaserScript = middleLaser.GetComponent<laser>();
        middleLaserScript.aim = new Vector3(this.transform.position.x, middleColumn + Configuration.laserGateGround, this.transform.position.z - columnDisctanceFromPosition);
        middleLaserScript.start = new Vector3(this.transform.position.x, middleColumn + Configuration.laserGateGround, this.transform.position.z + columnDisctanceFromPosition);

        if (summSwitches == 1)
        {
            return;
        }

        float placeBetweenLasers = laserPlaceInterval / summSwitches;

        for (int i = 0; i < summSwitches / 2; i++)
        {
            GameObject laser = Instantiate(laserModel, new Vector3(0, 0, 0), Quaternion.AngleAxis(0, Vector3.zero), parent);
            //laser.transform.SetParent(parent);
            laser laserScript = laser.GetComponent<laser>();
            laserScript.aim = new Vector3(this.transform.position.x, middleColumn + Configuration.laserGateGround + (i + 1) * placeBetweenLasers, this.transform.position.z - columnDisctanceFromPosition);
            laserScript.start = new Vector3(this.transform.position.x, middleColumn + Configuration.laserGateGround + (i + 1) * placeBetweenLasers, this.transform.position.z + columnDisctanceFromPosition);

            GameObject laser2 = Instantiate(laserModel, new Vector3(0, 0, 0), Quaternion.AngleAxis(0, Vector3.zero), parent);
            //laser2.transform.SetParent(parent);
            laser laserScript2 = laser2.GetComponent<laser>();
            laserScript2.aim = new Vector3(this.transform.position.x, middleColumn + Configuration.laserGateGround - (i + 1) * placeBetweenLasers, this.transform.position.z - columnDisctanceFromPosition);
            laserScript2.start = new Vector3(this.transform.position.x, middleColumn + Configuration.laserGateGround - (i + 1) * placeBetweenLasers, this.transform.position.z + columnDisctanceFromPosition);
        }
    }
}
