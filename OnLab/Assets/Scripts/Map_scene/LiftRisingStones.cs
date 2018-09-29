using UnityEngine;

public class LiftRisingStones : MonoBehaviour {

    private GameObject mapGen;
    private bool used = false;

    // Use this for initialization
    void Start()
    {
        mapGen = GameObject.Find(Configuration.mapGeneratorName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!used)
        {
            if (mapGen == null)
                return;
            used = true;
            mapGen.GetComponent<MapGenerator>().RiseRisingStones();
        }
    }
}
