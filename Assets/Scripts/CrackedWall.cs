using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrackedWall : MonoBehaviour
{
    private GameManager gameManager;
    public Sprite brokenSprite;
    public Sprite fullWall;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.explodeWalls.Add(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Explosion"))
        {
            GetComponent<SpriteRenderer>().sprite = brokenSprite;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
