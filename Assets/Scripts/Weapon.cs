using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private int baseDamage;
    [SerializeField] private float critRate;
    [SerializeField] private float critDMG;
    public string element;
    public string weapon;
    [SerializeField] private GameObject critSpark;

    //attack function checks which hitboxes it's damage hitbox hit and then calculates damage for each of them separately
    public virtual void DoAttack(Collider2D col)
    {
        LayerMask mask = LayerMask.GetMask("Player", "Weapon", "PickUp", "Arrow", "Water", "Default");
        Collider2D[] cols = Physics2D.OverlapBoxAll(col.bounds.center, col.bounds.extents, 0, ~mask);
        foreach(Collider2D c in cols)
        {
            float damage = (baseDamage * Random.Range(0.85f, 1.1f));
            
            if (Random.Range(1, 100) <= critRate && c.gameObject.CompareTag("Enemy"))
            {
                damage = Mathf.Round(damage * (1 + (critDMG / 100)));
                GameObject particle = Instantiate(critSpark, c.transform);
                Destroy(particle, 0.2f);
            }

            if (c.gameObject.CompareTag("Enemy"))
            {
                c.gameObject.GetComponent<Enemy>().TakeDamage(damage, element, weapon);
            }
            if (c.gameObject.CompareTag("Rock"))
            {
                c.gameObject.GetComponent<Rock>().TakeDamage(damage, element, weapon);
            }
        }
    }
}
