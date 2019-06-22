using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weap : MonoBehaviour
{
    public float offset;
    public GameObject projectile;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float rotY;
    public float zMul;

    public AudioClip musClip;
    public AudioSource audSource;

    private void Start()
    {
        audSource.clip = musClip;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, rotY, zMul * rotZ + offset);

        if (Input.GetMouseButtonDown(0) && timeBtwShots<=0)
        {
            Instantiate(projectile, shotPoint.position + transform.right * 0.7f, transform.rotation);
            timeBtwShots = startTimeBtwShots;

            audSource.Play();
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
