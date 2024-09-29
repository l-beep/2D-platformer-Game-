using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class zombie : MonoBehaviour
{
    Transform target;
    public Transform borderPoint;
    public int enemyLife = 100;
    public Animator animator;


    

private void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
   

 
    private void Update()
    {

        if(target.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
    }
    public void TakeDamage(int damageAmount)
    {
        enemyLife -= damageAmount;
        if(enemyLife > 0)
        {
            animator.SetTrigger("Damage");
        }
        else
        {
            animator.SetTrigger("death");
            GetComponent<BoxCollider2D>().enabled = false;
            this.enabled = false;
        }
    }
}
