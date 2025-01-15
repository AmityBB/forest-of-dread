using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Bow bow;
    private void Awake()
    {
        bow = FindObjectOfType<Bow>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bow.DoAttack(GetComponent<BoxCollider2D>());
        Destroy(gameObject);
    }
}
