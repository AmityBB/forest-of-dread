using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour, IDamageable
{
    public Sprite fullRock;
    public int hitPoints = 3;
    [SerializeField] GameObject m_PickUp;
    [SerializeField] List<GameObject> m_PickUps = new();

    private void Start()
    {
        m_PickUp = m_PickUps[Random.Range(0, m_PickUps.Count)];
    }

    public void TakeDamage(float amount, string element, string weapon)
    {
        hitPoints--;
        if (hitPoints == 0)
        {
            if (m_PickUp != null)
            {
                Instantiate(m_PickUp, transform.position, Quaternion.identity);
            }
            GetComponent<SpriteRenderer>().sprite = null;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void GetHit(int amount)
    {
        hitPoints -= amount;
        if (hitPoints == 0)
        {
            if (m_PickUp != null)
            {
                Instantiate(m_PickUp, transform.position, Quaternion.identity);
            }
            GetComponent<SpriteRenderer>().sprite = null;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerAttack"))
        {
            GetHit(1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Explosion"))
        {
            GetHit(3);
        }
    }
}
