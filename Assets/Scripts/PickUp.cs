using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public static event Action OnPickUp;
    private GameManager gameManager;
    private Inventory inventory;
    public int price;

    public void Start()
    {
        inventory = FindObjectOfType<Inventory>();
       gameManager = FindObjectOfType<GameManager>();
       gameManager.activePickUps.Add(gameObject);
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        PickUpAction(collision);
    }

    public virtual void PickUpAction(Collider2D col)
    {
        if (inventory.coins >= price)
        {
            inventory.coins -= price;
            OnPickUp?.Invoke();
            gameManager.activePickUps.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
