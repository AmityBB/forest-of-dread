using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : PickUp
{
    public override void PickUpAction(Collider2D col)
    {
        col.GetComponent<Player>().money += 1;
        base.PickUpAction(col);
    }
}
