using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyToSpawn;
    public float spawnTime = 100;
    public float maxSpawnTime = 100;
    private float origMaxTime;

    // Start is called before the first frame update
    void Start()
    {
        origMaxTime = maxSpawnTime;
        spawnTime = maxSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime > 0){
            spawnTime -= Time.deltaTime;
        }
        else{
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        maxSpawnTime = maxSpawnTime * 0.90f;
        if (maxSpawnTime < maxSpawnTime * 0.25f){
            maxSpawnTime = maxSpawnTime * 0.25f;
        }
        GameObject enemyInst = Instantiate(enemyToSpawn, this.transform.position, Quaternion.identity);
        spawnTime = maxSpawnTime;
    }
}
