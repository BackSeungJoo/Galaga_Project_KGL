using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float enemyInterval = 1.5f;
    private float gameTime = default;

    void Start()
    {
        //StartCoroutine(spawnEneny(enemyInterval, enemyPrefab));
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime > enemyInterval)
        {
            gameTime = 0;
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-4f, 4), 0.2f, Random.Range(4, 7)), Quaternion.identity);

        }

    }
}
