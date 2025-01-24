using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Inventory : MonoBehaviour
{
    public List<GameObject> Slots = new List<GameObject>();
    public List<GameObject> Weapons = new List<GameObject>();

    public int bombs;
    public int coins;
    public float activeWeapon = 1;

    public void SwitchWeapon(CallbackContext _context)
    {
        if (_context.performed && !GetComponent<Player>().attacking) 
        {
           activeWeapon = _context.ReadValue<float>();
           for (int i = 1; i <= Weapons.Count; i++)
            {
                if (i == activeWeapon)
                {
                    Weapons[i-1].SetActive(true);
                }
                else
                {
                    Weapons[i-1].SetActive(false);
                }
            }
        }
    }
}
