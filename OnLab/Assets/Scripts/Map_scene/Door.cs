using UnityEngine;

[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(GateHeightData))]
public class Door : MonoBehaviour
{
    private int count = 1;

    [SerializeField]
    private string doorAnimName = "DoorWidth_last";

    private GateHeightData doorHighData;
    private Animation anim;

    private void Start()
    {
        doorHighData = transform.GetComponent<GateHeightData>();
        anim = transform.GetComponent<Animation>();

        if (count == 0)
        {
            anim[doorAnimName].speed = anim[doorAnimName].length / SharedData.timeForAnimation;
            anim.Play();
            doorHighData.Opened = true;
        }
    }

    public void MoreCount()
    {
        if (count == 0)
        {
            anim[doorAnimName].speed = -anim[doorAnimName].length / SharedData.timeForAnimation;
            anim[doorAnimName].time = anim[doorAnimName].length;
            anim.Play(doorAnimName);
            doorHighData.Opened = false;
        }
        count++;
    }

    public void LessCount()
    {
        count--;
        if (count == 0)
        {
            anim[doorAnimName].speed = anim[doorAnimName].length / SharedData.timeForAnimation;
            anim.Play();
            doorHighData.Opened = true;
        }
    }

    public void SetCount(int count)
    {
        this.count = count;
    }
}
