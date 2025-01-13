using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Idamageable
{
    public static event Action PlayerInteract;
    public GameObject player;

    public int damage;
    public float baseHealth;
    public float health;
    public float baseDefence;
    public float defence;
    public float speed;
    public float baseSpeed;
    public string weakness;
    private bool isSlowed;
    private bool rooted;

    public virtual void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        defence = baseDefence;
    }

    //if the enemy collides with the player the player takes damage equal to the enemy's damage stat
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage, null);
        }
    }

    //if the enemy gets hit by any source of damage it checks how much base damage it should take and of which element that attack is, then calculate the full damage it takes and activates the effects of specific elements
    public void TakeDamage(float amount, string element)
    {
        switch (element)
        {
            case null: defence = baseDefence * 0.9f;
                break;
            case "Fire": 
                StartCoroutine(BurnDoT(5));
                break;
            case "Ice":
                if (!isSlowed)
                StartCoroutine(SlowTimer(2));
                break;
            case "Plant":
                rooted = true;
                break;
        }
        amount = amount * (1 - (defence / 100));
        if(element == weakness)
        {
            amount *= 1.4f;
        }
        health -= amount;
        if (health < 0)
        {
            Die();
        }
    }


    //fire damage over time activates when enemy is hit with a fire element attack. 
    private IEnumerator BurnDoT(int time)
    {
        yield return new WaitForSeconds(1);
        if (weakness == "Fire")
        {
            health = health - ((baseHealth * 0.005f)* UnityEngine.Random.Range(0.85f, 1.1f));
        }
        else
        {
            health = health - ((baseHealth * 0.0025f)* UnityEngine.Random.Range(0.85f, 1.1f));
        }
        time--;
        if(time > 0)
        {
            StartCoroutine(BurnDoT(time));
        }
    }

    private IEnumerator SlowTimer(int time)
    {
        isSlowed = true;
        if(weakness == "Ice")
        {
            speed = speed / 2;
        }
        else
        {
            speed = speed / 1.5f;
        }
        yield return new WaitForSeconds(time);
        speed = baseSpeed;
        isSlowed = false;
    }

    private void Die()
    {
        if (rooted)
        {
            if (weakness == "Plant")
            {
                player.GetComponent<Player>().health += 2;
            }
            else
            {
                player.GetComponent<Player>().health += 1;
            }
                PlayerInteract?.Invoke();
        }
        Destroy(gameObject);
        //change sprite to dead sprite, disable hitbox lower enemies left int in gamemanager and turn off script
    }
}
