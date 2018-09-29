using UnityEngine;
using UnityEngine.UI;

public class ChangeBetweenFvAndMain : MonoBehaviour {

    public GameObject Main;
    public GameObject Fvs;
    public GameObject Fv1;
    public GameObject Fv2;
    public string MainString;
    public string FvString;
    public Text txt;

    private void Start()
    {
        txt.text = FvString;
    }

    public void Change()
    {
        bool change = Main.GetComponent<Image>().enabled;
        txt.text = change ? MainString : FvString;
        //Main
        Main.GetComponent<Image>().enabled = !change;
        Main.GetComponent<Image>().raycastTarget = change;
        Image[] allChildRenderers = Main.GetComponentsInChildren<Image>();

        foreach (Image R in allChildRenderers)
        {
            R.enabled = !change;
            R.raycastTarget = !change;
        }


        //Fvs
        Fvs.GetComponent<Image>().enabled = change;
        Fvs.GetComponent<Image>().raycastTarget = change;
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
