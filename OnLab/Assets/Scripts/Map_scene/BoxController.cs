using UnityEngine;

public class BoxController : MonoBehaviour
{

    private Vector3 direction;
    private bool Move = false;
    public bool Rise = false;
    private Rigidbody body;
    private float time = 1.1f;
    private float originTime;

    private Vector3 aimPosition;
    public Transform onIt;

    private float plusHight;
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
            }

        }
        else if (Rise)
        {
            this.transform.position = onIt.position + new Vector3(0, plusHight, 0);
        }
    }

    public void MoveToThere(Vector3 forward)
    {
        aimPosition = this.transform.position + forward * 50;
        Move = true;
        direction = forward;
        time = originTime;
    }

    public void RiseBox(float time)
    {
        Rise = true;
        this.GetComponent<Rigidbody>().useGravity = false;
        Invoke("EndRising", time);
    }

    private void EndRising()
    {
        Rise = false;
        this.GetComponent<Rigidbody>().useGravity = true;
        this.transform.position = onIt.position + new Vector3(0, plusHight, 0);
    }

    public void InitOnIt(Transform onIt, int onItNumber)
    {
        this.onIt = onIt;
        plusHight = Configuration.unit * onItNumber;
    }
}
