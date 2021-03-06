﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();

    private List<Transform> currentPlatforms = new List<Transform>();

    private Transform player;
    private Transform currentPlatformPoint;
    private int platformIndex = 0;

    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < platforms.Count; i++)
        {
            Transform p = Instantiate(platforms[i], new Vector2(i * 30, transform.position.y), transform.rotation).transform;
            offset  += 30f;
            currentPlatforms.Add(p);
        }

        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
    }

    // Update is called once per frame
    void Update()
    {
        Move(); 
    }

    void Move() {
        float distance = player.position.x - currentPlatformPoint.position.x;

        if (distance >= 1) {
            Recycle(currentPlatforms[platformIndex].gameObject);
            platformIndex++;

            if (platformIndex > currentPlatforms.Count - 1) {
                platformIndex = 0;
            }

            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
        }
    }

    public void Recycle(GameObject platform) {
        platform.transform.position = new Vector2(offset, transform.position.y);
        
        if(platform.GetComponent<Platform>().spawnEnemiesPlatform != null) {
            platform.GetComponent<Platform>().spawnEnemiesPlatform.Spawn();
        }
        
        offset  += 30f;
    }
}
