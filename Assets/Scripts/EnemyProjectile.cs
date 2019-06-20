using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    //public GameObject player;
    public float speed;
    public float distance;
    public float damage;
    public LayerMask whatIsSolid;
    public GameObject destroyEffect;
    // Start is called before the first frame update
    void Start()
    {
        //playerPos = GameObject.FindGameObjectWithTag("Player").transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distance, whatIsSolid);
        if (hitInfo.collider)
        {
            Debug.Log(hitInfo.collider);
            DestroyProjectile();

            if (hitInfo.collider.tag.Equals("Player"))
            {

                hitInfo.collider.GetComponentInParent<playerControler>().TakeDamage(damage);
            }
            

            //transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        }
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        // Debug.Log(transform.position);
        // Debug.Log(transform.up * 9);
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        // Instantiate(destroyEffect, transform.position + transform.right * 1.1f, Quaternion.identity); to make explode effect at the same spot as the bullet
        //Vector3.Scale(transform.position, new Vector3(-2f, 2f, 1f)), Quaternion.identity);
        Destroy(gameObject);
    }
}
