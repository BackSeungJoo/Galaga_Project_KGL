using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // ���� �Ŵ���
    private GameManage gameManage = default;
    private EnemySpawner enemySpawner = default;

    public GameObject particlePrefab;  // ��ƼŬ ������ ���� ����
    private Rigidbody enemyRigid = default;
    private int randomValue = default;

    // Start is called before the first frame update
    void Start()
    {
        // ������ �� ���� ���� �����ؼ� �¿�� �����̰� �ϱ�
        enemyRigid = GetComponent<Rigidbody>();
        randomValue = Random.Range(1, 3);
        gameManage = GameObject.FindAnyObjectByType<GameManage>();
        enemySpawner = EnemySpawner.FindAnyObjectByType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1�̸� ����
        if (randomValue == 1)
        {
            Vector3 newVelocity = new Vector3(-enemySpawner.enemyMoveSpeed, 0f, 0f);
            enemyRigid.velocity = newVelocity;
        }

        // 2�̸� ������
        else if (randomValue == 2)
        {
            Vector3 newVelocity = new Vector3(enemySpawner.enemyMoveSpeed, 0f, 0f);
            enemyRigid.velocity = newVelocity;
        }
    }

    public void EnemyDie()
    {
        // ��ƼŬ ����
        GameObject particleEffect = Instantiate(particlePrefab, transform.position, Quaternion.identity);

        // ��ƼŬ�� ����� �� �ı��ǵ��� ����
        ParticleSystem particleSystem = particleEffect.GetComponent<ParticleSystem>();
        float duration = particleSystem.main.duration + particleSystem.main.startLifetimeMultiplier;
        Destroy(particleEffect, duration);

        // �ı� ��Ű��
        Destroy(gameObject);

        // ���� ���� 500�� ���
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
