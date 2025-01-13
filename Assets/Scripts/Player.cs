using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour, Idamageable
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

    // function for the main scythe attack. starts the attack animation and enables the attack hitbox
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

    //disables the attack hitbox after a small amount of time and resets the animation trigger for the attack
    IEnumerator AttackCD()
    {
        yield return new WaitForSeconds(0.2f);
        WeaponHitbox.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.6f);
        Weapon.GetComponent<Animator>().ResetTrigger("attack");
        attacking = false;
    }

    //function for the player taking damage also makes an event so that the healthbar knows when the player takes damage
    public void TakeDamage(float amount, string element)
    {
        health -= amount;
        OnPlayerDamaged?.Invoke();
        if (health <= 0)
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
