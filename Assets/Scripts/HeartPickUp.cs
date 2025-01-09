using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUp : PickUp
{
    public override void PickUpAction(Collider2D col)
    {
        if (col.GetComponent<Player>().health != col.GetComponent<Player>().maxHealth)
        {
            col.GetComponent<Player>().health += 1;
            base.PickUpAction(col);
        }
    }
}
