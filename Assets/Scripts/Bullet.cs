using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeSpan;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int damage;
    private Vector3 bulletPath;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
        transform.position = Player.Instance.transform.position;
        bulletPath = (mousePos - transform.position).normalized;
        bulletPath *= bulletSpeed;
        rb.velocity = (Vector2)bulletPath;


        StartCoroutine(DestroySelf());
    }

    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifeSpan);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.takeDamage(damage);
            Destroy(gameObject);
        }
    }
}