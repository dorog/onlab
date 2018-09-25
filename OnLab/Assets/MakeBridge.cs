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
            if (mapGen == null)
                return;
            used = true;
            mapGen.GetComponent<MapGenerator>().RiseBridgeElements(); 
           /* Transform BridgeElements = mapGen.transform.GetChild(5);
            for(int i=0; i<BridgeElements.childCount; i++)
            //for (int i = 0; i < 1; i++)
            {
                RiseElement riseEl = BridgeElements.GetChild(i).GetComponent<RiseElement>();
                if (riseEl == null)
                {
                    return;
                }
                riseEl.Rise();
            }
            used = true;
            mapGen.GetComponent<MapGenerator>().RiseBridgeElements();*/
        }
    }
}
