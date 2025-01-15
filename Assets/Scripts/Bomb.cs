using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public static event Action PlayerInteract;
    public BoxCollider2D explosion;
    [SerializeField] private GameObject particle;
    private void Start()
    {
        StartCoroutine(ExplodeTimer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().health -= 1;
            PlayerInteract.Invoke();
        }
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(200, "Explosion");
        }
    }

    private IEnumerator ExplodeTimer()
    {
        yield return new WaitForSeconds(1.5f);
        explosion.enabled = true;
        GameObject boom = Instantiate(particle, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.6f);
        Destroy(boom);
        explosion.enabled = false;
        Destroy(gameObject);
    }
}
