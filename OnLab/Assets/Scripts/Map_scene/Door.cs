using UnityEngine;

public class Door : MonoBehaviour {

    private int count = 1;
    private bool used = false;
    public float doorOpenSpeed = 2f;
    public string doorAnimName = "OpenWalledDoor";
	
	// Update is called once per frame
	void Update () {
        if (count == 0 && !used)
        {
            used = true;
            Animation anim = this.transform.GetComponent<Animation>();
            anim[doorAnimName].speed = doorOpenSpeed;
            anim.Play();
            this.transform.GetChild(this.transform.childCount - 1).gameObject.SetActive(true);
            this.transform.GetComponent<DoorHighData>().opened = true;
        }
    }

    public void MoreCount()
    {
        if (count == 0)
        {
            used = false;
            Animation anim = this.GetComponent<Animation>();
            anim[doorAnimName].speed = -doorOpenSpeed;
            anim[doorAnimName].time = anim[doorAnimName].length;
            anim.Play(doorAnimName);
            this.transform.GetChild(this.transform.childCount - 1).gameObject.SetActive(false);
            this.transform.GetComponent<DoorHighData>().opened = false;
        }
        count++;
    }

    public void LessCount()
    {
        count--;
    }

    public void SetCount(int count)
    {
        this.count = count;
    }
}
