using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        winScreen.SetActive(true);
        collision.gameObject.SetActive(false);
    }
}
