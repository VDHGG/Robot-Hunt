using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPositions;
    public float startTime = 2f;
    private float timeBetweenSpawn;

    void Start()
    {
            timeBetweenSpawn = startTime;
    }


    void Update()
    {
        if(FindObjectOfType<GameManager>().isGameActive == false)
        {
            return;
        }

        if(timeBetweenSpawn <= 0f)
        {
            SpawnEnemy();
            timeBetweenSpawn = startTime;
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }

    void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemies.Length);
        int randomPosition = Random.Range(0, spawnPositions.Length);
        Instantiate(enemies[randomEnemy], spawnPositions[randomPosition].position, Quaternion.identity);
    }
}
