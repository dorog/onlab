using UnityEngine;

public class RisingRound : MonoBehaviour {

    [Header("GameObjects")]
    [SerializeField]
    private GameObject risingRound;
    [SerializeField]
    private GameObject character;
    [SerializeField]
    private TunnelDoor tunnelDoor;

    [Header("Rising Settings")]
    [SerializeField]
    private float risingAmount = 900;
    [SerializeField]
    private float risingTime = 10;
    private bool rising = false;
    private float risingSpeed;

    [Header("Tunnel Settings")]
    [SerializeField]
    private float tunnelOpenStartTime = 5;
    [SerializeField]
    private float fallingStartTime = 2;

    [Header("Arrive Higher Level Setting")]
    [SerializeField]
    private float insideRisingTime = 2;
    private bool inside = false;
    private float insideRisingSpeed;

    [Header("Fall Setting")]
    [SerializeField]
    private float fallingTime = 5;
    private bool falling = false;
    private float fallingSpeed;

    [Header("Fall inside Setting")]
    [SerializeField]
    private float fallInsideTheGroundAmount = 900;
    [Tooltip("Time while the character go inside the hole")]
    [SerializeField]
    private float fallInsideTheGroundTime = 10;
    private bool fallInsideTheGround = false;
    private float fallInsideTheGroundSpeed;

    private Camera cam;
    private Quaternion originalCameraRotation;

	void Start () {
        cam = Camera.main;
        originalCameraRotation = cam.transform.rotation;
    }
	
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
                PreparLevel.InAnimation = false;
                PreparLevel.SwitchLevelFromLower = false;
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
                PreparLevel.InAnimation = false;
                PreparLevel.SwitchLevelFromHigher = false;
                cam.transform.rotation = originalCameraRotation;
                falling = false;
                character.GetComponent<JOE_Anim_Manager>().ShowAnim();
            }
        }
    }

    public void RiseUp()
    {
        if (PreparLevel.InAnimation)
        {
            return;
        }
        character.GetComponent<JOE_Anim_Manager>().AnimEnd();
        PreparLevel.InAnimation = true;
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
        if (PreparLevel.InAnimation)
        {
            return;
        }
        character.GetComponent<JOE_Anim_Manager>().AnimEnd();
        PreparLevel.InAnimation = true;
        fallInsideTheGround = true;
        fallInsideTheGroundSpeed = fallInsideTheGroundAmount / fallInsideTheGroundTime;
    }

    public void GoDown(float fallingDistance)
    {
        Invoke("StartFalling", fallingStartTime);
        fallingSpeed = fallingDistance / fallingTime;
        tunnelDoor.StartOpen();
    }

    private void StartFalling()
    {
        falling = true;
    }
}
