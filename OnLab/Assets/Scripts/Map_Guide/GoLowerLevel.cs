using UnityEngine.SceneManagement;

public class GoLowerLevel : SwitchLevel
{

    public override void ChangeLevel()
    {
        if (PreparLevel.SwitchLevelFromLower)
        {
            return;
        }
        PreparLevel.SwitchLevelFromHigher = true;
        CurrentGameDatas.onLevel--;
        CurrentGameDatas.SaveLevel();
        SceneManager.LoadScene(GameStructure.GetLevelName());
        return;
    }
}
