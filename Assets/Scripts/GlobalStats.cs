using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalStats : Singleton<GlobalStats>
{
    public IDictionary<string, float> stats = new Dictionary<string, float>(){
        {"health", 1f},
        {"enemyToKill", 30},
        {"enemyKilled",0 }
    };

    public static void LoadWinningScene(){
        LoadScene(2);
    }

    public static void LoadStartScene(){
        LoadScene(0);
    }

    public static void LoadDeadScene(){
        LoadScene(3);
    }

    private static void LoadScene(int scene){
        SceneManager.LoadScene(scene);
    }
}
