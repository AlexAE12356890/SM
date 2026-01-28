using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefab;

    public Transform[] spawnPoints;

    public int enemiesToSpawn = 5;
    
    private BoxCollider2D _boxCollider;

    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    /*void SpawnEnemy()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
         {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }*/
    
    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            foreach (Transform item in spawnPoints)
            {
                Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], item.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _boxCollider.enabled = false;
            StartCoroutine(SpawnEnemy());
        }
    }
}
