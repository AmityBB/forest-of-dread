using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LookAtScript : MonoBehaviour
{
    public GameObject target;

    private void Start()
    {
        target = FindObjectOfType<Player>().gameObject;
    }
    void Update()
    {
        Vector2 direction = target.transform.position - transform.position;
        transform.right = direction;
    }
}
