using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour, IDamageable
{
    public static event Action OnPlayerDamaged;

    [SerializeField] private Sprite[] deathSprites;

    private Inventory inventory;
    public GameObject Bowomb;
    public GameObject gameOverScreen;
    public bool attacking;
    public bool grabbed;
    public float health = 6;
    public float maxHealth = 6;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }


    private void Update()
    {
        if(health > maxHealth) health = maxHealth;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        if(health <= 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    // function for the main scythe attack. starts the attack animation and enables the attack hitbox
    public void MainAttack(CallbackContext _context)
    {
        if (_context.performed && !attacking && health > 0)
        {
            switch (inventory.activeWeapon)
            {
                case 1:
                    inventory.Weapons[0].GetComponent<Scythe>().DoAttack(inventory.Weapons[0].GetComponent<Scythe>().hitBox);
                    StartCoroutine(AttackCD(0.8f));
                    StartCoroutine(inventory.Weapons[0].GetComponent<Scythe>().Cooldown());
                    attacking = true;
                    break;
                case 2:
                    inventory.Weapons[1].GetComponent<Bow>().Shoot();
                    StartCoroutine(AttackCD(0.4f));
                    attacking = true;
                    break;
                case 3:
                    inventory.Weapons[2].GetComponent<Animator>().SetTrigger("attack");
                    StartCoroutine(AttackCD(0.3f));
                    StartCoroutine(inventory.Weapons[2].GetComponent<Knife>().Stabs());
                    attacking= true;
                    break;
            }
        }
    }

    public void DropBomb(CallbackContext _context)
    {
        if (_context.performed && inventory.bombs > 0)
        {
            Instantiate(Bowomb, transform.position, Quaternion.identity);
            inventory.bombs--;
        }
    }

    //disables the attack hitbox after a small amount of time and resets the animation trigger for the attack
    IEnumerator AttackCD(float time)
    {
        yield return new WaitForSeconds(time);
        attacking = false;
    }

    //function for the player taking damage also makes an event so that the healthbar knows when the player takes damage
    public void TakeDamage(float amount, string element, string weapon)
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
        GetComponent<Inventory>().enabled = false;
        gameOverScreen.SetActive(true);
    }
}
