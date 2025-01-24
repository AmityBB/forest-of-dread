using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public static event Action OnPickUp;
    private GameManager gameManager;

    public void Start()
    {
       gameManager = FindObjectOfType<GameManager>();
       gameManager.activePickUps.Add(gameObject);
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        PickUpAction(collision);
    }

    public virtual void PickUpAction(Collider2D col)
    {
        OnPickUp?.Invoke();
        gameManager.activePickUps.Remove(gameObject);
        Destroy(gameObject);
    }
}
