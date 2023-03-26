using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float enemiesToSpawn = 5; //πόσους θελουμε να γεννησουμε
    public float activeEnemies = 0; //πόσοι είναι ζωντανοί τωρα
    public float totalEnemiesSpawned; //ποσοι γεννηθηκαν συνολικά μεχρι στιγμής
    public float enemiesAtOnce = 2;
    public float originRandomOffset = 2;
    public UnityEvent onSpawnerEnd;

    // Start is called before the first frame update
    void Start()
    {
        activeEnemies = 0;
        totalEnemiesSpawned = 0;

        if (enemiesToSpawn > 0) SpawnEnemy();
    }

    void SpawnEnemy()
    {
        activeEnemies++;
        totalEnemiesSpawned++;
        //activeEnemies = activeEnemies + 2;
        //totalEnemiesSpawned = totalEnemiesSpawned + 2;

        GameObject clone = GameObject.Instantiate(enemyPrefab, transform.position + RandomSpawnLocalPosition(), transform.rotation);

        EnemyHealth enemyHealth = clone.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.RegisterSpawner(this);
        }

        if (activeEnemies < enemiesAtOnce)
        {
            SpawnEnemy();
        }
    }

    public void NotifyDeath(EnemyHealth enemyHealth)
    {
        activeEnemies--;

        if (totalEnemiesSpawned < enemiesToSpawn)
        {
            SpawnEnemy();
        }
        else if (activeEnemies <= 0)
        {
            onSpawnerEnd.Invoke();
        }
    }

    Vector3 RandomSpawnLocalPosition()
    {
        float x = Random.Range(-originRandomOffset, originRandomOffset);
        float z = Random.Range(-originRandomOffset, originRandomOffset);

        return new Vector3(x, 0, z);
    }
}
