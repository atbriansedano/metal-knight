using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private float interval = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn(interval, prefab));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawn(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(25.18f, -3.37f,0), Quaternion.identity);
        StartCoroutine(Spawn(interval, enemy));
    }
}
