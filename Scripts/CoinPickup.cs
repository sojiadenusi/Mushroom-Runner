using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickUp;
    [SerializeField] int coinValue = 100;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession>().AddToScore(coinValue);
        AudioSource.PlayClipAtPoint(coinPickUp, Camera.main.transform.position);
        Destroy(gameObject);
        
    }

}
