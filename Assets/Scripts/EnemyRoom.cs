using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoom : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private List<GameObject> doors = new();
    [SerializeField] private List<GameObject> spawns = new();
    [SerializeField] private List<GameObject> enemies = new();
    [SerializeField] private List<GameObject> activeEnemies = new();
    [SerializeField] private List<GameObject> wispSpawns = new();

    [SerializeField] private GameObject wisp;
    
    public bool started;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.rooms.Add(this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !started)
        {
            for(int i = 0; i < doors.Count; i++)
            {
                doors[i].SetActive(true);
            }
            for(int i = 0;i < spawns.Count; i++)
            { 
                activeEnemies.Add(Instantiate(enemies[Random.Range(0, enemies.Count)], spawns[i].transform.position, Quaternion.identity));
            }
            if (wispSpawns.Count > 0)
            {
                Instantiate(wisp, wispSpawns[Random.Range(0, wispSpawns.Count)].transform.position, Quaternion.identity);
            }
            started = true;
        }
    }
    private void Update()
    {
        for (int i = 0; i < activeEnemies.Count; i++)
        {
            if (activeEnemies[i] == null)
            {
                activeEnemies.RemoveAt(i);
            }
        }
        if(activeEnemies.Count == 0)
        {
            for( int i = 0; i < doors.Count; i++)
            {
                    doors[i].SetActive(false);
            }
        }
        
    }
}
