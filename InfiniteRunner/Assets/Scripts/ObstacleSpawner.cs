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
    [SerializeField]
    private int powerupSpawn;

    private float nextSpawnTime;
    private int numOfSpawns;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Random.Range(spawnMinTime, spawnMaxTime);
        numOfSpawns = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + Random.Range(spawnMinTime, spawnMaxTime);
            if (numOfSpawns % powerupSpawn == 0)
            {
                GameObject.Instantiate(pillarPrefabs[0], transform);
            }
            else
            {
                GameObject.Instantiate(pillarPrefabs[Random.Range(1, pillarPrefabs.Count)], transform);
            }
            numOfSpawns++;
        }
    }
}
