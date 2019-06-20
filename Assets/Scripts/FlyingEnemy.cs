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

    // public float health;
    // public GameObject blood;
    // public GameObject bodyBlood;
    // public GameObject destroyedEffect;

    public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    // Update is called once per frame
    void Update()
    {
        
        // if (Vector2.Distance(transform.position, player.position) > sightDistance)
        // {
            // StartCoroutine(FlyUp());
            // anim.SetBool("isDetect", false);
            // anim.SetBool("shouldAttack", false);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
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
    IEnumerator FlyUp(){
        yield return new WaitForSeconds(3f);
        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0f, 1f, 0f), 0.2f);
        
    }
}
