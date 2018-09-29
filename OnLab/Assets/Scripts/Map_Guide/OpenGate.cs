using UnityEngine;

public class OpenGate : MonoBehaviour {

    private bool door_is_Opening = false;
    private Vector3 aimPosition;

    public float OpeningSpeed = 50;
    public float OpeningTime = 5;
    public Vector3 direction = new Vector3(1, 0, 0);
    public float distance = 300;

    // Use this for initialization
    void Start()
    {
        aimPosition = this.transform.position + direction * distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (door_is_Opening)
        {

            if (OpeningTime - Time.deltaTime >= 0)
            {
                this.transform.position += direction * Time.deltaTime * OpeningSpeed;
                OpeningTime -= Time.deltaTime;
            }
            else
            {
                this.transform.position = aimPosition;
                door_is_Opening = false;
            }
        }
    }

    public void OpenGateInstantly()
    {
        this.transform.position = this.transform.position + direction * distance;
    }

    public void OpenGateNew()
    {
        door_is_Opening = true;
    }
}
