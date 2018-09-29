using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyEffect : ItemEffect
{
    public float rotationSpeed = 50;

    void Update()
    {
        this.transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
    }

}
