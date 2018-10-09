using UnityEngine;

public class PreparLevel : MonoBehaviour {

    public static bool inAnimation = false;
    public static bool switchLevelFromLower = false;
    public static bool switchLevelFromHigher = false;
    public GameObject character;
    public GameObject risingRound;
    public RisingRound risingRoundScript;
    public GameObject SwitchLevelUp;
    public GameObject SwitchLevelDown;
    public float insideTheRisingRound;
    public float insideTheRoof;
    public GameObject levelChangeButtonGO;

	// Use this for initialization
	void Start () {
        if (switchLevelFromLower)
        {
            cameFromLowerLevel();
        }
        else if (switchLevelFromHigher)
        {
            cameFromHigherLevel();
        }
    }

    private void cameFromLowerLevel()
    {
        if (SwitchLevelDown != null)
        {
            SwitchLevelDown.SetActive(false);
        }
        character.transform.position -= new Vector3(0, insideTheRisingRound, 0);
        risingRound.transform.position -= new Vector3(0, insideTheRisingRound, 0);
        risingRoundScript.RiseFromInsideTheGround(insideTheRisingRound);
        switchLevelFromLower = false;
    }

    private void cameFromHigherLevel()
    {
        if (SwitchLevelUp != null)
        {
            SwitchLevelUp.SetActive(false);
        }
        character.transform.position += new Vector3(0, insideTheRoof, 0);
        risingRound.transform.position += new Vector3(0, insideTheRoof, 0);
        risingRoundScript.GoDown(insideTheRoof);
        Camera.main.transform.LookAt(character.transform);
    }
}
