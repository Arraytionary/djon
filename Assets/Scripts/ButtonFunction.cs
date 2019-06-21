using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunction : MonoBehaviour
{
    public void StartGame()
    {
        GlobalStats.Instance.stats["health"] = 1f;
        GlobalStats.Instance.stats["enemyToKill"] = 30f;
        GlobalStats.Instance.stats["enemyKilled"] = 0f;
        GlobalStats.LoadMainGame();
    }

    public void GotoMainMenu()
    {
        GlobalStats.LoadStartScene();
    }

    public void GoToHowToPlay()
    {
        GlobalStats.LoadHowTo();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
