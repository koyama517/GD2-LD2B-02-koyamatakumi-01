using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEffect : MonoBehaviour
{
    public GameObject trailPrefab;
    public float trailSpawnInterval = 0.1f;

    private List<GameObject> trailList = new List<GameObject>();
    private float lastSpawnTime;

    private void Start()
    {
        lastSpawnTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - lastSpawnTime >= trailSpawnInterval)
        {
            SpawnTrailObject();
            lastSpawnTime = Time.time;
        }
    }

    private void SpawnTrailObject()
    {
        GameObject newTrail = Instantiate(trailPrefab, transform.position, Quaternion.identity);
        trailList.Add(newTrail);
        Destroy(newTrail, trailSpawnInterval);
    }
}
