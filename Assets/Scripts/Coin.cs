using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float minMagnetDistance = 3;
    [SerializeField] private float maxMagnetDistance = 7;
    [SerializeField] private float coinMagnetisimSpeed = 6;
    private Vector2 _direction;
    private int _value;
    private bool _attractedToPlayer = false;
    public Rigidbody2D rb;


    private void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.Instance.transform.position);
        if (distance < minMagnetDistance) _attractedToPlayer = true;
        if (distance > maxMagnetDistance) _attractedToPlayer = false;
        
        if (_attractedToPlayer)
        {
            _direction = (Player.Instance.transform.position - transform.position).normalized;
            _direction *= coinMagnetisimSpeed;
        }
        else
        {
            _direction = new Vector2(0, 0);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = _direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _value = Random.Range(1, 3);

        if (other.CompareTag("Player"))
        {
            CoinManager.Instance.GainMoney(_value);
            Destroy(gameObject);
        }
    }
}