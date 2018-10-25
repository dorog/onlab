using UnityEngine;

public class TunnelDoor : MonoBehaviour {

    [Header("GameObjects")]
    [SerializeField]
    private GameObject rightDoor;
    [SerializeField]
    private GameObject leftDoor;

    [Header("Settings")]
    [SerializeField]
    private float openTime;
    private float originalOpenTime;
    [SerializeField]
    private float closeTime;
    private float originalCloseTime;
    [SerializeField]
    private float distance;
    [SerializeField]
    private float waitBetweenOpenAndClose;
    private float openSpeed;
    private float closeSpeed;
    private bool openDoor = false;
    private bool closeDoor = false;

	void Start () {
        originalOpenTime = openTime;
        originalCloseTime = closeTime;
    }
	
	void Update () {
        if (openDoor)
        {
            if(openTime - Time.deltaTime > 0)
            {
                openTime -= Time.deltaTime;
                rightDoor.transform.position += new Vector3(openSpeed * Time.deltaTime, 0, 0);
                leftDoor.transform.position += new Vector3(-openSpeed * Time.deltaTime, 0, 0);
            }
            else
            {
                openDoor = false;
                Invoke("CloseDoors", waitBetweenOpenAndClose);
            }
        }
        else if (closeDoor)
        {
            if (closeTime - Time.deltaTime > 0)
            {
                closeTime -= Time.deltaTime;
                rightDoor.transform.position += new Vector3(-closeSpeed * Time.deltaTime, 0, 0);
                leftDoor.transform.position += new Vector3(closeSpeed * Time.deltaTime, 0, 0);
            }
            else
            {
                closeDoor = false;
                // Todo: fade ?
            }
        }
	}

    public void StartOpen()
    {
        openDoor = true;
        openTime = originalOpenTime;
        closeTime = originalCloseTime;
        openSpeed = distance / openTime;
        closeSpeed = distance / closeTime;
    }

    public void InvokeStartOpen(float time)
    {
        Invoke("StartOpen", time);
    }

    private void CloseDoors()
    {
        closeDoor = true;
    }
}
