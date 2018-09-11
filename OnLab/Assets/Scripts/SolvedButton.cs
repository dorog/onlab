using UnityEngine;

public class SolvedButton : MonoBehaviour {

    public bool used;
    MapGenerator mapGenerator;

    // Use this for initialization
    void Start()
    {
        mapGenerator = GameObject.Find(Configuration.mapGeneratorName).GetComponent<MapGenerator>();
        used = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapBox(this.transform.position, new Vector3(40, 40, 20));
        //Debug.Log(colliders.Length);
        for(int i=0; i<colliders.Length; i++)
        {
            Rigidbody body = colliders[i].GetComponent<Rigidbody>();
            if (!body)
            {
                continue;
            }
            if (!used)
            {
                mapGenerator.lessCount();
                used = true;
                //Debug.Log("mukszik " + used);
            }
        }
    }
}
