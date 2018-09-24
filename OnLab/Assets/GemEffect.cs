using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemEffect : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Configuration.characterName)
        {
            CurrentGameDatas.HaveItem = true;
        }
        Destroy(this.transform.gameObject);
    }
}
