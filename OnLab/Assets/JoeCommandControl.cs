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

    public bool fall = false;
    public float gravityForce = 20;
    public float fallAnimationTime = 1.2f;

	// Use this for initialization
	void Start () {
        originTime = time;
        joeAnim = this.transform.GetComponent<Animator>();
        joeControll = this.transform.GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (fall && (fallAnimationTime-Time.deltaTime<=0))
        {
            joeControll.Move(Vector3.down*Time.deltaTime*gravityForce);
        }
        else if(fall)
        {
            fallAnimationTime -= Time.deltaTime;
            //Debug.Log("else");
        }
        if (forward)
        {
            if (time - Time.deltaTime <= 0)
            {
                forward = false;
                this.transform.GetComponent<CharacterController>().Move(this.transform.forward*50*time);
                time = originTime;
                joeAnim.SetBool("forward", forward);

            }
            else
            {
                this.transform.GetComponent<CharacterController>().Move(this.transform.forward * 50 * Time.deltaTime);
                time -= Time.deltaTime;
            }
        }
        else if(leftturn)
        {
            if (time - Time.deltaTime <= 0)
            {
                leftturn = false;
                this.transform.Rotate(0, rotate*time*-1, 0);
                time = originTime;
             }
             else
             {
                this.transform.Rotate(0, rotate * Time.deltaTime*-1, 0);
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
        forward = true;
        joeAnim.SetBool("forward", forward);
    }
}
