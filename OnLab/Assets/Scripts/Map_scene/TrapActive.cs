using UnityEngine;

public class TrapActive : MonoBehaviour
{

    Animation trapAnim;
    StartActions sa;
    public float timeInTheAir = 4.7f;
    public float resetTime = 2;
    public int minNotKillHeigh = 1;
    private bool used = false;
    private HighData highData;

    // Use this for initialization
    void Start()
    {
        trapAnim = this.transform.GetComponent<Animation>();
        sa = GameObject.Find(Configuration.actionMenuName).GetComponent<StartActions>();
        highData = this.transform.GetComponent<HighData>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!used)
        {
            if (trapAnim == null)
            {
                return;
            }
            trapAnim.Play();
            used = true;
        }
        if (highData.boxes.Count >= minNotKillHeigh)
        {
            return;
        }
        else
        {
            JoeCommandControl joeController = other.GetComponent<JoeCommandControl>();
            if (!joeController)
            {
                return;
            }
            if (joeController)
            {
                joeController.HitTrap(timeInTheAir);
                trapAnim.Play();
                sa.KilledByTrap(resetTime + timeInTheAir);
            }

        }
    }
}
