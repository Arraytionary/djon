using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnerLeft;
    public GameObject spawnerRight;
    public GameObject walkingEnemy;
    public GameObject flyingEnemy;
    public GameObject[] spawners;
    public GameObject[] enemyToSpawn;

    public float spawnCoolDown;
    private float crrTime;
    private int spawnNumber;
    // Start is called before the first frame update
    void Start()
    {
        spawners = new GameObject[]{spawnerLeft, spawnerRight};
        enemyToSpawn = new GameObject[] { walkingEnemy, flyingEnemy };
        spawnNumber = (int)GlobalStats.Instance.stats["enemyToKill"];
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnNumber > 0)
        {
            Debug.Log(Time.time - crrTime);
            if (Time.time - crrTime >= 0)
            {
                Vector2 spawnPoint = spawners[Random.Range(0, 2)].transform.position;
                GameObject toSpwan = enemyToSpawn[Random.Range(0, 2)];
                Instantiate(toSpwan, spawnPoint, Quaternion.identity);
                crrTime = spawnCoolDown + Time.time;

                spawnNumber--;
            }
        }
        else{
            GlobalStats.LoadStartScene();
        }
        
    }
}
