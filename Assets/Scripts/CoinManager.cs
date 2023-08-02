using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    private int _numCoins;

    private int NumCoins
    {
        get => _numCoins;
        set
        {
            _numCoins = value;
            coinText.text = NumCoins.ToString();
        }
    }

    [SerializeField] private GameObject coin;
    [SerializeField] private Text coinText;

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
        NumCoins += value;
    }
}