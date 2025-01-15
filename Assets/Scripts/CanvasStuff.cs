using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasStuff : MonoBehaviour
{
    public TextMeshProUGUI BombCount;

    private Inventory playerInv;

    private void Awake()
    {
        playerInv = FindObjectOfType<Inventory>();
    }
    private void Update()
    {
        BombCount.text = playerInv.bombs.ToString() + "x";
    }
}
