using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedWall : MonoBehaviour
{
    public Sprite brokenSprite;
    public Sprite fullWall;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Explosion"))
        {
            GetComponent<SpriteRenderer>().sprite = brokenSprite;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
