using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    public Text toRender;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        toRender.text = GlobalStats.Instance.stats["enemyKilled"].ToString() + "/" + GlobalStats.Instance.stats["enemyToKill"].ToString();
    }
}
