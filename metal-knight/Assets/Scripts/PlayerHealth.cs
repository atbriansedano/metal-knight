using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 10;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if(health <= 0)
        {
            //Destroy(gameObject); //Change to scene change
            SceneManager.LoadScene("DeathScreen");

        }
    }
}
