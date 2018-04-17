﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInLava : MonoBehaviour {

    StartActions sa;
    public float resetTime = 2;

    // Use this for initialization
    void Start()
    {

        sa = GameObject.Find("ActionMenuGO").GetComponent<StartActions>();

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapBox(this.transform.position, new Vector3(25, 150, 25));
        //Debug.Log(colliders.Length);
        float joeTime = 0;
        for (int i = 0; i < colliders.Length; i++)
        {
            Animator anim = colliders[i].GetComponent<Animator>();
            if (!anim)
            {
                continue;
            }
            anim.SetBool("lava", true);
            anim.SetBool("start", false);
            JoeCommandControl joeController = colliders[i].GetComponent<JoeCommandControl>();
            if (!joeController)
            {
                continue;
            }
            joeController.fall_lava = true;
            joeController.left_time = joeController.LavaFallAnimationTime;
            joeTime = joeController.LavaFallAnimationTime;
        }

        sa.ObjectHit(resetTime+joeTime);
    }
}
