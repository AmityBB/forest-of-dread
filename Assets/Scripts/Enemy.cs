using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;
    public float baseHealth;
    public float health;
    public float baseDefence;
    public float defence;
    public string weakness;

    private void Start()
    {
        defence = baseDefence;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
    }

    
    public void TakeDamage(float dmg, string element)
    {
        switch (element)
        {
            case null: defence = baseDefence * 0.9f;
                break;
            case "Fire": 
                StartCoroutine(BurnDoT());
                break;
        }
        dmg = dmg * 1 - (defence / 100);
        if(element == weakness)
        {
            dmg *= 1.4f;
        }
        health -= dmg;
        if (health < 0)
        {
            Die();
        }
    }

    private IEnumerator BurnDoT()
    {
        int secondsLeft = 5;
        yield return new WaitForSeconds(1);
        if (weakness == "Fire")
        {
            health = health - (baseHealth * 0.05f);
        }
        else
        {
            health = health - (baseHealth * 0.025f);
        }
        secondsLeft--;
        if(secondsLeft > 0)
        {
            StartCoroutine(BurnDoT());
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        //change sprite to dead sprite, disable hitbox lower enemies left int in gamemanager and turn off script
    }
}
