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
    public List<GameObject> explodeWalls = new();
    public List<GameObject> activeWisps = new();
    public List<EnemyRoom> rooms = new();
    private Player player;
    public GameObject pauseScreen;
    private bool paused;
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
        for(int i = activePickUps.Count - 1; i >= 0; i--)
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
        for (int i = activeWisps.Count - 1; i >= 0; i--)
        {
            if (activeWisps[i] != null)
            {
                Destroy(activeWisps[i]);
            }
        }
        for(int i = 0; i < rooms.Count; i++)
        {
            rooms[i].started = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
                paused = false;
                player.enabled = true;
            }
            else
            {
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
                paused = true;
                player.enabled = false;
            }
        }
        
    }
}
