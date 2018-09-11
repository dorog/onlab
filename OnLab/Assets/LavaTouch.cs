using UnityEngine;

public class LavaTouch : MonoBehaviour {

    StartActions sa;

    // Use this for initialization
    void Start () {
        sa = GameObject.Find(Configuration.actionMenuName).GetComponent<StartActions>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapBox(this.transform.position, new Vector3(500, 10, 500));
        //Debug.Log(colliders.Length);
        for (int i = 0; i < colliders.Length; i++)
        {
            JoeCommandControl joeController = colliders[i].GetComponent<JoeCommandControl>();
            //OnePushPerRound oppr = colliders[i].GetComponent<OnePushPerRound>();
            if (!joeController)
            {
                continue;
            }
            //Debug.Log("here");
            /*joeController.fall = true;
            joeController.left_time = 0.5f;*/
            //joeTime = joeController.LavaFallAnimationTime;

            /*Animator anim = colliders[i].GetComponent<Animator>();
            if (anim == null)
            {
                continue;
            }
            anim.SetBool("lava", true);                
            anim.SetBool("start", false);*/
            sa.ObjectHit(0.5f);

            //TODO: kulcsot nem tudja felvenni, animacio nem jatszodik le
        }
    }
}
