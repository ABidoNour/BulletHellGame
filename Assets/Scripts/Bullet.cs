using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeSpan;
    [SerializeField] private float bulletSpeed;
    private Vector3 bulletPath;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
        transform.position = Player.Instance.transform.position;
        bulletPath = (mousePos - transform.position).normalized;
        bulletPath *= bulletSpeed;

        StartCoroutine(DestroySelf());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifeSpan);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.position += bulletPath;
    }
}