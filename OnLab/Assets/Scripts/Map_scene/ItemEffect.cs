using UnityEngine;

public class ItemEffect : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Configuration.characterName)
        {
            CurrentGameDatas.HaveItem = true;
        }
        Destroy(this.transform.gameObject);
    }
}
