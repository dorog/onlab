using UnityEngine;

public abstract class SwitchLevel : MonoBehaviour
{
    public float changeAfterHitTime = 2;

    private void OnTriggerEnter(Collider other)
    {
        Invoke("ChangeLevel", changeAfterHitTime);
    }

    public virtual void ChangeLevel(){}
}
