using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private const float CooldownTimeSecs = .5f;
    private Vector2 _direction;
    public Rigidbody2D rb;

    private void Update()
    {
        _direction = (Player.Instance.transform.position - transform.position).normalized;
        _direction *= speed;
    }

    private void FixedUpdate()
    {
        rb.velocity = _direction;
    }

    public void TakeDamage(float damageTake)
    {
        health -= damageTake;
        if (health > 0) return;
        Destroy(gameObject);
        EnemyManager.DecreaseNumEnemies();
    }


    private readonly Func<bool> _canAttack = Timer.Start(CooldownTimeSecs);
    private bool CanAttack => _canAttack();

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player") || !CanAttack) return;

        var player = other.GetComponent<Player>();
        player.takeDamage(damage);
    }
}