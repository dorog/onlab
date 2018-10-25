using UnityEngine;

public class PreparLevel : MonoBehaviour {

    private static bool inAnimation = false;
    private static bool switchLevelFromLower = false;
    private static bool switchLevelFromHigher = false;

    [Header("GameObjects")]
    [SerializeField]
    private GameObject character;
    [SerializeField]
    private GameObject risingRound;
    [SerializeField]
    private RisingRound risingRoundScript;

    [Header("Level Change Settings")]
    [SerializeField]
    public float insideTheRisingRound = 150;
    [SerializeField]
    public float insideTheRoof = 900;

    public static bool InAnimation
    {
        get
        {
            return inAnimation;
        }

        set
        {
            inAnimation = value;
        }
    }

    public static bool SwitchLevelFromLower
    {
        get
        {
            return switchLevelFromLower;
        }

        set
        {
            switchLevelFromLower = value;
        }
    }

    public static bool SwitchLevelFromHigher
    {
        get
        {
            return switchLevelFromHigher;
        }

        set
        {
            switchLevelFromHigher = value;
        }
    }

    void Start () {
        if (SwitchLevelFromLower)
        {
            cameFromLowerLevel();
        }
        else if (SwitchLevelFromHigher)
        {
            cameFromHigherLevel();
        }
    }

    private void cameFromLowerLevel()
    {
        character.transform.position -= new Vector3(0, insideTheRisingRound, 0);
        risingRound.transform.position -= new Vector3(0, insideTheRisingRound, 0);
        risingRoundScript.RiseFromInsideTheGround(insideTheRisingRound);
    }

    private void cameFromHigherLevel()
    {
        character.transform.position += new Vector3(0, insideTheRoof, 0);
        risingRound.transform.position += new Vector3(0, insideTheRoof, 0);
        risingRoundScript.GoDown(insideTheRoof);
        Camera.main.transform.LookAt(character.transform);
    }
}
