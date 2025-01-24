using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudBall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(1, null, null);
        }
        Destroy(gameObject);
    }
}
