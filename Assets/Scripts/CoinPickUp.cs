using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : PickUp, IPickUpAble
{
    public override void PickUpAction(Collider2D col)
    {
        col.GetComponent<Inventory>().coins += 1;
        base.PickUpAction(col);
    }
}
