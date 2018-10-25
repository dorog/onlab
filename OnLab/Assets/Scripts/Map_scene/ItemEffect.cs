using UnityEngine;

public class ItemEffect : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == SharedData.playerTag)
        {
            ActualMapData.HaveItem = true;
        }
        Destroy(transform.gameObject);
    }
}
