using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] projectilePrefab;
    [SerializeField] float secondSpawn = 0.5f, minTras, maxTras;

    void Start()
    {
        StartCoroutine(CSpawn());
    }

    IEnumerator CSpawn()
    {
        while(true)
        {
            var wanted = Random.Range(minTras,maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(projectilePrefab[Random.Range(0, projectilePrefab.Length)],
            position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    }
}