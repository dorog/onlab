using UnityEngine;
using UnityEngine.UI;

public class AutoGridLayout : MonoBehaviour {

    RectTransform rt;
    private GridLayoutGroup glg;

    [SerializeField]
    private int column = 7;
    [SerializeField]
    private int row = 7;

    private void Awake()
    {
        glg = GetComponent<GridLayoutGroup>();
        rt = GetComponent<RectTransform>();

        glg.cellSize = new Vector2(rt.rect.width / column, rt.rect.height / row);
    }

    /*void Start () {
        glg = GetComponent<GridLayoutGroup>();
        rt = GetComponent<RectTransform>();

        glg.cellSize = new Vector2(rt.rect.width / column, rt.rect.height / row);
	}*/
	
	// Update is called once per frame
	void Update () {
		
	}
}
