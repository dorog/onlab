using UnityEngine;

public class OpenGate : MonoBehaviour {

    private bool opening = false;
    private Vector3 aimPosition;

    [Header("Opening Settings")]
    [SerializeField]
    private float OpeningSpeed = 50;
    [SerializeField]
    private float OpeningTime = 5;
    [SerializeField]
    private Vector3 direction = new Vector3(1, 0, 0);
    [SerializeField]
    private float distance = 300;

    void Start()
    {
        aimPosition = transform.position + direction * distance;
    }

    void Update()
    {
        if (opening)
        {

            if (OpeningTime - Time.deltaTime >= 0)
            {
                transform.position += direction * Time.deltaTime * OpeningSpeed;
                OpeningTime -= Time.deltaTime;
            }
            else
            {
                transform.position = aimPosition;
                opening = false;
            }
        }
    }

    public void OpenGateInstantly()
    {
        transform.position = transform.position + direction * distance;
    }

    public void OpenGateNew()
    {
        opening = true;
    }
}
