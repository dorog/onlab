using UnityEngine;

public class ButtonElement : MonoBehaviour {

    private bool used;
    MapGenerator mapGenerator;
    public Material usedMat;
    private Material originalMat;

    // Use this for initialization
    void Start()
    {
        mapGenerator = GameObject.Find(Configuration.mapGeneratorName).GetComponent<MapGenerator>();
        used = false;
        originalMat = this.transform.GetComponent<MeshRenderer>().material;
    }

    public void ActivateButton()
    {
        if (!used)
        {
            mapGenerator.ButtonActivated();
            used = true;
            //light up
            this.transform.GetComponent<MeshRenderer>().material = usedMat;
        }
        else
        {
            used = false;
            mapGenerator.ButtonDeactivated();
            this.transform.GetComponent<MeshRenderer>().material = originalMat;
        }
    }
}
