using UnityEngine;

public class JoeCommandControl : MonoBehaviour {

    public float rotate = 90;
    private float originTime = 1;
    private float time;
    private Animator joeAnim;

    private bool forward = false;
    private bool leftturn = false;
    private bool rightturn = false;

    public bool stopped = false;

    private Vector3 aimPosition;

    // Use this for initialization
    void Start() {
        originTime = Configuration.timeForAnimation;
        time = Configuration.timeForAnimation;
        joeAnim = this.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        if (!stopped)
        {
            if (forward)
            {
                if (time - Time.deltaTime > 0)
                {
                    this.transform.position += this.transform.forward * Configuration.unit * Time.deltaTime;
                    time -= Time.deltaTime;
                }
                else
                {
                    forward = false;
                    this.transform.position = new Vector3(aimPosition.x, this.transform.position.y, aimPosition.z);
                    time = originTime;
                    joeAnim.SetBool(Configuration.forwardAnimation, false);
                    joeAnim.SetBool(Configuration.idleAnimation, true);
                }
            }
            else if (leftturn)
            {
                if (time - Time.deltaTime <= 0)
                {
                    leftturn = false;
                    this.transform.Rotate(0, rotate * time * -1, 0);
                    time = originTime;
                }
                else
                {
                    this.transform.Rotate(0, rotate * Time.deltaTime * -1, 0);
                    time -= Time.deltaTime;
                }
            }
            else if (rightturn)
            {
                if (time - Time.deltaTime <= 0)
                {
                    rightturn = false;
                    this.transform.Rotate(0, rotate * time, 0);
                    time = originTime;
                }
                else
                {
                    this.transform.Rotate(0, rotate * Time.deltaTime, 0);
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
        aimPosition = this.transform.position + this.transform.forward * Configuration.unit;
        forward = true;
        joeAnim.SetBool(Configuration.idleAnimation, false);
        joeAnim.SetBool(Configuration.forwardAnimation, forward);

    }

    public void HitTrap(float timeInTheAir)
    {
        Animator anim = this.transform.GetComponent<Animator>();
        if (!anim)
        {
            return;
        }
        anim.SetBool(Configuration.idleAnimation, false);
        anim.SetBool(Configuration.trapAnimation, true);
    }
}
