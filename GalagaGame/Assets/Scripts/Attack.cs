using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // 플레이어 공격을 위한 변수
    public GameObject bulletPrefab = default;
    public float attackTimer = 0;

    // 공격 속도
    public float attack_Speed = 0.2f;

    void Start()
    {
        
    }

    void Update()
    {
        attackTimer += Time.deltaTime;

        // { 플레이어 공격 로직
        if (attack_Speed <= attackTimer)
        {
            if (Input.GetKey(KeyCode.Z) == true)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                attackTimer = 0;
            }
        }
        
        
        // } 플레이어 공격 로직 end
    }
}
