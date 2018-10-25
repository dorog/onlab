using UnityEngine;

public class MapChoose : MonoBehaviour {

    private Camera cam;

	void Start () {
        cam = Camera.main;
        if(cam == null)
        {
            Debug.LogError("MapChoose: No main camera, need one!");
        }
	}
	
	void Update () {
        if (PreparLevel.InAnimation)
        {
            return;
        }
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
