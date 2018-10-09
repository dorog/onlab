using UnityEngine;

public class laser : MonoBehaviour {

    public LineRenderer lr;
    public Vector3 start;
    public Vector3 aim;	

    public void SwitchOn()
    {
        lr.SetPosition(0, start);
        lr.SetPosition(1, aim);
    }
}
