using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    public static event Action OnPlayerDamaged;

    [SerializeField] private Sprite[] deathSprites;

    public GameObject Weapon;
    public GameObject WeaponHitbox;
    private bool attacking;
    public float health = 6;
    public float maxHealth = 6;
    public int bombs;
    public int money;



    private void Update()
    {
        if(health > maxHealth) health = maxHealth;
    }
    public void MainAttack(CallbackContext _context)
    {
        if (_context.performed && !attacking)
        {
            Weapon.GetComponent<Animator>().SetTrigger("attack");
            WeaponHitbox.GetComponent<BoxCollider2D>().enabled = true;
            Weapon.GetComponent<WeaponScript>().DoAttack(WeaponHitbox.GetComponent<BoxCollider2D>());
            attacking = true;
            StartCoroutine(AttackCD());
        }
    }
    IEnumerator AttackCD()
    {
        yield return new WaitForSeconds(0.2f);
        WeaponHitbox.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.6f);
        Weapon.GetComponent<Animator>().ResetTrigger("attack");
        attacking = false;
    }
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        OnPlayerDamaged?.Invoke();

        
        if(health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        gameObject.GetComponent<Movement>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = deathSprites[UnityEngine.Random.Range(0, deathSprites.Length)];
    }
}
