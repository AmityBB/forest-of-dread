using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public int baseDamage;
    public float critRate;
    public int critDMG;
    public string element;
    public GameObject critSpark;

    //attack function checks which hitboxes it's damage hitbox hit and then calculates damage for each of them separately
    public void DoAttack(Collider2D col)
    {
        LayerMask mask = LayerMask.GetMask("Player", "Weapon");
        Collider2D[] cols = Physics2D.OverlapBoxAll(col.bounds.center, col.bounds.extents, 0, ~mask);
        foreach(Collider2D c in cols)
        {
            float damage = (baseDamage * Random.Range(0.85f, 1.1f));
            
            if (Random.Range(1, 100) <= critRate)
            {
                damage = Mathf.Round(damage * (1 + (critDMG / 100)));
                GameObject particle =Instantiate(critSpark, transform.parent);
                particle.transform.SetParent(transform.parent);
                particle.transform.localPosition = new Vector2(1.1f, 0.8f);
                Destroy(particle, 0.2f);
            }

            if (c.gameObject.CompareTag("Enemy"))
            {
                c.gameObject.GetComponent<Enemy>().TakeDamage(damage, element);
            }
        }
    }
}
