using Unity.Mathematics;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }
    public int numCoins;
    [SerializeField] private GameObject coin;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnCoins(Vector3 position)
    {
        Instantiate(coin, position, quaternion.identity, transform);
    }

    public void GainMoney(int value)
    {
        numCoins += value;
    }
}