using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : WeaponScript
{
    public BoxCollider2D hitBox;
    public override void DoAttack(Collider2D col)
    {
        base.DoAttack(col);
        GetComponent<Animator>().SetTrigger("attack");
    }

    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.8f);
        GetComponent<Animator>().ResetTrigger("attack");
    }
}
