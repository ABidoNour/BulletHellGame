using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // if (gameObject.GetComponent<Collider2D>().IsTouchingLayers(6))
        // {
        //     Destroy(gameObject);
        //     Debug.Log("Reached");
        // }
    }

    private void FixedUpdate()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("WORRK");
    }
}