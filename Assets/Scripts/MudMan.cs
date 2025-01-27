using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class MudMan : Enemy
{
    public GameObject mudBall;
    [SerializeField] private GameObject mudOrigin;
    [SerializeField] private bool nearPlayer;
    public float bulletSpeed;
    public float shootspeed;
    public float range;
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
        if(Vector2.Distance(transform.position, player.transform.position) < range && !nearPlayer)
        {
            StartCoroutine(BulletCD());
            nearPlayer = true;
        }
        else if(Vector2.Distance(transform.position, player.transform.position) > range && nearPlayer)
        {
            StopAllCoroutines();
            nearPlayer = false;
        }
    }


    IEnumerator BulletCD()
    {
        yield return new WaitForSeconds(shootspeed);
        GameObject mud = Instantiate(mudBall, mudOrigin.transform.position, mudOrigin.transform.rotation);
        mud.GetComponent<Rigidbody2D>().AddForce(mudOrigin.transform.right * bulletSpeed, ForceMode2D.Impulse);
        StartCoroutine(BulletCD());
    }
}
