using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Player : MonoBehaviour
{
    //General Variables
    public Animator animator;

    //Character Health
    public int maxHealth;
    public int playerHealth;

    //Character Combat
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;

    //Character Movement
    public Controller controller;
    public float runSpeed = 40f;
	float horizontalMove = 0f;
	bool jump = false;


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
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

        //Character Movement
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

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
        playerHealth -= playerDamage;
        if(playerHealth <= 0)
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }
}
