using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject bar = gameObject.transform.Find("bar").gameObject;
        bar.transform.localScale = new Vector3(.4f, 1f);
    }

    // TODO make a singleton to hold the health and use this update to sync the health bar
    void Update()
    {
        
    }
}
