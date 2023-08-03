using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] private float playerSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float maxHealth;
    [SerializeField] private HealthBar healthbar;
    private int amountOfMoney;
    private float health;
    private float xSpeed;
    private float ySpeed;
    public Rigidbody2D rb;

    private void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        health = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }
    
    void Update()
    {
        if (Time.timeScale == 0f) return;
        xSpeed = Input.GetAxisRaw("Horizontal");
        ySpeed = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xSpeed, ySpeed).normalized * playerSpeed;
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