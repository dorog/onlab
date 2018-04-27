using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActive : MonoBehaviour {

    Animation trapAnim;
    StartActions sa;
    public float resetTime = 2;

	// Use this for initialization
	void Start () {
        trapAnim = this.transform.GetComponent<Animation>();
        sa = GameObject.Find(Configuration.actionMenuName).GetComponent<StartActions>();

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapBox(this.transform.position, new Vector3(25, 150, 25));
        //Debug.Log(colliders.Length);
        float joeTime = 0;
        for(int i=0; i<colliders.Length; i++)
        {
            JoeCommandControl joeController = colliders[i].GetComponent<JoeCommandControl>();
            if (!joeController)
            {
                continue;
            }
            joeController.fall_trap = true;
            joeController.left_time = joeController.fallAnimationTime;
            joeTime = joeController.fallAnimationTime;
            Animator anim = colliders[i].GetComponent<Animator>();
            if (!anim)
            {
                continue;
            }
            anim.SetBool("fall", true);
            anim.SetBool("start", false);
            trapAnim.Play();
            sa.ObjectHit(resetTime + joeTime);
        }
        //Debug.Log(colliders.Length);
        
    }
}
