using UnityEngine;

public class TrapActive : MonoBehaviour
{

    Animation trapAnim;
    StartActions sa;
    public float timeInTheAir = 4.7f;
    public float resetTime = 2;
    public int minNotKillHeigh = 1;
    private bool used = false;
    private TrapHighData trapHighData;
    public BoxCollider boxCollider;

    // Use this for initialization
    void Start()
    {
        trapAnim = this.transform.GetComponent<Animation>();
        sa = GameObject.Find(Configuration.actionMenuName).GetComponent<StartActions>();
        trapHighData = this.transform.GetComponent<TrapHighData>();
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
        if (trapHighData.GetRealBoxCount() >= minNotKillHeigh)
        {
            boxCollider.enabled = false;
            return;
        }
        else
        {
            JoeCommandControl joeController = other.GetComponent<JoeCommandControl>();
            if (joeController==null)
            {
                return;
            }
            if (joeController)
            {
                joeController.HitTrap(timeInTheAir);
                Invoke("CanFall", timeInTheAir);
                trapAnim.Play();
                sa.KilledByTrap(resetTime + timeInTheAir);
            }

        }
    }

    private void CanFall()
    {
        boxCollider.enabled = false;
    }
}
