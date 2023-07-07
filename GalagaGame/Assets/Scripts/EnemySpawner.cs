using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameManage gameManage = default;
    public GameObject enemyPrefab;

    public float enemyMoveSpeed = 1f;
    public int hard = 0;
    private float hardGame = default;
    private float enemyInterval = 1.5f;
    private float gameTime = default;

    void Start()
    {
        gameManage = GameObject.FindAnyObjectByType<GameManage>();
    }

    private void Update()
    {
        if(gameManage.isGameOver == false)
        {
            hardGame += Time.deltaTime;
            if (hardGame > 15)
            {
                enemyInterval -= 0.2f;
                hardGame = 0;

                // 난이도
                hard += 1;

                // 이동 속도.
                enemyMoveSpeed += (0.3f * hard);
            }

            gameTime += Time.deltaTime;
            if (gameTime > enemyInterval)
            {
                gameTime = 0;
                GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-4f, 4), 0.2f, Random.Range(4, 7)), Quaternion.identity);
            }
        }

        else
        {
            enemyInterval = 500;
            enemyMoveSpeed = 0;
        }
    }
}
