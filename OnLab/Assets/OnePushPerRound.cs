using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePushPerRound : MonoBehaviour {

    private Vector3 direction;
    private bool Move = false;
    private Rigidbody body;
    public float time = 1.1f;
    private float originTime;

    public bool fall = false;
    public float left_time = 1;
    public float gravityForce = 240;
    public bool isFalled = false;

    private Vector3 aimPosition;

    public int x = 0;
    public int z = 0;

	// Use this for initialization
	void Start () {
        body = this.GetComponent<Rigidbody>();
        originTime = time/2; //  /2
        time = time / 2;
    }
	
	// Update is called once per frame
	void Update () {
        if (Move)
        {
            if (time - Time.deltaTime >= 0)
            {
                //

                //this.transform.Translate(this.transform.position + direction * Time.deltaTime * 100);
                body.MovePosition(this.transform.position + direction * Time.deltaTime * 100);



                //this.transform.Translate(this.transform.position + direction * Time.deltaTime * 50);
                //this.transform.GetComponent<CharacterController>().Move(direction * 50 * Time.deltaTime);
                time -= Time.deltaTime;
            }
            else if (time > 0)
            {
                if (Mathf.Pow(Mathf.Pow(this.transform.position.x - aimPosition.x, 2) + Mathf.Pow(this.transform.position.z - aimPosition.z, 2), 0.5f) < 25)
                {
                body.MovePosition(aimPosition);
                }
                else
                {
                this.transform.position = aimPosition - 50 * this.transform.forward;
                body.MovePosition(aimPosition - 50 * direction);

                }
                //body.MovePosition(aimPosition);


                //this.transform.Translate();
                //body.MovePosition(this.transform.position + direction * time * 50);

                //this.transform.Translate(this.transform.position + direction * time * 50); //dont working
                //this.transform.GetComponent<CharacterController>().Move(direction * 50 * time); //working except the walking on the roof
                Move = false;
                time = originTime;
            }

        }

        if (fall && (left_time - Time.deltaTime <= 0))
        {
            //this.transform.GetComponent<CharacterController>().Move(Vector3.down * Time.deltaTime * gravityForce);
            /*Debug.Log("itt");
            body.MovePosition(this.transform.position + new Vector3(0, -1, 0) * Time.deltaTime * gravityForce);*/
        }

        if (fall)
        {
            left_time -= Time.deltaTime;
        }

        //Debug.Log(fall + " " + left_time);
    }

    public void MoveToThere(Vector3 forward)
    {
        //this.GetComponent<BoxCollider>().isTrigger = true;
        if (!isFalled)
        {
            aimPosition = this.transform.position + forward * 50;
            //Debug.Log(aimPosition);
            Move = true;
            direction = forward;
            //called = true;
        }
        //this.GetComponent<BoxCollider>().isTrigger = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        /*Collider[] colliders = Physics.OverlapBox(this.transform.position, new Vector3(25, 150, 25));
        //Debug.Log(colliders.Length);
        for (int i = 0; i < colliders.Length; i++)
        {
            JoeCommandControl joeController = colliders[i].GetComponent<JoeCommandControl>();
            if (!joeController)
            {
                continue;
            }
            
        }*/
    }
}
