using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    [SerializeField] private int value;
    private void OnTriggerEnter2D(Collider2D other)
    {
        value = UnityEngine.Random.Range(1, 3);
        
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            player.gainMoney(value);
            Destroy(gameObject);
        }
    }
}
