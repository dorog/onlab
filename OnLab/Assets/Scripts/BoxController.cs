using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {

    private Vector3 direction;
    private bool Move = false;
    private Rigidbody body;
    public float time = 1.1f;
    private float originTime;

    //public bool fall = false;
    public float left_time = 1;
    public float gravityForce = 240;

    private Vector3 aimPosition;

    public int x = 0;
    public int z = 0;

    // Use this for initialization
    void Start()
    {
        body = this.GetComponent<Rigidbody>();
        originTime = time / 2; //  /2
        time = time / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Move)
        {
            if (time - Time.deltaTime >= 0)
            {
                body.MovePosition(this.transform.position + direction * Time.deltaTime * 100);
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
                Move = false;
                time = originTime;
            }

        }
    }

    public void MoveToThere(Vector3 forward)
    {
            aimPosition = this.transform.position + forward * 50;
            Move = true;
            direction = forward;

    }
}
