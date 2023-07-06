using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // 플레이어 공격을 위한 변수
    public GameObject bulletPrefab = default;

    void Start()
    {
        
    }

    void Update()
    {
        // { 플레이어 공격 로직
        if (Input.GetKeyDown(KeyCode.Z) == true)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        // } 플레이어 공격 로직 end
    }
}
