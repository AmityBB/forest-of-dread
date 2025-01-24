using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoth : Enemy
{
    [SerializeField] private bool attacking;
    [SerializeField] private bool dashing;

    public override void Update()
    {
        base.Update();
        if (health < baseHealth / 2)
        {
            speed = baseSpeed * 2;
        }
        float step = speed * Time.deltaTime;
        if (!attacking)
        {
            dashing = false;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
            if (Vector3.Distance(transform.position, player.transform.position) < 5 && health > baseHealth/2)
            {
                if (!dashing)
                {
                    StartCoroutine(Dash());
                    dashing = true;
                }
                attacking = true;
            }
        }
        else if(Vector3.Distance(transform.position, player.transform.position) > 5 && GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            StopAllCoroutines();
            attacking = false; 
        }
        if (player.transform.position.x > transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    IEnumerator Dash()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody2D>().AddForce((player.transform.position - transform.position) * 40, ForceMode2D.Impulse);
        yield return new WaitForSeconds(2);
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        if (attacking)
        {
            StartCoroutine(Dash());
        }      
    }
}
