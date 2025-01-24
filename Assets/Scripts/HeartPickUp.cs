using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUp : PickUp, IPickUpAble
{ 
    public override void PickUpAction(Collider2D col)
    {
        if (col.GetComponent<Player>().health != col.GetComponent<Player>().maxHealth)
        {
            col.GetComponent<Player>().health += 2;
            Destroy(gameObject);
            base.PickUpAction(col);
        }
    }
}
