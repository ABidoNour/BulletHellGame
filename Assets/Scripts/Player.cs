using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] private float playerSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float maxHealth;
    [SerializeField] private HealthBar healthbar;
    private float health;
    private float xSpeed;
    private float ySpeed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        health = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        xSpeed = Input.GetAxisRaw("Horizontal") * playerSpeed;
        ySpeed = Input.GetAxisRaw("Vertical") * playerSpeed;
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xSpeed, ySpeed);
        Debug.Log(health);
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        healthbar.setHealth(health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}