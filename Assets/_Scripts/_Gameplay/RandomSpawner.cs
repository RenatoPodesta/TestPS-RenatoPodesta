using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemyPrefabs;

    [SerializeField]
    Transform[] spawnPoints;

    [SerializeField]
    float spawnRate;

    float spawnRateTimer = 0;

    void Update()
    {
        spawnRate = PlayerPrefs.GetFloat("EnemySpawnTime");

        spawnRateTimer += Time.deltaTime;
        if (spawnRateTimer > spawnRate)
            Spawn();
    }

    void Spawn()
    {
        spawnRateTimer = 0;
        int randomEnemy = Random.Range(0, enemyPrefabs.Length);
        int randomSpawnPoints = Random.Range(0, spawnPoints.Length);

        Instantiate(enemyPrefabs[randomEnemy], spawnPoints[randomSpawnPoints].position, transform.rotation);
    }
}
