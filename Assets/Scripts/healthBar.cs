using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class healthBar : MonoBehaviour
{
    GameObject bar;

    void Start()
    {
        bar = gameObject.transform.Find("bar").gameObject;
        // bar.transform.localScale = new Vector3(.4f, 1f);
    }

    // TODO make a singleton to hold the health and use this update to sync the health bar
    void Update()
    {
        float crrHealth = Relu(GlobalStats.Instance.stats["health"]);
        bar.transform.localScale = new Vector3(crrHealth, 1f);
    }
    float Relu(float n){
        return Math.Max(0, n);
    }
}
