using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float velocity;
    private float moveInput;
    public GameObject weapon;
    private Animator anim;
    public float health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // anim.SetBool("isAttacked", false);
        moveInput = Input.GetAxisRaw("Horizontal");
        if(moveInput == 1)
        {
            anim.SetBool("isRunning", true);
            transform.eulerAngles = new Vector3(0, 0, 0);
            weapon.GetComponent<weap>().offset = 0;
            weapon.GetComponent<weap>().rotY = 0;
            weapon.GetComponent<weap>().zMul = 1;
            //weapon.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(moveInput == -1)
        {
            anim.SetBool("isRunning", true);
            transform.eulerAngles = new Vector3(0, 180, 0);
            weapon.GetComponent<weap>().offset = -180;
            weapon.GetComponent<weap>().rotY = 180;
            weapon.GetComponent<weap>().zMul = -1;
            //weapon.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        velocity = moveInput * speed;
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    public void TakeDamage(float damage)
    {
        anim.SetTrigger("isAttacked");
        //anim.Play("take damage", 0);
        GlobalStats.Instance.stats["health"] -= damage;
        // health -= damage;

        //anim.Rebind();
    }

}
