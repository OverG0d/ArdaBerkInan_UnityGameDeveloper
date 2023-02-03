using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("AI")]
    [SerializeField] private GameObject badFish;
    [SerializeField] private GameObject goodFish;

    [Header("Spawns")]
    [SerializeField] private List<GameObject> spawnPoints = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTimer", 3f, 3f);
    }

    void SpawnTimer()
    {
        // Chooses random AI to spawn at random spawn point
        float random = Random.Range(0f, 5f);
        int randomSpawnPoint = Random.Range(0, 3);
        if (random >= 0 && random <= 2)
        {
            GameObject spawnClone = (GameObject)Instantiate(goodFish, spawnPoints[randomSpawnPoint].transform.position, spawnPoints[randomSpawnPoint].transform.rotation);
            if (randomSpawnPoint == 0 || randomSpawnPoint == 1)
            {
                // Spawn on left side
                spawnClone.GetComponent<Fish>().leftSide = true;
            }
            else if (randomSpawnPoint == 2 || randomSpawnPoint == 3)
            {
                // Spawn on right side
                spawnClone.GetComponent<Fish>().leftSide = false;
            }
        }
        else if(random >= 3 && random <= 5)
        {
            GameObject spawnClone = (GameObject)Instantiate(badFish, spawnPoints[randomSpawnPoint].transform.position, spawnPoints[randomSpawnPoint].transform.rotation);
            if (randomSpawnPoint == 0 || randomSpawnPoint == 1)
            {
                spawnClone.GetComponent<Fish>().leftSide = true;

            }
            else if (randomSpawnPoint == 2 || randomSpawnPoint == 3)
            {
                spawnClone.GetComponent<Fish>().leftSide = false;
            }
        }
    }
}
