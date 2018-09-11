using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour {

    NavMeshAgent character;

	// Use this for initialization
	void Start () {
        character = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	public void MoveToPoint(Vector3 point)
    {
        character.SetDestination(point);
    }
}
