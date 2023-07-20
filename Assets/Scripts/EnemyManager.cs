using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float circleRadius = 24f;
    [SerializeField] private float enemySpawnTime = 1f;
    private static int _numEnemies;
    public int maxEnemies = 3;
    
    private Random _rand = new Unity.Mathematics.Random(5);

    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        print("Started");
        while (true)
        {
            if (_numEnemies < maxEnemies)
            {
                Vector3 pointOfSpawn = getRandomPointOnCircle();
                Instantiate(enemyPrefab, pointOfSpawn, Quaternion.identity, transform);
                _numEnemies++;
            }

            yield return new WaitForSeconds(enemySpawnTime);
        }
    }

    private Vector2 getRandomPointOnCircle()
    {
        var angleInRadians = _rand.NextFloat(0, 2 * Mathf.PI);
        return new Vector2(circleRadius * Mathf.Cos(angleInRadians), circleRadius * Mathf.Sin(angleInRadians));
    }

    public static void DecreaseNumEnemies()
    {
        _numEnemies--;
    }
}