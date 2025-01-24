using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemies = new();
    public List<GameObject> pickUps = new();
    public List<GameObject> pickUpSpots = new();
    public List<GameObject> activePickUps = new();
    [SerializeField] private Rock[] rocks;
    [SerializeField] private List<GameObject> explodeWalls = new();
    public GameObject activeWisp;
    public List<EnemyRoom> rooms = new();
    private Player player;
    private void Start()
    {
        rocks = FindObjectsOfType<Rock>();
        player = FindObjectOfType<Player>();
    }
    private void OnEnable()
    {
        ButtonScript.GameReset += OnReset;
    }
    private void OnDisable()
    {
        ButtonScript.GameReset -= OnReset;
    }
    public void OnReset()
    {
        Camera.main.transform.position = new Vector3 (0, 0, -10);
        player.grabbed = false;
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            Destroy(enemies[i]);
            enemies.RemoveAt(i);
        }
        for(int i = 0; i < activePickUps.Count; i++)
        {
            Destroy(activePickUps[i]);
            activePickUps.RemoveAt(i);
        }
        for(int i = 0; i < pickUpSpots.Count; i++)
        {
            Instantiate(pickUps[i], pickUpSpots[i].transform.position, Quaternion.identity);
        }
        for(int i = 0; i < explodeWalls.Count; i++)
        {
            if (explodeWalls[i].GetComponent<SpriteRenderer>().sprite == explodeWalls[i].GetComponent<CrackedWall>().brokenSprite)
            {
                explodeWalls[i].GetComponent<SpriteRenderer>().sprite = explodeWalls[i].GetComponent<CrackedWall>().fullWall;
                explodeWalls[i].GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        for(int i = 0; i < rocks.Length; i++)
        {
            if (rocks[i].GetComponent<SpriteRenderer>().sprite == null)
            {
                rocks[i].GetComponent<SpriteRenderer>().sprite = rocks[i].fullRock;
                rocks[i].GetComponent<BoxCollider2D>().enabled = true;
                rocks[i].hitPoints = 3;
            }
        }
        if (activeWisp != null)
        {
            Destroy(activeWisp);
        }
        for(int i = 0; i < rooms.Count; i++)
        {
            rooms[i].started = false;
        }
    }
}
