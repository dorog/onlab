using UnityEngine;

public class UFO_Move : MonoBehaviour {

    [Header("UFO door")]
    [SerializeField]
    private GameObject door;

    [Header("Rising settings")]
    [SerializeField]
    private float rising_time = 3;
    private float originRisingTime;
    [SerializeField]
    private float rising_speed = 5;
    private float originRisingSpeed;

    [Header("Flying settings")]
    [SerializeField]
    private float flying_time = 3;
    private float originDistanceJump;
    [SerializeField]
    private float jumpUpPower = 3;
    private float originJumpUp;
    [SerializeField]
    private float jumpXpower = 3;
    private float originJumpX;

    [Header("Flying away settings")]
    [SerializeField]
    private float waitBeforeJump = 3;
    private float originWaitBeforeJump;
    [SerializeField]
    public float place_door_open_time = 3;
    private float originDoorOpenTime;

    private bool animation_start = false;
    private bool doorIsOpen = false;

    [Header("Flying back settings")]
    [SerializeField]
    private float return_time = 3;
    private float originReturnTime;
    [SerializeField]
    private float jumpDownPower = 3;
    private float originJumpDown;
    [SerializeField]
    private float jumpBackPower = 3;
    private float originJumpBack;

    [Header("Hover settings")]
    [SerializeField]
    private float waitBeforaLanding = 3;
    private float originWaitBeforeLanding;

    [Header("Landing time")]
    [SerializeField]
    private float landing_time = 3;
    private float originLandingTime;
    [SerializeField]
    private float landing_speed = 5;
    private float originLandingSpeed;

    private bool firstHere = true;
    private bool animation_back = false;

    private Vector3 risedAimPosition;
    private Vector3 flyAwayPosition;

    private Vector3 originPosition;

	void Start () {

        originPosition = transform.position;

        // Save Fly away setting
        originRisingTime = rising_time;
        originRisingSpeed = rising_speed;
        originDistanceJump = flying_time;
        originJumpUp = jumpUpPower;
        originJumpX = jumpXpower;
        originWaitBeforeJump = waitBeforeJump;
        originDoorOpenTime = place_door_open_time;

        // Save Return settings
        originReturnTime = return_time;
        originJumpDown = jumpDownPower;
        originJumpBack = jumpBackPower;
        originWaitBeforeLanding = waitBeforaLanding;
        originLandingSpeed = landing_speed;
        originLandingTime = landing_time;
    }
	
	void Update () {

        // Rising
        if (animation_start && doorIsOpen)
        {
            if(rising_time - Time.deltaTime > 0)
            {
                transform.position += new Vector3(0, 1, 0) * Time.deltaTime * rising_speed;
                rising_time -= Time.deltaTime;
            }
            else if(rising_time >= 0)
            {
                transform.position = risedAimPosition;
                rising_time = -1;
            }
            else if(waitBeforeJump - Time.deltaTime >= 0)
            {
                waitBeforeJump -= Time.deltaTime;
            }
            else if(flying_time - Time.deltaTime > 0)
            {
                transform.position += new Vector3(Time.deltaTime*jumpXpower, Time.deltaTime * jumpUpPower, 0);
                flying_time -= Time.deltaTime;
            }
            else if(flying_time >= 0)
            {
                transform.position = flyAwayPosition;
                flying_time = -1;
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
            place_door_open_time -= Time.deltaTime;
            if(place_door_open_time <= 0)
            {
                doorIsOpen = true;
            }
        }

        // Come back
        if (animation_back)
        {
            if (return_time - Time.deltaTime > 0)
            {           
                if (firstHere)
                {
                    door.GetComponent<Animation>().Play();
                    firstHere = false;
                }
                transform.position -= new Vector3(Time.deltaTime * jumpBackPower, Time.deltaTime * jumpDownPower, 0);
                return_time -= Time.deltaTime;
            }
            else if (return_time >= 0)
            {
                transform.position = risedAimPosition;
                return_time = -1;
            }
            else if(waitBeforaLanding - Time.deltaTime >= 0)
            {
                waitBeforaLanding -= Time.deltaTime;
            }
            else if(landing_time - Time.deltaTime >= 0)
            {
                transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * landing_speed;
                landing_time -= Time.deltaTime;
            }
            else if(landing_time >= 0)
            {
                transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * landing_speed;
                landing_time = -1;
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
                transform.position = originPosition;
            }
        }
	}

    public void Start_animation()
    {
        animation_start = true;
        risedAimPosition = originPosition + new Vector3(0, 1, 0) * rising_time * rising_speed;
        flyAwayPosition = risedAimPosition + new Vector3(flying_time * jumpXpower, flying_time * jumpUpPower, 0);
    }

    public void Come_back()
    {
        animation_back = true;
    }
}
