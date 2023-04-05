using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy AI
    public GameObject player;
    public bool flip;
    public float speed;

    //Enemy Combat
    public int playerDamage;
    public Player playerHealth;
    public float cooldown;
    float lastHit;
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    public int enemyDamage;

    // Start is called before the first frame update
    void Start()
    {
        //Enemy Combat Feature
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //EnemyAI Feature
        Vector3 scale = transform.localScale;

        if(player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
            transform.Translate(speed * Time.deltaTime * -1,0, 0);
        }

        transform.localScale = scale;
    }

    //ENEMY COMBAT FUNCTIONS
    public void EnemyTakeDamage(int enemyDamage)
    {
        currentHealth -= enemyDamage;
        animator.SetTrigger("Hurt");

        
        if(currentHealth <= 0)
        {
            EnemyDie();
            
        }
    }
    
    void EnemyDie()
    {
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        
        if(collision.gameObject.tag == "Player") 
        {
            animator.SetTrigger("Attack");

            if (Time.time - lastHit < cooldown)
            {
                return;
            }
            lastHit = Time.time;
            playerHealth.PlayerTakeDamage(playerDamage);
        }
       
    }
    
}
