using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> pillarPrefabs;
    [SerializeField]
    private float spawnMinTime;
    [SerializeField]
    private float spawnMaxTime;

    private float nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnMinTime = .5f;
        spawnMaxTime = 2.0f;
        nextSpawnTime = Random.Range(spawnMinTime, spawnMaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + Random.Range(spawnMinTime, spawnMaxTime);
            GameObject.Instantiate(pillarPrefabs[Random.Range(0, 0)], transform);
        }
    }
}
