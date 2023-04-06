using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHBar : MonoBehaviour
{
   
    public Player player;
    Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        if(player.playerHealth >= 0)
        {
        localScale.x = 0.03f * player.playerHealth;
        transform.localScale = localScale;
        }
    }
}