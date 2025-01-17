using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WillOWisp : MonoBehaviour
{
    private bool caught;
    private GameObject player;
    [SerializeField] private List<float> distances;
    private Vector3 targetPos;

    private void Start()
    {
        distances[0] = Vector3.Distance(transform.position, new Vector3(9, transform.position.y, 0));
        distances[1] = Vector3.Distance(transform.position, new Vector3(-9, transform.position.y, 0));
        distances[2] = Vector3.Distance(transform.position, new Vector3(transform.position.x, 5, 0));
        distances[3] = Vector3.Distance(transform.position, new Vector3(transform.position.x, -5, 0));
        switch (GetLowest(distances))
        {
            case 0: 
                targetPos = new Vector3(20, transform.position.y, 0);
                break;
            case 1:
                targetPos = new Vector3(-20, transform.position.y, 0);
                break;
            case 2:
                targetPos = new Vector3(transform.position.x, 10, 0);
                break;
            case 3:
                targetPos = new Vector3(transform.position.x, -10, 0);
                break;
        }
    }

    private int GetLowest(List<float> distances)
    {
        float value = float.PositiveInfinity;
        int index = -1;
        for (int i = 0; i < distances.Count; i++)
        {
            if (distances[i] < value)
            {
                index = i;
                value = distances[i];
            }
        }
        return index;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject;
            collision.GetComponent<Movement>().enabled = false;
            caught = true;
        }
    }

    private void Update()
    {
        if (caught)
        {
            player.transform.position = transform.position;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 0.5f);
            if(Vector3.Distance(transform.position, targetPos) < 1)
            {
                player.GetComponent<Player>().TakeDamage(10000, "Death");
                Destroy(gameObject);
            }
        }
    }
}
