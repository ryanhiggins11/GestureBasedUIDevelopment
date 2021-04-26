using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Ryan Higgins
 * G00337350
 * Final Year Gesture Based UI Development Project
 * Deals with spawning the enemy
 */
public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyGo;
    float maxSpawnRateInSeconds = 3f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject anEnemy = (GameObject)Instantiate(EnemyGo);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        SchedueleNextEnemySpawn();
    }

    private void SchedueleNextEnemySpawn()
    {
        maxSpawnRateInSeconds = 3f;
        float spawnInSeconds;
        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInSeconds = Random.Range(3f, maxSpawnRateInSeconds);
        }
        else
            spawnInSeconds = 1f;

        Invoke("SpawnEnemy", spawnInSeconds);
    }
    void increaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
        {
            maxSpawnRateInSeconds--;
        }
        if (maxSpawnRateInSeconds == 1f)
        {
            CancelInvoke("increaseSpawnRate");
        }
    }

    public void SchedueleEnemySpawner()
    {
        Invoke("SpawnEnemy", 2f);
        InvokeRepeating("increaseSpawnRate", 0f, 30f);
    }

    public void UnschedueleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("increaseSpawnRate");
    }
}
