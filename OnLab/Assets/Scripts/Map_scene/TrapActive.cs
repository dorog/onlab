using UnityEngine;

[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(TrapHeightData))]
public class TrapActive : MonoBehaviour
{

    private Animation trapAnim;
    private StartActions sa;
    private bool used = false;
    private TrapHeightData trapHighData;

    [SerializeField]
    private float timeInTheAir = 4.7f;
    [SerializeField]
    private float resetTime = 2;
    [SerializeField]
    private int minNotKillHeigh = 1;
    [SerializeField]
    private BoxCollider trapSurface;
    [SerializeField]
    private string AnimName = "OpenTrap";

    // Use this for initialization
    void Start()
    {
        trapAnim = transform.GetComponent<Animation>();
        sa = StartActions.GetStartActions();
        if (sa == null)
        {
            Debug.LogError("SwitchLaser: StartActions is null!");
        }
        trapHighData = transform.GetComponent<TrapHeightData>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!used)
        {
            trapAnim.Play(AnimName);
            used = true;
        }
        if (trapHighData.GetRealBoxCount() >= minNotKillHeigh)
        {
            trapSurface.enabled = false;
            return;
        }
        else
        {
            JoeCommandControl joeController = other.GetComponent<JoeCommandControl>();
            if (joeController)
            {
                joeController.HitTrap(timeInTheAir);
                Invoke("CanFall", timeInTheAir);
                trapAnim.Play();
                sa.KilledBySomething(resetTime + timeInTheAir);
            }

        }
    }

    private void CanFall()
    {
        trapSurface.enabled = false;
    }
}
