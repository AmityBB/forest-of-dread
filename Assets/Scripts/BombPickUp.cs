using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPickUp : PickUp
{
    public override void PickUpAction(Collider2D col)
    {
        col.GetComponent<Player>().bombs += 1;
        base.PickUpAction(col);
    }
}
