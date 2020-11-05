/* Broc Edson
 * Assignment 7
 * Manages the spawning of enemies
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int enemyCount;
    public int waveNumber = 1;
    public Text waveText;
    private float spawnRange = 9;
    private GameManager gameManager;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float SpawnPosX = Random.Range(-spawnRange, spawnRange);
        float SpawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(SpawnPosX, 0f, SpawnPosZ);
        return randomPos;
    }

    private void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if(enemyCount == 0)
        {
            waveNumber++;
            if (waveNumber > 10 && !gameManager.ended)
            {
                gameManager.ended = true;
                gameManager.won = true;
            }
            else if(!gameManager.ended)
            {
                SpawnEnemyWave(waveNumber);
                SpawnPowerup(1);
                waveText.text = "Wave: " + waveNumber;
            }
        }
    }

    private void SpawnPowerup(int powerupsToSpawn)
    {
        for (int i = 0; i < powerupsToSpawn; i++)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
}
