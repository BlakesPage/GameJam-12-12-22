using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyTypes = new List<GameObject>();
    [SerializeField] private Transform TopLeft;
    [SerializeField] private Transform TopRight;
    [SerializeField] private Transform BottomLeft;

    private GameObject player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerManager>().gameObject;
    }


    float lastTime;
    private void Update()
    {
        if(Time.time > lastTime + EnemyStats.SpawnInterval)
        {
            lastTime = Time.time;
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        for (int i = 0; i < EnemyStats.SpawnAmount; i++)
        {
            if (EnemyStats.enemies.Count < 150f)
            {
                int rand = Random.Range(0, enemyTypes.Count);
                GameObject enemy = Instantiate(enemyTypes[rand], randomSpawn(TopLeft, BottomLeft, TopRight), Quaternion.identity);
                EnemyStats.enemies.Add(enemy);
            }
        }
    }

    private Vector3 randomSpawn(Transform topleft, Transform bottomLeft, Transform topRight)
    {
        float x = Random.Range(topleft.position.x + 1, topRight.position.x - 1);
        float y = Random.Range(bottomLeft.position.y + 1, topleft.position.y - 1);
        Vector3 POS = new Vector3(x, y, 0);

        while(Vector3.Distance(POS, player.transform.position) < 15f)
        {
            float i = Random.Range(topleft.position.x + 1, topRight.position.x - 1);
            float j = Random.Range(bottomLeft.position.y + 1, topleft.position.y - 1);
            POS = new Vector3(i, j, 0);
        }

        return POS;
    }
}
