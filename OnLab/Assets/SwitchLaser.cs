using UnityEngine;

public class SwitchLaser : MonoBehaviour {

    private int objectOnIt = 0;
    private MapGenerator mapGenerator;

    private void Start()
    {
        mapGenerator = GameObject.Find(Configuration.mapGeneratorName).transform.GetComponent<MapGenerator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(objectOnIt == 0)
        {
            //Laser switch off
            mapGenerator.LaserSwitchOff();
        }
        objectOnIt++;
    }

    public void OnTriggerExit(Collider other)
    {
        if(objectOnIt == 1)
        {
            //Laser switch on
            mapGenerator.LaserSwitchOn();
        }
        objectOnIt--;
    }
}
