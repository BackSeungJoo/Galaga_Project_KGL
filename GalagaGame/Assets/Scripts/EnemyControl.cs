using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // 게임 매니저
    private GameManage gameManage = default;
    private EnemySpawner enemySpawner = default;

    public GameObject particlePrefab;  // 파티클 프리팹 변수 선언
    private Rigidbody enemyRigid = default;
    private int randomValue = default;

    // Start is called before the first frame update
    void Start()
    {
        // 생성할 때 랜덤 값을 지정해서 좌우로 움직이게 하기
        enemyRigid = GetComponent<Rigidbody>();
        randomValue = Random.Range(1, 3);
        gameManage = GameObject.FindAnyObjectByType<GameManage>();
        enemySpawner = EnemySpawner.FindAnyObjectByType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1이면 왼쪽
        if (randomValue == 1)
        {
            Vector3 newVelocity = new Vector3(-enemySpawner.enemyMoveSpeed, 0f, 0f);
            enemyRigid.velocity = newVelocity;
        }

        // 2이면 오른쪽
        else if (randomValue == 2)
        {
            Vector3 newVelocity = new Vector3(enemySpawner.enemyMoveSpeed, 0f, 0f);
            enemyRigid.velocity = newVelocity;
        }
    }

    public void EnemyDie()
    {
        // 파티클 생성
        GameObject particleEffect = Instantiate(particlePrefab, transform.position, Quaternion.identity);

        // 파티클이 재생된 후 파괴되도록 설정
        ParticleSystem particleSystem = particleEffect.GetComponent<ParticleSystem>();
        float duration = particleSystem.main.duration + particleSystem.main.startLifetimeMultiplier;
        Destroy(particleEffect, duration);

        // 파괴 시키기
        Destroy(gameObject);

        // 게임 점수 500점 상승
        gameManage.nowScore += 500;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wall") 
        {
            if (randomValue == 1)
            {
                randomValue = 2;
            }

            else if (randomValue == 2)
            {
                randomValue = 1;
            }
        }
    }
}
