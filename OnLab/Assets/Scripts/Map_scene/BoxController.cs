using UnityEngine;

public class BoxController : MonoBehaviour {

    private Vector3 direction;
    private bool Move = false;
    private bool Rise = false;
    private Rigidbody body;
    private float time = 1.1f;
    private float originTime;

    private Vector3 aimPosition;

    // Use this for initialization
    void Start()
    {
        body = this.GetComponent<Rigidbody>();
        originTime = Configuration.timeForBoxMove;
        time = Configuration.timeForBoxMove;
    }

    // Update is called once per frame
    void Update()
    {
        if (Move)
        {
            if (time - Time.deltaTime >= 0)
            {
                body.MovePosition(this.transform.position + direction * Time.deltaTime * 100);
                time -= Time.deltaTime;
            }
            else if (time > 0)
            {
                this.transform.position = aimPosition;
                Move = false;
                time = originTime;
                //this.GetComponent<Rigidbody>().useGravity = true;
            }

        }
        else if (Rise)
        {
            if (time - Time.deltaTime >= 0)
            {
                body.MovePosition(this.transform.position + new Vector3(0, Configuration.unit, 0)*Time.deltaTime/0.5f);
                time -= Time.deltaTime;
            }
            else if (time > 0)
            {
                body.transform.position = aimPosition;
                Rise = false;
                time = originTime;
                this.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    public void MoveToThere(Vector3 forward)
    {
        //this.transform.GetComponent<BoxCollider>().enabled = false;
         aimPosition = this.transform.position + forward * 50;
         Move = true;
         direction = forward;
         time = originTime;
    }

    public void RiseBox(float time)
    {
        Rise = true;
        this.GetComponent<Rigidbody>().useGravity = false;
        aimPosition = this.transform.position + new Vector3(0, Configuration.unit, 0);
        this.time = time;
    }
}
