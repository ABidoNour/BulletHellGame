using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private const float CooldownTimeSecs = .5f;
    private Vector2 direction;
    public Rigidbody2D rb;

    private void Update()
    {
        direction = (Player.Instance.transform.position - transform.position).normalized;
        direction *= speed;
    }

    private void FixedUpdate()
    {
        float minDistanceFromPlayer = .5f;
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) > minDistanceFromPlayer)
        {
            rb.velocity = direction;
        }
        //TODO
        // else
        // {
        //     rb.velocity = -rb.velocity * 10;
        // }
        
    }

    public void TakeDamage(float damageTake)
    {
        health -= damageTake;
        if (health > 0) return;
        
        var positionOfDeath = transform.position;
        Destroy(gameObject);
        EnemyManager.DecreaseNumEnemies();
        CoinManager.Instance.SpawnCoins(positionOfDeath);
    }


    private readonly Func<bool> canAttack = Timer.Start(CooldownTimeSecs);
    private bool CanAttack => canAttack();

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player") || !CanAttack) return;

        var player = other.GetComponent<Player>();
        player.takeDamage(damage);
    }
}