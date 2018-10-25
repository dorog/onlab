using UnityEngine;

public class LaserGate : MonoBehaviour {

    private int summSwitches;
    [Header("GameObjects for Instantiate")]
    [SerializeField]
    private GameObject laserModel;
    [SerializeField]
    private GameObject particalLaser;
    [Header("Laser's place Settings")]
    [SerializeField]
    private int middleColumn = 190;
    [SerializeField]
    private int laserPlaceInterval = 140;
    [SerializeField]
    private float columnDistanceFromMiddle = 50;
    [Header("Parent GameObject")]
    [SerializeField]
    private Transform parent;

    public int ActiveSwitches { get; set; }

    private float laserGateGround;

    private void Start()
    {
        if (laserModel.GetComponent<Laser>()==null)
        {
            Debug.LogError("LaserGate: laserModel has to have Laser script!");
        }
    }

    public void SetLasers(int _summSwitches, float _laserGround)
    {
        laserGateGround = _laserGround;
        ActiveSwitches = _summSwitches;
        summSwitches = _summSwitches;

        if (summSwitches % 2 == 1)
        {
            OddNumber();
        }
        else
        {
            EvenNumber();
        }
        for(int i=0; i<parent.childCount; i++)
        {
            parent.GetChild(i).GetComponent<Laser>().SwitchOn();
        }
    }

    public void SwitchedOffOne()
    {
        ActiveSwitches--;
        parent.GetChild(ActiveSwitches).gameObject.SetActive(false);
    }

    public void SwitchedOnOne()
    {
        parent.GetChild(ActiveSwitches).gameObject.SetActive(true);
        ActiveSwitches++;
    }

    public void ResetLaserGate()
    {
        for(int i=0; i<parent.childCount; i++)
        {
            parent.GetChild(i).gameObject.SetActive(true);
        }
        ActiveSwitches = summSwitches;
    }

    private void EvenNumber()
    {
        if(summSwitches == 0)
        {
            return;
        }
        float placeBetweenLasers = laserPlaceInterval / summSwitches;

        for (int i = 0; i < summSwitches / 2; i++)
        {
            GameObject laser = Instantiate(laserModel, new Vector3(0, 0, 0), Quaternion.AngleAxis(0, Vector3.zero), parent) as GameObject;
            Instantiate(particalLaser, new Vector3(transform.position.x, middleColumn + laserGateGround + (i + 0.5f) * placeBetweenLasers, transform.position.z - columnDistanceFromMiddle), Quaternion.AngleAxis(0, Vector3.zero), laser.transform);
            Laser laserScript = laser.GetComponent<Laser>();
            laserScript.aim = new Vector3(transform.position.x, middleColumn + laserGateGround + (i + 0.5f) * placeBetweenLasers, transform.position.z - columnDistanceFromMiddle);
            laserScript.start = new Vector3(transform.position.x, middleColumn + laserGateGround + (i + 0.5f) * placeBetweenLasers, transform.position.z + columnDistanceFromMiddle);

            GameObject laser2 = Instantiate(laserModel, new Vector3(0, 0, 0), Quaternion.AngleAxis(0, Vector3.zero), parent);
            Instantiate(particalLaser, new Vector3(transform.position.x, middleColumn + laserGateGround - (i + 0.5f) * placeBetweenLasers, transform.position.z - columnDistanceFromMiddle), Quaternion.AngleAxis(0, Vector3.zero), laser2.transform);
            Laser laserScript2 = laser2.GetComponent<Laser>();
            laserScript2.aim = new Vector3(transform.position.x, middleColumn + laserGateGround - (i + 0.5f) * placeBetweenLasers, transform.position.z - columnDistanceFromMiddle);
            laserScript2.start = new Vector3(transform.position.x, middleColumn + laserGateGround - (i + 0.5f) * placeBetweenLasers, transform.position.z + columnDistanceFromMiddle);
        }
    }
    
    private void OddNumber()
    {
        GameObject middleLaser = Instantiate(laserModel, new Vector3(0, 0, 0), Quaternion.AngleAxis(0, Vector3.zero), parent);
        Laser middleLaserScript = middleLaser.GetComponent<Laser>();
        middleLaserScript.aim = new Vector3(transform.position.x, middleColumn + laserGateGround, transform.position.z - columnDistanceFromMiddle);
        middleLaserScript.start = new Vector3(transform.position.x, middleColumn + laserGateGround, transform.position.z + columnDistanceFromMiddle);

        if (summSwitches == 1)
        {
            return;
        }

        float placeBetweenLasers = laserPlaceInterval / summSwitches;

        for (int i = 0; i < summSwitches / 2; i++)
        {
            GameObject laser = Instantiate(laserModel, new Vector3(0, 0, 0), Quaternion.AngleAxis(0, Vector3.zero), parent);
            Laser laserScript = laser.GetComponent<Laser>();
            laserScript.aim = new Vector3(transform.position.x, middleColumn + laserGateGround + (i + 1) * placeBetweenLasers, transform.position.z - columnDistanceFromMiddle);
            laserScript.start = new Vector3(transform.position.x, middleColumn + laserGateGround + (i + 1) * placeBetweenLasers, transform.position.z + columnDistanceFromMiddle);

            GameObject laser2 = Instantiate(laserModel, new Vector3(0, 0, 0), Quaternion.AngleAxis(0, Vector3.zero), parent);
            Laser laserScript2 = laser2.GetComponent<Laser>();
            laserScript2.aim = new Vector3(transform.position.x, middleColumn + laserGateGround - (i + 1) * placeBetweenLasers, transform.position.z - columnDistanceFromMiddle);
            laserScript2.start = new Vector3(transform.position.x, middleColumn + laserGateGround - (i + 1) * placeBetweenLasers, transform.position.z + columnDistanceFromMiddle);
        }
    }
}
