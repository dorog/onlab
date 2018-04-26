using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoeCommandControl : MonoBehaviour {

    public float rotate = 90;
    public float time = 1;
    private float originTime=1;
    private Animator joeAnim;
    private CharacterController joeControll;

    private bool forward = false;
    private bool leftturn = false;
    private bool rightturn = false;

    public bool fall_trap = false;
    public bool fall = false;
    public float gravityForce = 20;
    public float fallAnimationTime = 1.2f;
    public float LavaFallAnimationTime = 0.5f;

    public float left_time = 0;
    public bool stopped = false;
    public float gravity = 10;

    private Vector3 aimPosition;

    private bool push_box = false;

	// Use this for initialization
	void Start () {
        originTime = time;
        joeAnim = this.transform.GetComponent<Animator>();
        joeControll = this.transform.GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {

        if (!stopped)
        {
            if (fall_trap && (left_time - Time.deltaTime <= 0))
            {
                joeControll.Move(Vector3.down * Time.deltaTime * gravityForce);

            }

            if (fall && (left_time - Time.deltaTime <= 0))
            {
                joeControll.Move(Vector3.down * Time.deltaTime * gravityForce / 2);
            }

            if (fall_trap || fall)
            {
                left_time -= Time.deltaTime;
            }

            if (forward)
            {
                if (time - Time.deltaTime <= 0)
                {
                    forward = false;
                    this.transform.GetComponent<CharacterController>().Move(this.transform.forward * 50 * time);

                    if(Mathf.Pow(Mathf.Pow(this.transform.position.x-aimPosition.x, 2)+ Mathf.Pow(this.transform.position.z - aimPosition.z, 2), 0.5f) < 25){
                        this.transform.position = aimPosition;
                        //Debug.Log("if");
                    }
                    else
                    {
                        this.transform.position = aimPosition - 50 * this.transform.forward;
                        //Debug.Log("else");
                    }
                    //this.transform.position = aimPosition; // it will be certain
                    time = originTime;
                    joeAnim.SetBool("forward", false);
                    joeAnim.SetBool("start", true);
                }
                else
                {
                    this.transform.GetComponent<CharacterController>().Move(this.transform.forward * 50 * Time.deltaTime);
                    time -= Time.deltaTime;

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

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //A
        Rigidbody body = hit.collider.attachedRigidbody;
        if(body == null || body.isKinematic) { return; }
        //if (hit.moveDirection.y < -0.3) { return; } // 
        var pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);


        //A.1
        //body.MovePosition(body.position + new Vector3(1, 0, 0)*50*Time.deltaTime);

        //A.2
        //body.velocity = pushDir *50;

        //A.3
        //body.transform.Translate(body.transform.position + new Vector3(0, 0, 1) * 50*Time.deltaTime); //bad idea

        //A.4
        //body.MovePosition(body.transform.position + this.transform.forward*50);

        //C.
        /*OnePushPerRound body = hit.collider.GetComponent<OnePushPerRound>();
        if(body == null)
        {
            return;
        }
        body.MoveToThere(this.transform.forward);*/

        

    }

    public void GoForward()
    {
        aimPosition = this.transform.position + this.transform.forward * 50;
        forward = true;
        joeAnim.SetBool("start", false);
        joeAnim.SetBool("forward", forward);

    }

    public void ResetActions()
    {
        joeAnim.SetBool("start", true);
        joeAnim.SetBool("fall", false);
        joeAnim.SetBool("lava", false);
        fall_trap = false;
        fall = false;
    }
}
