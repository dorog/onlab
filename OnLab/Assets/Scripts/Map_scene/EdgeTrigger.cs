using UnityEngine;

[RequireComponent(typeof(HighData))]
public class EdgeTrigger : MonoBehaviour
{
    private StartActions sa;
    private HighData highData;
    [SerializeField]
    private float resetTime = 1.5f;

    void Start()
    {
        sa = StartActions.GetStartActions();
        if (sa == null)
        {
            Debug.LogError("EdgeTrigger: Startaction is null!");
        }
        highData = transform.GetComponent<HighData>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (highData == null)
        {
            return;
        }
        if (highData.GetBoxCount() > 0)
        {
            return;
        }
        JoeCommandControl joeController = other.GetComponent<JoeCommandControl>();
        if (!joeController)
        {
            return;
        }
        sa.KilledBySomething(resetTime);
    }
}
