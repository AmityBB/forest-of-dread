using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : WeaponScript
{
    public BoxCollider2D hitBox;
    public override void DoAttack(Collider2D col)
    {
        base.DoAttack(col);
    }

    public IEnumerator Stabs()
    {
        DoAttack(hitBox);
        yield return new WaitForSeconds(0.15f);
        DoAttack(hitBox);
        GetComponent<Animator>().ResetTrigger("attack");
    }
}
