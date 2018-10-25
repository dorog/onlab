using UnityEngine;

public class SwitchLaser : MonoBehaviour {

    private int objectOnIt = 0;
    private MapGenerator mapGenerator;

    private void Start()
    {
        mapGenerator = MapGenerator.GetMapGenerator();
        if (mapGenerator == null)
        {
            Debug.LogError("SwitchLaser: MapGenerator is null!");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(objectOnIt == 0)
        {
            mapGenerator.LaserSwitchOff();
        }
        objectOnIt++;
    }

    public void OnTriggerExit(Collider other)
    {
        if(objectOnIt == 1)
        {
            mapGenerator.LaserSwitchOn();
        }
        objectOnIt--;
    }
}
