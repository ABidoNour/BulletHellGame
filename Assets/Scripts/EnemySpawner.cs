using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float circleRadius = 24f;
    [SerializeField] private float enemySpawnTime = 1f;
    public int maxEnemies = 3;
    public int numEnemies;
    private Random _rand = new Unity.Mathematics.Random(5);

    // Start is called before the first frame update
    void Start()
    {
        numEnemies = 0;
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
        print("Started");
        while (true)
        {
            if (numEnemies < maxEnemies)
            {
                Vector3 pointOfSpawn = getRandomPointOnCircle();
                Instantiate(enemyPrefab, pointOfSpawn, Quaternion.identity);
                numEnemies++;
            }

            yield return new WaitForSeconds(enemySpawnTime);
        }
    }

    Vector2 getRandomPointOnCircle()
    {
        float angleInRadians = _rand.NextFloat(0, 2 * Mathf.PI);
        return new Vector2(circleRadius * Mathf.Cos(angleInRadians), circleRadius * Mathf.Sin(angleInRadians));
    }

    public void decreaseNumEnemies()
    {
        numEnemies--;
    }
}