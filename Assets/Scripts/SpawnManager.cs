using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private float spawnRangeMinZ = -10;
    private float spawnRangeMaxZ = 6.1f;
    private float spwanPosX = 25;
    private float startDelay = 2;
    private float spawnInterval = 0.7f;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);
        playerControllerScript = GameObject.Find("player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnRandomObstacle()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
        Vector3 spawnPos = new Vector3(spwanPosX, 0, Random.Range(spawnRangeMinZ, spawnRangeMaxZ));
        Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation);
    }
}
