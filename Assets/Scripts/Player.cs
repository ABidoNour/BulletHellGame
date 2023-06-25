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
    private float xSpeed;
    private float ySpeed;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
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
        transform.position += new Vector3(xSpeed, ySpeed, 0);
    }
}