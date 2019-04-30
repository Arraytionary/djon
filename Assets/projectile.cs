using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public GameObject destroyEffect;
    //private Vector3 travelVal = Vector2.right * speed * Time.deltaTime;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Debug.Log(transform.position);
        Debug.Log(transform.up * 9);
        //Instantiate(destroyEffect, transform.position + Vector3.Scale(transform.position, new Vector3(2f,2f,1f)), Quaternion.identity);
        Instantiate(destroyEffect, transform.position + transform.right * 1.1f, Quaternion.identity);
        //Vector3.Scale(transform.position, new Vector3(-2f, 2f, 1f)), Quaternion.identity);
        Destroy(gameObject);
    }
}
