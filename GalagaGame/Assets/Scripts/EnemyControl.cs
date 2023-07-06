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
        // 생성할 때 랜덤 값을 지정해서 좌우로 움직이게 하기
        enemyRigid = GetComponent<Rigidbody>();
        randomValue = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        // 1이면 왼쪽
        if(randomValue == 1)
        {
            Vector3 newVelocity = new Vector3(-moveSpeed, 0f, 0f);
            enemyRigid.velocity = newVelocity;
        }

        // 2이면 오른쪽
        else if (randomValue == 2)
        {
            Vector3 newVelocity = new Vector3(moveSpeed, 0f, 0f);
            enemyRigid.velocity = newVelocity;
        }
    }

    public void EnemyDie()
    {
        // 파괴 시키기
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
