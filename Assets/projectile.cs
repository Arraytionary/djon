using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;
    public GameObject destroyEffect;
    //private Vector3 travelVal = Vector2.right * speed * Time.deltaTime;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distance, whatIsSolid);
        if (hitInfo.collider)
        {
            Debug.Log(hitInfo.collider);
            DestroyProjectile();

            if (hitInfo.collider.tag.Equals("Enemy"))
            {

                hitInfo.collider.GetComponentInParent<WalkingEnemy>().TakeDamage(0.2f, false);
                

            }
            else if (hitInfo.collider.tag.Equals("Head"))
            {
                hitInfo.collider.GetComponentInParent<WalkingEnemy>().TakeDamage(0.4f, true);
            }
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
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
