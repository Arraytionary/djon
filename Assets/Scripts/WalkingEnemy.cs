﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour
{
    public Animator anim;
    //private Collider2D
    public float speed;
    public float runningSpeed;
    public Transform player;
    public float sightDistance;
    public float attackRange;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float damage;

    private float tBA;
    public float sTBA;

    public float health;
    public GameObject blood;

    void Start()
    {
        //anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    // Update is called once per frame
    void Update()
    {
        //HeadExplode();
        //anim.SetBool("shouldAttack", false);
        if (Vector2.Distance(transform.position, player.position) > sightDistance)
        {
            anim.SetBool("isDetect", false);
            anim.SetBool("shouldAttack", false);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isDetect", true);
            //anim.Play("detect", 0);
            //anim.Rebind();
            if (Time.time - tBA >= 0)
            {
                if (Vector2.Distance(transform.position, player.position) < attackRange)
                {

                    //Debug.Log(Time.time - tBA);

                    //StopAllCoroutines();
                    //StartCoroutine(Attack());
                    //Attack();
                    anim.SetTrigger("shouldAttack");
                    tBA = Time.time + sTBA;

                    //else
                    //{
                    //    tBA -= Time.deltaTime;
                    //}
                    anim.SetBool("isTooclose", true);
                }
                else
                {
                    anim.SetBool("isTooclose", false);
                    transform.position = Vector2.MoveTowards(transform.position, player.position, runningSpeed * Time.deltaTime);
                }
            }
        }
        //Debug.Log(Vector2.Distance(transform.position, player.position));
        //    switch (Vector2.Distance(transform.position, player.position))
        //    {
        //        case >sightDistance:
        //        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //    }
    }
    //IEnumerator
    public void Attack()
    {
        //anim.SetTrigger("shouldAttack");
        Collider2D[] inAtkRange = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i=0; i< inAtkRange.Length; i++)
        {
            Debug.Log(i);
            if (inAtkRange[i].CompareTag("Player"))
            {
                
                inAtkRange[i].GetComponent<playerControler>().TakeDamage(damage);
            }
        }
        //Debug.Log(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        //yield return new WaitForSeconds(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
       
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject, 0f);
        }
    }
    public void HeadExplode()
    {
        GameObject head = gameObject.transform.Find("Enemy").gameObject.transform.Find("head").gameObject;
        Vector3 headPos = head.transform.position;
        //Destroy(head, 0f);
        head.gameObject.SetActive(false);
        Instantiate(blood, headPos, Quaternion.identity);
    }
}
