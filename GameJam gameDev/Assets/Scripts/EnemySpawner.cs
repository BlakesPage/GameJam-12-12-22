using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyTypes = new GameObject[1];
    //[SerializeField] private List<GameObject> spawnLocations = new List<GameObject>();
    [SerializeField] private Transform TopLeft;
    [SerializeField] private Transform TopRight;
    [SerializeField] private Transform BottomLeft;


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
            int rand = Random.Range(0, enemyTypes.Length - 1);
            GameObject enemy = Instantiate(enemyTypes[rand], randomSpawn(TopLeft, BottomLeft, TopRight), Quaternion.identity);
            EnemyStats.enemies.Add(enemy);
        }
    }

    private Vector3 randomSpawn(Transform topleft, Transform bottomLeft, Transform topRight)
    {
        float x = Random.Range(topleft.position.x + 1, topRight.position.x - 1);
        float y = Random.Range(bottomLeft.position.y + 1, topleft.position.y - 1);
        return new Vector3(x, y, 0);
    }

    //private Vector2 randomSpawn(Vector2 topleft, Vector2 bottomLeft, Vector2 topRight)
    //{
    //    float x = Random.Range(topleft.x + 1, topRight.x - 1);
    //    float y = Random.Range(bottomLeft.y + 1, topleft.y - 1);
    //    return new Vector2(x, y);
    //}  
}
