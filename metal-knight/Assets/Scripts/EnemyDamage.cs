using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;
    public float cooldown;
    float lastHit;
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision) {
        
        
        if(collision.gameObject.tag == "Player") 
        {
            if (Time.time - lastHit < cooldown)
            {
                animator.SetBool("EnemyAttack", true);
                return;
            }
            lastHit = Time.time;
            playerHealth.TakeDamage(damage);
        }
         if(collision.gameObject.tag != "Player") 
        {
            animator.SetBool("EnemyAttack", false);
        }
       
    }
}