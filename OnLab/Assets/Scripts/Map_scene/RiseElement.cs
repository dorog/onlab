using UnityEngine;

[RequireComponent(typeof(HeightData))]
public class RiseElement : MonoBehaviour {

    private bool rising = false;
    private float rising_time = 0.5f;
    private float originRisingTime;

    [SerializeField]
    [Tooltip ("GameObject what the RiseElement generate under itself")]
    private GameObject underThis;
    private int rised = 1;

    private float speed;

    private Vector3 aimPosition;

    private HeightData myData;

    void Start()
    {
        speed = SharedData.heightUnit / SharedData.timeForAnimation;
        originRisingTime = SharedData.timeForAnimation;
        myData = GetComponent<HeightData>();
    }
	
	void Update () {
        if (rising)
        {
            if (rising_time - Time.deltaTime > 0)
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                rising_time -= Time.deltaTime;
            }
            else
            {
                transform.position = aimPosition;
                rising = false;
            }
        }
	}

    public void Rise()
    {
        Instantiate(underThis, transform.position + Vector3.down * SharedData.heightUnit * rised, transform.rotation, transform);
        aimPosition = transform.position + new Vector3(0, SharedData.heightUnit, 0);
        rised++;
        rising_time = originRisingTime;
        myData.BaseHeight++;
        for(int i=0; i<myData.GetBoxCount(); i++)
        {
            myData.GetBox(myData.GetBoxCount()-i-1).GetComponent<BoxController>().RiseBox();
        }
        rising = true;
    }
}
