using UnityEngine;

public class EdgeTrigger : MonoBehaviour {

    private StartActions sa;
    private HighData highData;

    // Use this for initialization
    void Start () {
	    sa = GameObject.Find(Configuration.actionMenuName).GetComponent<StartActions>();
        highData = this.transform.GetComponent<HighData>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(highData.boxes.Count > 0)
        {
            return;
        }
        Collider[] colliders = Physics.OverlapBox(this.transform.position, new Vector3(25, 150, 25));
        for (int i = 0; i < colliders.Length; i++)
        {
            JoeCommandControl joeController = colliders[i].GetComponent<JoeCommandControl>();
            if (!joeController)
            {
                continue;
            }
            if (joeController)
            {
                //Debug.Log("Edge");
                sa.EdgeHit();
            }
        }
    }
}
