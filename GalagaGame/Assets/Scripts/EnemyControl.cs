using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Rigidbody enemyRigid = default;
    public float moveSpeed = 0.5f;
    private int randomValue = default;

    // Start is called before the first frame update
    void Start()
    {
        // ������ �� ���� ���� �����ؼ� �¿�� �����̰� �ϱ�
        enemyRigid = GetComponent<Rigidbody>();
        randomValue = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        // 1�̸� ����
        if(randomValue == 1)
        {
            Vector3 newVelocity = new Vector3(-moveSpeed, 0f, 0f);
            enemyRigid.velocity = newVelocity;
        }

        // 2�̸� ������
        else if (randomValue == 2)
        {
            Vector3 newVelocity = new Vector3(moveSpeed, 0f, 0f);
            enemyRigid.velocity = newVelocity;
        }
    }

    public void EnemyDie()
    {
        // �ı� ��Ű��
        Destroy(gameObject);
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
