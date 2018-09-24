using UnityEngine;

public class KeyEffects : MonoBehaviour {

    public float rotationSpeed = 5;
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == Configuration.characterName)
        {
            CurrentGameDatas.HaveItem = true;
        }
        Destroy(this.transform.gameObject);
    }
}
