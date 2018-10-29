using UnityEngine;
using UnityEngine.UI;

public class AutoGridLayout : MonoBehaviour {

    RectTransform rt;
    private GridLayoutGroup glg;

    [SerializeField]
    private int column = 7;
    [SerializeField]
    private int row = 7;
    [SerializeField]
    private int gridTop = 0;
    [SerializeField]
    private int gridRight = 0;
    [SerializeField]
    private int spacingX = 0;
    [SerializeField]
    private int spacingY = 0;

    private void Awake()
    {
        glg = GetComponent<GridLayoutGroup>();
        rt = GetComponent<RectTransform>();
        float cellSizeX = (rt.rect.width - (column-1) * spacingX - gridRight) / column;
        float cellSizeY = (rt.rect.height - (row-1) * spacingY - gridTop) / row;
        glg.cellSize = new Vector2(cellSizeX, cellSizeY);
        glg.spacing = new Vector2(spacingX, spacingY);
        glg.padding.top = gridTop;
        glg.padding.right = gridRight;
    }
}
