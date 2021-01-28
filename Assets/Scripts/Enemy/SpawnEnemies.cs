using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public List<GameObject> enemiesList = new List<GameObject>();
    private float timeCount;
    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount >= spawnTime) {
            SpawnEnemy();
            timeCount = 0f;
        }
    }

    void SpawnEnemy() {
        Instantiate(enemiesList[Random.Range(0, enemiesList.Count)], transform.position + new Vector3(0, Random.Range(-1f, 3f), 0), transform.rotation);
    }
}
