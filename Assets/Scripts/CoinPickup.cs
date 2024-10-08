using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private AudioClip coinPickSFX;
    [SerializeField] private int pointsForCoinPickup = 100;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            AudioSource.PlayClipAtPoint(coinPickSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
