using UnityEngine.SceneManagement;

public class GoHigherLevel : SwitchLevel
{
    public override void ChangeLevel()
    {
        if(PreparLevel.SwitchLevelFromHigher){
            return;
        }
        PreparLevel.SwitchLevelFromLower = true;
        CurrentGameDatas.onLevel++;
        CurrentGameDatas.SaveLevel();
        SceneManager.LoadScene(GameStructure.GetLevelName());
    }
}
