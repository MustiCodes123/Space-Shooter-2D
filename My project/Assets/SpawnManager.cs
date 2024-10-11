using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject[] powerupPrefabs;

    public bool stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }


    void Update()
    {
        
    }


    IEnumerator SpawnEnemyRoutine() {

        while (stopSpawning == false)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-8.9f, 8.5f), 4.7f, 0);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(4.0f);
        }
    }

    IEnumerator SpawnPowerupRoutine() { 
    
        while (stopSpawning == false) {

            Vector3 spawnPos = new Vector3(Random.Range(-8.9f, 8.5f), 4.7f, 0);
            int randomPowerup = Random.Range(0, 3);
            Instantiate(powerupPrefabs[randomPowerup], spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0, 8));


        }
    }

    public void OnPlayerDeath() {
        stopSpawning = true;
    }
}
