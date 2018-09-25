using UnityEngine;

public class Fall : MonoBehaviour {


    public float resetTime = 2;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapBox(this.transform.position, new Vector3(25, 150, 25));
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
            //joeController.fallALevel(1);
            /*joeController.fall = true;
            joeController.left_time = 0.5f;*/
            //joeTime = joeController.LavaFallAnimationTime;

            /*Animator anim = colliders[i].GetComponent<Animator>();
            if (anim == null)
            {
                continue;
            }
            anim.SetBool("lava", true);                
            anim.SetBool("start", false);
            sa.ObjectHit(resetTime + joeTime);*/

        }
    }
}
