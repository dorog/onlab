using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelDoor : MonoBehaviour {

    public GameObject rightDoor;
    public GameObject leftDoor;
    public float openTime;
    private float originalOpenTime;
    public float closeTime;
    private float originalCloseTime;
    public float distance;
    public float waitBetweenOpenAndClose;
    private float openSpeed;
    private float closeSpeed;
    private bool openDoor = false;
    private bool closeDoor = false;

	// Use this for initialization
	void Start () {
        originalOpenTime = openTime;
        originalCloseTime = closeTime;
    }
	
	// Update is called once per frame
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
                Invoke("closeDoors", waitBetweenOpenAndClose);
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

    public void startOpen()
    {
        openDoor = true;
        openTime = originalOpenTime;
        closeTime = originalCloseTime;
        openSpeed = distance / openTime;
        closeSpeed = distance / closeTime;
    }

    public void InvokeStartOpen(float time)
    {
        Invoke("startOpen", time);
    }

    private void closeDoors()
    {
        closeDoor = true;
    }
}
