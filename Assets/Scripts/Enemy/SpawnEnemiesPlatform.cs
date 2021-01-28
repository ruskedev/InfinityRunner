using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesPlatform : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject currentEnemy;

    public List<Transform> spawnPoints = new List<Transform>();

    void Start() {
        Spawn();
    }

    public void Spawn() {
        if (currentEnemy == null) {
            CreateEnemy();
        } else {
            int pos = Random.Range(0, spawnPoints.Count);
            currentEnemy.transform.position = spawnPoints[pos].position;
            currentEnemy.transform.rotation = spawnPoints[pos].rotation;
        }
    }

    void CreateEnemy() {
        int pos = Random.Range(0, spawnPoints.Count);

        currentEnemy = Instantiate(enemyPrefab, spawnPoints[pos].position, spawnPoints[pos].rotation);
    }
}
