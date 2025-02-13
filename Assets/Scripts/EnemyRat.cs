using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRat : Enemy
{
    public override void Update()
    {
        base.Update();
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
        if (player.transform.position.x > transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public override void TakeDamage(float amount, string element, string weapon)
    {
        base.TakeDamage(amount, element, weapon);
        if (weapon == "Melee" && Random.Range(0, 10) == 1)
        {
            FindObjectOfType<Player>().TakeDamage(1, null, null);
        }
    }
}
