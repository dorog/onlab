using UnityEngine;

public class JoeCommandControl : MonoBehaviour {

    public float rotate = 90;
    private float originTime=1;
    private float time;
    private Animator joeAnim;
    public CharacterController joeControll;

    private bool forward = false;
    private bool leftturn = false;
    private bool rightturn = false;

    public bool fall_trap = false;
    public float gravityForce = 20;

    public bool stopped = false;
    public bool gravityOff = false;

    private Vector3 aimPosition;
    public float fallSpeedCheck;

    //public Vector3 joeForward = new Vector3(1, 0, 0);

    // Use this for initialization
    void Start () {
        originTime = Configuration.timeForAnimation;
        time = Configuration.timeForAnimation;
        joeAnim = this.transform.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (!stopped)
        {
            if (fall_trap)
            {
                joeControll.Move(Vector3.down * Time.deltaTime * gravityForce);
            }

            if (forward)
            {
                if (time - Time.deltaTime > 0)
                {
                    //joeControll.Move(this.transform.forward * Configuration.unit * Time.deltaTime);
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
        if (!gravityOff)
        {
            fallSpeedCheck = Configuration.fallSpeed;
            joeControll.Move(new Vector3(0, Time.timeScale*Time.deltaTime*Configuration.fallSpeed*-1, 0));
        }
       
	}

    public void TurnRight()
    {
        //joeForward = Quaternion.Euler(0, rotate, 0) * joeForward;
        rightturn = true;
    }

    public void TurnLeft()
    {
        //joeForward = Quaternion.Euler(0, -rotate, 0) * joeForward;
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
        gravityOff = true;
        Invoke("CanFallNow", timeInTheAir);
        Animator anim = this.transform.GetComponent<Animator>();
        if (!anim)
        {
            return;
        }
        anim.SetBool(Configuration.idleAnimation, false);
        anim.SetBool(Configuration.trapAnimation, true);
    }

    private void CanFallNow()
    {
        fall_trap = true;
    }
}
