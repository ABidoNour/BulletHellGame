using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    // public static EnemyManager Instance { get; private set; }
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float circleRadius = 27f;
    [SerializeField] private float enemySpawnTime = 1f;
    [SerializeField] private float enemyWaveIncrementSeconds = 60f;
    [SerializeField] private int enemyNumIncrements = 4;
    private static int _numEnemies;
    public int currMaxEnemies = 3;
    private const int MostPossibleEnemies = 25;

    private void Awake()
    {

    }

    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(IncrementEnemyWaves());
    }

    private IEnumerator IncrementEnemyWaves()
    {
        while (currMaxEnemies < MostPossibleEnemies)
        {
            yield return new WaitForSeconds(enemyWaveIncrementSeconds);
            currMaxEnemies += enemyNumIncrements;
            for (int i = 0; i < enemyNumIncrements; i++) SpawnEnemy();
        }
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(enemySpawnTime);
        }
    }

    private void SpawnEnemy()
    {
        if (_numEnemies >= currMaxEnemies) return;
        Vector3 pointOfSpawn = getRandomPointOnCircle(Player.Instance.transform.position);
        Instantiate(enemyPrefab, pointOfSpawn, Quaternion.identity, transform);
        _numEnemies++;
    }

    private Vector2 getRandomPointOnCircle(Vector2 center)
    {
        var angleInRadians = Random.Range(0, 2 * Mathf.PI);
        return new Vector2(circleRadius * Mathf.Cos(angleInRadians), circleRadius * Mathf.Sin(angleInRadians)) + center;
    }

    public static void DecreaseNumEnemies()
    {
        _numEnemies--;
    }
}