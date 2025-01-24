using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasStuff : MonoBehaviour
{
    public TextMeshProUGUI BombCount;
    public TextMeshProUGUI CoinCount;

    private Inventory playerInv;

    private void Awake()
    {
        playerInv = FindObjectOfType<Inventory>();
    }
    private void Update()
    {
        BombCount.text = playerInv.bombs.ToString() + "x";
        CoinCount.text = playerInv.coins.ToString() + "x";
    }
}
