using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHeartBar : MonoBehaviour
{
    public GameObject heartPrefab;
    private Player playerHealth;
    public List<HealthHearts> hearts = new List<HealthHearts>();

    private void OnEnable()
    {
        Player.OnPlayerDamaged += DrawHearts;
        HeartPickUp.OnPickUp += DrawHearts;
        Enemy.PlayerInteract += DrawHearts;
        Bomb.PlayerInteract += DrawHearts;
    }

    private void OnDisable()
    {
        Player.OnPlayerDamaged -= DrawHearts;
        HeartPickUp.OnPickUp -= DrawHearts;
        Enemy.PlayerInteract -= DrawHearts;
        Bomb.PlayerInteract -= DrawHearts;
    }

    private void Awake()
    {
        playerHealth = FindObjectOfType<Player>();
    }

    private void Start()
    {
        DrawHearts();
    }
    public void DrawHearts()
    {
        ClearHearts();


        float maxHealthRemainder = playerHealth.maxHealth % 2;
        int heartsToMake = (int)((playerHealth.maxHealth / 2) + maxHealthRemainder);
        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

        for(int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(playerHealth.health - (i * 2), 0, 2);
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
        }
    }

    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthHearts heartComponent = newHeart.GetComponent<HealthHearts>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }


    public void ClearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHearts>();
    }
}
