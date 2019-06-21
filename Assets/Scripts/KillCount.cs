using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    public Text toRender;
    public Animator anim;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        toRender.text = GlobalStats.Instance.stats["enemyKilled"].ToString() + "/" + GlobalStats.Instance.stats["enemyToKill"].ToString();
        if (GlobalStats.Instance.stats["enemyKilled"] == GlobalStats.Instance.stats["enemyToKill"])
        {
            anim.SetTrigger("fade");
            StartCoroutine(EndGame());
            
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1f);
        GlobalStats.LoadWinningScene();
    }
}
