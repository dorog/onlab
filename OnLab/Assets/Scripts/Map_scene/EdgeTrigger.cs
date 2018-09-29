using UnityEngine;

public class EdgeTrigger : MonoBehaviour
{

    private StartActions sa;
    private HighData highData;

    // Use this for initialization
    void Start()
    {
        sa = GameObject.Find(Configuration.actionMenuName).GetComponent<StartActions>();
        highData = this.transform.GetComponent<HighData>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (highData.boxes.Count > 0)
        {
            return;
        }
        JoeCommandControl joeController = other.GetComponent<JoeCommandControl>();
        if (!joeController)
        {
            return;
        }
        sa.EdgeHit();

    }
}
