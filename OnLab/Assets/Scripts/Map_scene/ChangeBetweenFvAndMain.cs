using UnityEngine;
using UnityEngine.UI;

public class ChangeBetweenFvAndMain : MonoBehaviour {

    [Header("GameObjects")]
    [SerializeField]
    private GameObject Main;
    [SerializeField]
    private GameObject Fvs;
    [SerializeField]
    [Tooltip("Parent's of the fv1's slots")]
    private GameObject Fv1;
    [SerializeField]
    [Tooltip("Parent's of the fv2's slots")]
    private GameObject Fv2;
    [Header("Button's texts")]
    [SerializeField]
    private string MainString;
    [SerializeField]
    private string FvString;
    public Text txt;

    private Image mainImage;
    private Image fvsImage;

    private void Start()
    {
        txt.text = FvString;
        mainImage = Main.GetComponent<Image>();
        if(mainImage == null)
        {
            Debug.LogError("ChangeBetweenFvAndMain: Main GameObject has to have Image component!");
        }
        fvsImage = Fvs.GetComponent<Image>();
        if (fvsImage == null)
        {
            Debug.LogError("ChangeBetweenFvAndMain: Fvs GameObject has to have Image component!");
        }
    }

    public void Change()
    {
        bool change = mainImage.enabled;
        txt.text = change ? MainString : FvString;
        //Main
        mainImage.enabled = !change;
        mainImage.raycastTarget = change;
        Image[] allChildRenderers = Main.GetComponentsInChildren<Image>();

        foreach (Image R in allChildRenderers)
        {
            R.enabled = !change;
            R.raycastTarget = !change;
        }

        //Fvs
        fvsImage.enabled = change;
        fvsImage.raycastTarget = change;
        allChildRenderers = Fvs.GetComponentsInChildren<Image>();

        foreach (Image R in allChildRenderers)
        {
            R.enabled = change;
            R.raycastTarget = change;
        }
        Fv1.SetActive(change);
        Fv2.SetActive(change);
    }
}
