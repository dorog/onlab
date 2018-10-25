using UnityEngine;

[RequireComponent(typeof(Animator))]
public class JoeCommandControl : MonoBehaviour {

    [SerializeField]
    [Range (0.0f, 360.0f)]
    private const float rotate = 90;
    [SerializeField]
    private float originTime = 1;
    private float time;

    private Animator joeAnim;

    private bool forward = false;
    private bool leftturn = false;
    private bool rightturn = false;

    public bool stopped = false;

    private Vector3 aimPosition;

    public static string forwardAnimation = "forward";
    public static string idleAnimation = "start";
    public static string trapAnimation = "trap";

    void Start() {
        originTime = SharedData.timeForAnimation;
        time = SharedData.timeForAnimation;
        joeAnim = transform.GetComponent<Animator>();
    }

    void Update() {

        if (!stopped)
        {
            if (forward)
            {
                if (time - Time.deltaTime > 0)
                {
                    transform.position += transform.forward * SharedData.unit * Time.deltaTime;
                    time -= Time.deltaTime;
                }
                else
                {
                    forward = false;
                    transform.position = new Vector3(aimPosition.x, transform.position.y, aimPosition.z);
                    time = originTime;
                    joeAnim.SetBool(forwardAnimation, false);
                    joeAnim.SetBool(idleAnimation, true);
                }
            }
            else if (leftturn)
            {
                if (time - Time.deltaTime <= 0)
                {
                    leftturn = false;
                    transform.Rotate(0, rotate * time * -1, 0);
                    time = originTime;
                }
                else
                {
                    transform.Rotate(0, rotate * Time.deltaTime * -1, 0);
                    time -= Time.deltaTime;
                }
            }
            else if (rightturn)
            {
                if (time - Time.deltaTime <= 0)
                {
                    rightturn = false;
                    transform.Rotate(0, rotate * time, 0);
                    time = originTime;
                }
                else
                {
                    transform.Rotate(0, rotate * Time.deltaTime, 0);
                    time -= Time.deltaTime;
                }
            }
        }
    }

    public void TurnRight()
    {
        rightturn = true;
    }

    public void TurnLeft()
    { 
        leftturn = true;
    }

    public void GoForward()
    {
        aimPosition = transform.position + transform.forward * SharedData.unit;
        forward = true;
        joeAnim.SetBool(idleAnimation, false);
        joeAnim.SetBool(forwardAnimation, forward);
    }

    public void HitTrap(float timeInTheAir)
    {
        joeAnim.SetBool(idleAnimation, false);
        joeAnim.SetBool(trapAnimation, true);
    }
}
