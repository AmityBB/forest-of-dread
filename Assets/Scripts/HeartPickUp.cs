using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUp : MonoBehaviour, IPickUpAble
{
    public static event Action OnPickUp;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PickUpAction(other);
        OnPickUp?.Invoke();
    }
    public void PickUpAction(Collider2D col)
    {
        if (col.GetComponent<Player>().health != col.GetComponent<Player>().maxHealth)
        {
            col.GetComponent<Player>().health += 2;
            Destroy(gameObject);
        }
    }
}
