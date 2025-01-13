using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour, IPickUpAble
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PickUpAction(other);
    }
    public void PickUpAction(Collider2D col)
    {
        col.GetComponent<Player>().money += 1;
        Destroy(gameObject);
    }
}
