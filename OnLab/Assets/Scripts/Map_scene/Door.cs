using UnityEngine;

public class Door : MonoBehaviour
{

    private int count = 1;
    private bool used = false;
    public string doorAnimName = "DoorWidth_last";

    // Update is called once per frame
    void Update()
    {
        if (count == 0 && !used)
        {
            used = true;
            Animation anim = this.transform.GetComponent<Animation>();
            anim[doorAnimName].speed = anim[doorAnimName].length / Configuration.timeForAnimation;
            anim.Play();
            this.transform.GetComponent<DoorHighData>().opened = true;
        }
    }

    public void MoreCount()
    {
        if (count == 0)
        {
            used = false;
            Animation anim = this.GetComponent<Animation>();
            anim[doorAnimName].speed = -anim[doorAnimName].length / Configuration.timeForAnimation; ;
            anim[doorAnimName].time = anim[doorAnimName].length;
            anim.Play(doorAnimName);
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
