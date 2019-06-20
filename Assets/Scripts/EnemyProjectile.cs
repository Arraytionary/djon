using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Vector2 playerPos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
    }
}
