using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 20f;

    private PlayerMovment _player;
    private Rigidbody2D bulletRigidbody;

    private float xAxisSpeed;
    
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<PlayerMovment>();
        xAxisSpeed = _player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        bulletRigidbody.velocity = new Vector2(xAxisSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
