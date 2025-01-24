using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public static event Action PlayerHPReset;
    public static event Action GameReset;
    Player player;
    Inventory inventory;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        inventory = FindObjectOfType<Inventory>();
    }
    public void ResetGame()
    {
        GameReset?.Invoke();
        player.gameObject.transform.position = Vector3.zero;
        player.gameObject.GetComponent<Movement>().enabled = true;
        player.health = player.maxHealth;
        int activeWeapon = (int)inventory.activeWeapon;
        activeWeapon = 0;
        inventory.activeWeapon = activeWeapon + 1;
        inventory.Weapons[activeWeapon].SetActive(true);
        inventory.bombs = 0;
        inventory.coins = 0;

        PlayerHPReset?.Invoke();
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
