using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if(health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //change sprite to dead sprite, disable hitbox lower enemies left int in gamemanager and turn off script
    }
}
