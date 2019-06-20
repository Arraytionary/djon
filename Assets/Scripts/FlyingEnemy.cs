using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public Animator anim;
    //private Collider2D
    public float speed;
    // public float runningSpeed;
    public Transform player;
    public float sightDistance;
    // public float attackRange;

    // public Transform attackPos;
    // public LayerMask whatIsEnemies;
    // public float damage;

    private float tBA;
    public float sTBA;

    public float retreatDistance;

    public float health;
    // public GameObject blood;
    public GameObject bodyBlood;
    public GameObject destroyedEffect;

    public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        
        // if (Vector2.Distance(transform.position, player.position) > sightDistance)
        // {
            // StartCoroutine(FlyUp());
            // anim.SetBool("isDetect", false);
            // anim.SetBool("shouldAttack", false);
            //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            // StopAllCoroutines();
        // }
        // else transform.position = player.position;
        if (Time.time - tBA >= 0){
            Vector3 difference = player.transform.position - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            // transform.rotation = Quaternion.Euler(0f, rotY, zMul * rotZ + offset);

            Instantiate(fire, transform.position,Quaternion.Euler(0f, 0f, rotZ + 90f));
            tBA = Time.time + sTBA;
        }
    }

    public void TakeDamage(float damage, bool headShot)
    {
        Debug.Log("FFFFFFFFFFFFFFFFFFFFF");
        Instantiate(bodyBlood, transform.position, Quaternion.identity);
        health -= damage;
        if (health <= 0)
        {
            StartCoroutine(Destroy(0.1f));
        }
    }

    IEnumerator Destroy(float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(gameObject, 0f);
        Instantiate(destroyedEffect, transform.position, Quaternion.identity);
        GlobalStats.Instance.stats["enemyKilled"] ++;
    }
}
