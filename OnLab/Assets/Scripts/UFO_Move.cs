using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO_Move : MonoBehaviour {

    public GameObject door;

    public float rising_time = 3;
    private float originRisingTime;
    public float rising_speed = 5;
    private float originRisingSpeed;

    public float flying_time = 3;
    private float originDistanceJump;
    public float jumpUpPower = 3;
    private float originJumpUp;
    public float jumpXpower = 3;
    private float originJumpX;

    public float waitBeforeJump = 3;
    private float originWaitBeforeJump;
    public float place_door_open_time = 3;
    private float originDoorOpenTime;
    public bool animation_start = false;
    private bool doorIsOpen = false;

    //return
    public float return_time = 3;
    private float originReturnTime;
    public float jumpDownPower = 3;
    private float originJumpDown;
    public float jumpBackPower = 3;
    private float originJumpBack;

    public float waitBeforaLanding = 3;
    private float originWaitBeforeLanding;

    public float landing_time = 3;
    private float originLandingTime;
    public float landing_speed = 5;
    private float originLandingSpeed;

    private bool firstHere = true;
    private bool animation_back = false;

    private Vector3 originPosition;

	// Use this for initialization
	void Start () {

        originPosition = this.transform.position;

        //fly away
        originRisingTime = rising_time;
        originRisingSpeed = rising_speed;
        originDistanceJump = flying_time;
        originJumpUp = jumpUpPower;
        originJumpX = jumpXpower;
        originWaitBeforeJump = waitBeforeJump;
        originDoorOpenTime = place_door_open_time;

        //return
        originReturnTime = return_time;
        originJumpDown = jumpDownPower;
        originJumpBack = jumpBackPower;
        originWaitBeforeLanding = waitBeforaLanding;
        originLandingSpeed = landing_speed;
        originLandingTime = landing_time;
    }
	
	// Update is called once per frame
	void Update () {

        //rising
        if (animation_start && doorIsOpen)
        {
            if(rising_time - Time.deltaTime >= 0)
            {
                this.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * rising_speed;
                rising_time -= Time.deltaTime;
            }
            //it must do no mistake
            else if(rising_time > 0)
            {
                this.transform.position += new Vector3(0, 1, 0) * rising_time * rising_speed;
                rising_time = 0;
            }
            //no problem if it wait a little less
            else if(waitBeforeJump - Time.deltaTime >= 0)
            {
                waitBeforeJump -= Time.deltaTime;
            }
            else if(flying_time - Time.deltaTime >= 0)
            {
                this.transform.position += new Vector3(Time.deltaTime*jumpXpower, Time.deltaTime * jumpUpPower, 0);
                flying_time -= Time.deltaTime;
            }
            else if(flying_time > 0)
            {
                this.transform.position += new Vector3(Time.deltaTime * jumpXpower, Time.deltaTime * jumpUpPower, 0);
                flying_time = 0;
            }
            else
            {
                animation_start = false;
                doorIsOpen = false;

                rising_time = originRisingTime;
                rising_speed = originRisingSpeed;
                flying_time = originDistanceJump;
                jumpUpPower = originJumpUp;
                jumpXpower = originJumpX;
                waitBeforeJump = originWaitBeforeJump;
                place_door_open_time = originDoorOpenTime;

            }
        }
        else if(animation_start)
        {
            // it can wait a little more
            place_door_open_time -= Time.deltaTime;
            if(place_door_open_time <= 0)
            {
                doorIsOpen = true;
            }
        }

        // come back
        if (animation_back)
        {
            if (return_time - Time.deltaTime >= 0)
            {           
                if (firstHere)
                {
                    door.GetComponent<Animation>().Play();
                    firstHere = false;
                }
                this.transform.position -= new Vector3(Time.deltaTime * jumpBackPower, Time.deltaTime * jumpDownPower, 0);
                return_time -= Time.deltaTime;
            }
            else if (return_time > 0)
            {
                this.transform.position -= new Vector3(Time.deltaTime * jumpBackPower, Time.deltaTime * jumpDownPower, 0);
                return_time = 0;
            }
            // it can wait a little more
            else if(waitBeforaLanding - Time.deltaTime >= 0)
            {
                waitBeforaLanding -= Time.deltaTime;
            }
            else if(landing_time - Time.deltaTime >= 0)
            {
                this.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * landing_speed;
                landing_time -= Time.deltaTime;
            }
            //it must be 100% correct
            else if(landing_time > 0)
            {
                this.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * landing_speed;
                landing_time = 0;
            }
            else
            {
                animation_back = false;
                firstHere = true;

                return_time = originReturnTime;
                jumpDownPower = originJumpDown;
                jumpBackPower = originJumpBack;
                waitBeforaLanding = originWaitBeforeLanding;
                landing_speed = originLandingSpeed;
                landing_time = originLandingTime;

                //in order to be the same location
                this.transform.position = originPosition;
            }
        }

	}

    public void Start_animation()
    {
        animation_start = true;
    }

    public void Come_back()
    {
        animation_back = true;
    }
}
