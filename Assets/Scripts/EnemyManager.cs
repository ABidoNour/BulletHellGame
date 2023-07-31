using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float circleRadius = 24f;
    [SerializeField] private float enemySpawnTime = 1f;
    private static int _numEnemies;
    public int maxEnemies = 3;
    
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (_numEnemies < maxEnemies)
            {
                Vector3 pointOfSpawn = getRandomPointOnCircle(Player.Instance.transform.position);
                Instantiate(enemyPrefab, pointOfSpawn, Quaternion.identity, transform);
                _numEnemies++;
            }

            yield return new WaitForSeconds(enemySpawnTime);
        }
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