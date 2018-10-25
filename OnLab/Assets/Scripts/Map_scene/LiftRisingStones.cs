using UnityEngine;

public class LiftRisingStones : MonoBehaviour {

    private MapGenerator mapGen;
    private bool used = false;

    void Start()
    {
        mapGen = MapGenerator.GetMapGenerator();
        if (mapGen == null)
        {
            Debug.LogError("LiftRisingStones: MapGenerator is null!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!used)
        {
            if (mapGen == null)
                return;
            used = true;
            mapGen.RiseRisingStones();
        }
    }
}
