using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyToSpawn;
    public int spawnTime = 100;
    public int maxSpawnTime = 100;
    private int origMaxTime;

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
            spawnTime -= 1;
        }
        else{
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        maxSpawnTime = (int) Mathf.Round(maxSpawnTime * 0.95f);
        if (maxSpawnTime < (int) Mathf.Round(maxSpawnTime * 0.5f)){
            maxSpawnTime = (int) Mathf.Round(maxSpawnTime * 0.5f);
        }
        GameObject enemyInst = Instantiate(enemyToSpawn, this.transform.position, Quaternion.identity);
        spawnTime = maxSpawnTime;
    }
}
