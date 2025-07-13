using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject planetPrefab;
    public GameObject wavyPlanetPrefab;
    public CountDownManager countDownManager;
    public float initialSpawnInterval = 2f;
    public float minimumSpawnInterval = 0.3f;
    public float spawnDecreaseRate = 0.05f;
    public float spawnRangeX = 8f;
    public float spawnRangeY = 4f;

    private float currentSpawnInterval;
    private float timeSinceLastSpawn = 0f;
    private float timeSinceLastDecrease = 0f;
    public float intervalDecreaseTime = 5f; // 何秒ごとに速くなるか

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
    }

    void Update()
    {
        //if (countDownManager.Isflag) return;

        timeSinceLastSpawn += Time.deltaTime;
        timeSinceLastDecrease += Time.deltaTime;

        if (timeSinceLastSpawn >= currentSpawnInterval)
        {
            SpawnPlanetX();
            // SpawnPlanetLeft();
            // SpawnPlanetRight();
            timeSinceLastSpawn = 0f;
        }

        if (timeSinceLastDecrease >= intervalDecreaseTime && currentSpawnInterval > minimumSpawnInterval)
        {
            currentSpawnInterval -= spawnDecreaseRate;
            timeSinceLastDecrease = 0f;
        }
    }

    void SpawnPlanetX()
    {
        float x = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(x, 6f, 0);

        GameObject obj = Random.value < 0.5f ? planetPrefab : wavyPlanetPrefab;
        obj.GetComponent<PlanetType>().SetType(PlanetType.PlanetMoveType.Top);
        
        Instantiate(obj, spawnPos, Quaternion.identity);
    }

    void SpawnPlanetLeft()
    {
        float y = Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 spawnPos = new Vector3(-10f, y, 0);

        GameObject obj = Random.value < 0.5f ? planetPrefab : wavyPlanetPrefab;
        obj.GetComponent<PlanetType>().SetType(PlanetType.PlanetMoveType.Left);
        Instantiate(obj, spawnPos, Quaternion.identity);
    }

    void SpawnPlanetRight()
    {
        float y = Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 spawnPos = new Vector3(10f, y, 0);

        GameObject obj = Random.value < 0.5f ? planetPrefab : wavyPlanetPrefab;
        obj.GetComponent<PlanetType>().SetType(PlanetType.PlanetMoveType.Right);
        Instantiate(obj, spawnPos, Quaternion.identity);
    }
}
