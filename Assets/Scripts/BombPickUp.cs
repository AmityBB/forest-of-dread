using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPickUp : PickUp, IPickUpAble
{
    public override void PickUpAction(Collider2D col)
    {
        col.GetComponent<Inventory>().bombs += 1;
        base.PickUpAction(col);
    }
}
