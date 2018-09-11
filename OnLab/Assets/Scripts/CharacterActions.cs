using UnityEngine;

public class CharacterActions : MonoBehaviour 
{
    public void GoForward()
    {
        this.transform.position += this.transform.forward * 50;
    }

    public void TurnLeft()
    {
        this.transform.RotateAround(this.transform.position + this.transform.forward * 20, this.transform.up, -90);
    }

    public void TurnRight()
    {
        this.transform.RotateAround(this.transform.position + this.transform.forward * 20, this.transform.up, 90);
    }
}
