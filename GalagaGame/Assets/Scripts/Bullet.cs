using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public float Speed = default;
    private Rigidbody rigid = default;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.up * Speed;

        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 적을 죽이는 코드
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyControl enemyControl = other.GetComponent<EnemyControl>();

            if (enemyControl != null)
            {
                enemyControl.EnemyDie();
            }
        }

        // 벽에 부딪히면 파괴
        if(other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
