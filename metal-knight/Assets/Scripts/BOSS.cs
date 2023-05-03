using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BOSS : MonoBehaviour
{

    //Enemy AI
    public GameObject player;
    public GameObject enemy;
    public bool flip;
    public float speed;

    //Enemy Combat
    public int playerDamage;
    public Player playerHealth;
    public float cooldown;
    float lastHit;
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;
    public int enemyDamage;

    // Scene change
    public float delay = 2f;
    private IEnumerator coroutine;

    //Health
    public BOSS boss;
    Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        localScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        if(boss.currentHealth >= 0)
        {
        localScale.x = 0.03f * boss.currentHealth;
        transform.localScale = localScale;
        }
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
        //GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(enemy,1);

        coroutine = WaitAndLoadScene(delay);
        StartCoroutine(coroutine);
    }

    IEnumerator WaitAndLoadScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("NewSceneName");
    }
}
