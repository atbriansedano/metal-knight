using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Player : MonoBehaviour
{
    //General Variables
    public Animator animator;

    //Character Health
    public int maxHealth = 20;
    public int playerHealth;

    //Character Combat
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    //Character Movement
    public Controller controller;
    public float runSpeed = 40f;
	float horizontalMove = 0f;
	bool jump = false, block = false;


    // Start is called before the first frame update
    void Start()
    {
        //Health Feature
        playerHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Character Combat
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f/ attackRate;
            }
        }    

        //Character Movement
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

        if (Input.GetMouseButtonDown(1)){
            block = true;
			animator.SetBool("isBlocking", true);
        }
        else if (Input.GetMouseButtonUp(1)){
           block = false;
		    animator.SetBool("isBlocking", false);
        }

    }

    public void Block()
    {

    }
   
    //MOVEMENT FUNCTIONS
    public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}

    //COMBAT FUNCTIONS
    public void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().EnemyTakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        
    }

    //HEALTH FUNCTION
    public void PlayerTakeDamage(int playerDamage)
    {
        animator.SetTrigger("Hurt");
        playerHealth -= playerDamage;
        if(playerHealth <= 0)
        {
            animator.SetBool("IsDead", true);
            this.enabled = false;

            SceneManager.LoadScene("DeathScreen");
        }
    }

    public void AddHealth()
    {
        playerHealth = maxHealth;
    }
}
