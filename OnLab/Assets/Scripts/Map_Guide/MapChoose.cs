using UnityEngine;

public class MapChoose : MonoBehaviour {

    private Camera cam;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                GameObject go = hit.transform.gameObject;
                GoToTheMap door= go.GetComponent<GoToTheMap>();
                if (!door)
                {
                    return;
                }
                door.GoMyMap();
            }
        }
	}
}
