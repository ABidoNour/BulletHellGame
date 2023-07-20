using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float damageDealt;
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

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health > 0) return;
        Destroy(gameObject);
        EnemyManager.DecreaseNumEnemies();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        var player = other.GetComponent<Player>();
        player.takeDamage(damageDealt);
    }
}