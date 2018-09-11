using UnityEngine;

public class MakeBridge : MonoBehaviour {

    private GameObject mapGen;
    private bool used = false;

	// Use this for initialization
	void Start () {
        mapGen = GameObject.Find(Configuration.mapGeneratorName);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!used)
        {
            Transform BridgeElements = mapGen.transform.GetChild(5);
            for(int i=0; i<BridgeElements.childCount; i++)
            //for (int i = 0; i < 1; i++)
            {
                BridgeElements.transform.GetChild(i).GetComponent<RiseElement>().Rise();
            }
            used = true;
            mapGen.GetComponent<MapGenerator>().RiseBridgeElements();
        }
    }
}
