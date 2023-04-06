using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    
    public Enemy enemy;
    Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        if(enemy.currentHealth >= 0)
        {
        localScale.x = 0.03f * enemy.currentHealth;
        transform.localScale = localScale;
        }
    }
}
