using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public static event Action OnPlayerDamaged;

    [SerializeField] private Sprite[] deathSprites;
    
    public float health = 6;
    public float maxHealth = 6;

    

    
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        OnPlayerDamaged?.Invoke();

        
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.GetComponent<Movement>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = deathSprites[UnityEngine.Random.Range(0, deathSprites.Length)];
    }
}
