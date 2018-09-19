using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBetweenFvAndMain : MonoBehaviour {

    public GameObject Main;
    public GameObject Fvs;
    public string MainString;
    public string FvString;
    private Text txt;

    private void Start()
    {
        
    }

    public void Change()
    {
        bool change = Main.GetComponent<Image>().enabled;
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
        Fvs.transform.GetChild(0).gameObject.SetActive(change);
        Fvs.transform.GetChild(2).gameObject.SetActive(change);
    }
}
