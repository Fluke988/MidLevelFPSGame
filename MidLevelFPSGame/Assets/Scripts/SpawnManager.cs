using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour
{
    public GameObject zombiePrefab;
    public int number;
    public float spawnRadius;
    public bool spawnOnStart = true;

    void Start()
    {
        if (spawnOnStart)
        {
            SpawnAllZombies();
        }
    }

    private void SpawnAllZombies()
    {
        for (int i = 0; i < number; i++)        //randomly spawn the zombies
        {
            Vector3 randomPoint = this.transform.position + Random.insideUnitSphere * spawnRadius;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 10.0f, NavMesh.AllAreas))
            {
                Instantiate(zombiePrefab, hit.position, Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!spawnOnStart)
        {
            if(other.gameObject.tag=="Player")
            {
                SpawnAllZombies();
            }
        }
    }

    void Update()
    {
        
    }
}
