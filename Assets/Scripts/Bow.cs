using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : WeaponScript
{
    public GameObject arrow;
    public void Shoot()
    {
        GameObject clone = Instantiate(arrow, transform.position, transform.rotation);
        clone.GetComponent<Rigidbody2D>().AddForce(transform.up * 10, ForceMode2D.Impulse);
        Destroy(clone, 4f);
    }

    public override void DoAttack(Collider2D col)
    {
        base.DoAttack(col);
    }
    private void Update()
    {
        // convert mouse position into world coordinates
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // get direction you want to point at
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;

        // set vector of transform directly
        transform.up = direction;
    }
}
