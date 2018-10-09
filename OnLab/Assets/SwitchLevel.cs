using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{
    public bool isUp = false;
    public float changeAfterHitTime = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (isUp)
        {
            Invoke("ChangeLevelUp", changeAfterHitTime);
        }
        else
        {
            Invoke("ChangeLevelDown", changeAfterHitTime);
        }
    }

    private void ChangeLevelUp()
    {
        PreparLevel.switchLevelFromLower = true;
        CurrentGameDatas.onLevel++;
        CurrentGameDatas.SaveLevel();
        SceneManager.LoadScene(Configuration.GetLevelName());
    }

    private void ChangeLevelDown()
    {
        PreparLevel.switchLevelFromHigher = true;
        CurrentGameDatas.onLevel--;
        CurrentGameDatas.SaveLevel();
        SceneManager.LoadScene(Configuration.GetLevelName());
    }
}
