using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingRound : MonoBehaviour {

    public GameObject risingRound;
    public GameObject character;
    public TunnelDoor tunnelDoor;
    public GameObject switchLevelUp;
    public GameObject switchLevelDown;

    public float risingAmount;
    public float risingTime;
    private bool rising = false;
    private float risingSpeed;

    public float tunnelOpenStartTime;
    public float fallingStartTime;

    public float insideRisingTime;
    private bool inside = false;
    private float insideRisingSpeed;

    public float fallingTime;
    private bool falling = false;
    private float fallingSpeed;

    public float fallInsideTheGroundAmount;
    public float fallInsideTheGroundTime;
    private bool fallInsideTheGround = false;
    private float fallInsideTheGroundSpeed;

    public Camera cam;
    private Quaternion originalCameraRotation;

	// Use this for initialization
	void Start () {
        originalCameraRotation = cam.transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        if (rising)
        {
            if(risingTime - Time.deltaTime > 0)
            {
                risingTime -= Time.deltaTime;
                risingRound.transform.position += new Vector3(0, risingSpeed * Time.deltaTime, 0);
                character.transform.position += new Vector3(0, risingSpeed * Time.deltaTime, 0);
                cam.transform.LookAt(character.transform);
            }
            else
            {
                rising = false;
            }
        }
        else if (inside)
        {
            if (insideRisingTime - Time.deltaTime > 0)
            {
                insideRisingTime -= Time.deltaTime;
                risingRound.transform.position += new Vector3(0, insideRisingSpeed * Time.deltaTime, 0);
                character.transform.position += new Vector3(0, insideRisingSpeed * Time.deltaTime, 0);
            }
            else
            {
                PreparLevel.inAnimation = false;
                PreparLevel.switchLevelFromLower = false;
                switchLevelDown.SetActive(true);
                inside = false;
                character.GetComponent<JOE_Anim_Manager>().ShowAnim();
            }
        }
        else if (fallInsideTheGround)
        {
            if(fallInsideTheGroundTime - Time.deltaTime > 0)
            {
                fallInsideTheGroundTime -= Time.deltaTime;
                risingRound.transform.position += new Vector3(0, -fallInsideTheGroundSpeed * Time.deltaTime, 0);
                character.transform.position += new Vector3(0, -fallInsideTheGroundSpeed * Time.deltaTime, 0);
            }
            else
            {
                fallInsideTheGround = false;
            }
        }
        else if (falling)
        {
            if (fallingTime - Time.deltaTime > 0)
            {
                fallingTime -= Time.deltaTime;
                risingRound.transform.position += new Vector3(0, -fallingSpeed * Time.deltaTime, 0);
                character.transform.position += new Vector3(0, -fallingSpeed * Time.deltaTime, 0);
                cam.transform.LookAt(character.transform);
            }
            else
            {
                PreparLevel.inAnimation = false;
                PreparLevel.switchLevelFromHigher = false;
                cam.transform.rotation = originalCameraRotation;
                switchLevelUp.SetActive(true);
                falling = false;
                character.GetComponent<JOE_Anim_Manager>().ShowAnim();
            }
        }
    }

    public void RiseUp()
    {
        if (PreparLevel.inAnimation)
        {
            return;
        }
        character.GetComponent<JOE_Anim_Manager>().AnimEnd();
        PreparLevel.inAnimation = true;
        rising = true;
        risingSpeed = risingAmount / risingTime;
        tunnelDoor.InvokeStartOpen(tunnelOpenStartTime);
    }

    public void RiseFromInsideTheGround(float insideDistance)
    {
        inside = true;
        insideRisingSpeed = insideDistance / insideRisingTime;

    }

    public void FallInsideTheGround()
    {
        if (PreparLevel.inAnimation)
        {
            return;
        }
        character.GetComponent<JOE_Anim_Manager>().AnimEnd();
        PreparLevel.inAnimation = true;
        fallInsideTheGround = true;
        fallInsideTheGroundSpeed = fallInsideTheGroundAmount / fallInsideTheGroundTime;
    }

    public void GoDown(float fallingDistance)
    {
        Invoke("StartFalling", fallingStartTime);
        fallingSpeed = fallingDistance / fallingTime;
        tunnelDoor.startOpen();
    }

    private void StartFalling()
    {
        falling = true;
    }
}
