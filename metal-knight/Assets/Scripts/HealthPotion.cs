using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{

    public Player player;
    public GameObject healthpotion;

    private void OnCollisionEnter2D(Collision2D collision) {
        
        
        if(collision.gameObject.tag == "Player") 
        {
            player.AddHealth();
            Destroy(healthpotion);
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
