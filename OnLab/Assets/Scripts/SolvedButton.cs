using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolvedButton : MonoBehaviour {

    private bool used;
    MapGenerator mapGenerator;

    // Use this for initialization
    void Start()
    {
        mapGenerator = GameObject.Find("MapGeneratorGO").GetComponent<MapGenerator>();
        used = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!used)
        {
            mapGenerator.lessCount();
            used = true;
        }
    }
}
