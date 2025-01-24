using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
    }
    void Update()
    {
        if (!player.GetComponent<Player>().grabbed)
        {
            if (player.transform.position.y > transform.position.y + 5.5f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
            }
            if (player.transform.position.y < transform.position.y - 5.5f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
            }
            if (player.transform.position.x > transform.position.x + 9.5f)
            {
                transform.position = new Vector3(transform.position.x + 18, transform.position.y, transform.position.z);
            }
            if (player.transform.position.x < transform.position.x - 9.5f)
            {
                transform.position = new Vector3(transform.position.x - 18, transform.position.y, transform.position.z);
            }
        }
    }
}
