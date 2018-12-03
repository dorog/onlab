using UnityEngine;

[RequireComponent(typeof(HeightData))]
public class EdgeTrigger : MonoBehaviour
{
    private StartActions sa;
    private HeightData highData;
    [SerializeField]
    private float resetTime = 1.5f;

    void Start()
    {
        sa = StartActions.GetStartActions();
        if (sa == null)
        {
            Debug.LogError("EdgeTrigger: Startaction is null!");
        }
        highData = transform.GetComponent<HeightData>();
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
