using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Player player;
    public int damage;

    private void OnTriggerEnter2D(Collider2D other){
        
        if(other.gameObject.tag == "Player") 
        {
            player.PlayerTakeDamage(damage);
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}