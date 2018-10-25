using UnityEngine;

public class ButtonElement : MonoBehaviour {

    private bool used;
    private MapGenerator mapGenerator;
    [Tooltip("Material for change colour when the character activate it")]
    [SerializeField]
    private Material usedMat;
    private Material originalMat;

    void Start()
    {
        mapGenerator = MapGenerator.GetMapGenerator();
        if (mapGenerator == null)
        {
            Debug.LogError("ButtonElement: MapGenerator is null!");
        }
        used = false;
        originalMat = transform.GetComponent<MeshRenderer>().material;
    }

    public void ActivateButton()
    {
        if (!used)
        {
            mapGenerator.ButtonActivated();
            used = true;

            //light up
            transform.GetComponent<MeshRenderer>().material = usedMat;
        }
        else
        {
            used = false;
            mapGenerator.ButtonDeactivated();
            transform.GetComponent<MeshRenderer>().material = originalMat;
        }
    }
}
