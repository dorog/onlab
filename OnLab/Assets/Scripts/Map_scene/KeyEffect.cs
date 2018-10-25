using UnityEngine;

public class KeyEffect : ItemEffect
{
    [SerializeField]
    private float rotationSpeed = 50;

    void Update()
    {
        transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
    }

}
