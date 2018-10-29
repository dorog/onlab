using UnityEngine;

public class WebCreator : MonoBehaviour {

    [SerializeField]
    private LineRenderer line;
    [SerializeField]
    private int columnCount;
    [SerializeField]
    private int rowCount;
    [SerializeField]
    private Vector3 startPosition;
    [SerializeField]
    private CreateMapElementOnIt MapElementPlace;

    public static string columnSprite = "";

    public int ColumnCount
    {
        get
        {
            return columnCount;
        }

        set
        {
            columnCount = value;
        }
    }

    public int RowCount
    {
        get
        {
            return rowCount;
        }

        set
        {
            rowCount = value;
        }
    }

    public Vector3 StartPosition
    {
        get
        {
            return startPosition;
        }

        set
        {
            startPosition = value;
        }
    }

    public CreateMapElementOnIt[,] map;

    void Start () {

        map = new CreateMapElementOnIt[RowCount, ColumnCount];

        for (int i=0; i<RowCount+1; i++)
        {
            GameObject webLine = Instantiate(line.gameObject, transform);
            LineRenderer webLineRenderer = webLine.GetComponent<LineRenderer>();
            webLineRenderer.positionCount = 2;
            Vector3 start = StartPosition + new Vector3(0, 0, -i * SharedData.widhtUnit);
            Vector3 end = StartPosition + new Vector3(ColumnCount * SharedData.widhtUnit, 0, -i * SharedData.widhtUnit);
            webLineRenderer.SetPosition(0, start);
            webLineRenderer.SetPosition(1, end);
        }
        for(int i=0; i<ColumnCount+1; i++)
        {
            GameObject webLine = Instantiate(line.gameObject, transform);
            LineRenderer webLineRenderer = webLine.GetComponent<LineRenderer>();
            webLineRenderer.positionCount = 2;
            Vector3 start = StartPosition + new Vector3(i * SharedData.widhtUnit, 0, 0);
            Vector3 end = StartPosition + new Vector3(i * SharedData.widhtUnit, 0, -RowCount * SharedData.widhtUnit);
            webLineRenderer.SetPosition(0, start);
            webLineRenderer.SetPosition(1, end);
        }
        for(int i=0; i<RowCount; i++)
        {
            for(int j = 0; j<ColumnCount; j++)
            {
                Vector3 location = StartPosition + new Vector3(j * SharedData.widhtUnit + SharedData.widhtUnit / 2, 0, -i * SharedData.widhtUnit - SharedData.widhtUnit / 2);
                GameObject mapElement = Instantiate(MapElementPlace.gameObject, location, Quaternion.identity, transform);
                CreateMapElementOnIt mapElementScript = mapElement.GetComponent<CreateMapElementOnIt>();
                map[i, j] = mapElementScript;
                mapElementScript.Row = i;
                mapElementScript.Column = j;
                if (i == 0 || i == RowCount-1) {
                    mapElementScript.edgeMapElementPlace = true;
                }
            }
        }
    }

    public void DisableMapPlace(int row, int column)
    {
        map[row, column].ElementOnIt = true;
    }

    public void EnableMapPlace(int row, int column)
    {
        map[row, column].ElementOnIt = false;
    }
}
