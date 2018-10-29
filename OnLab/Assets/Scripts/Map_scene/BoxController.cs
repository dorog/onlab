using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoxController : MonoBehaviour
{
    private Vector3 direction;
    private bool Move = false;
    private bool Rise = false;
    private Rigidbody body;
    private float time;
    private float originTime;

    private Vector3 aimPosition;
    private float plusHight;

    public Transform OnIt { get; set; }

    private float timeForBoxMove = 0.55f;

    [SerializeField]
    private float QuatFloat = 0;
    [SerializeField]
    private Vector3 QuatVector = Vector3.right;

    public Quaternion GetQuat()
    {
        return Quaternion.AngleAxis(QuatFloat, QuatVector);
    }

    void Start()
    {
        body = GetComponent<Rigidbody>();
        originTime = timeForBoxMove;
        time = timeForBoxMove;
    }

    void Update()
    {
        if (Move)
        {
            if (time - Time.deltaTime >= 0)
            {
                body.MovePosition(transform.position + direction * Time.deltaTime * 100);
                time -= Time.deltaTime;
            }
            else if (time > 0)
            {
                transform.position = aimPosition;
                Move = false;
                time = originTime;
            }

        }
        else if (Rise)
        {
            transform.position = OnIt.position + new Vector3(0, plusHight, 0);
        }
    }

    public void MoveToThere(Vector3 forward)
    {
        aimPosition = transform.position + forward * 50;
        Move = true;
        direction = forward;
        time = originTime;
    }

    public void RiseBox()
    {
        Rise = true;
        body.useGravity = false;
        Invoke("EndRising", SharedData.timeForAnimation);
    }

    private void EndRising()
    {
        Rise = false;
        body.useGravity = true;
        transform.position = OnIt.position + new Vector3(0, plusHight, 0);
    }

    public void InitOnIt(Transform onIt, int onItNumber)
    {
        OnIt = onIt;
        plusHight = SharedData.heightUnit * onItNumber;
    }
}
