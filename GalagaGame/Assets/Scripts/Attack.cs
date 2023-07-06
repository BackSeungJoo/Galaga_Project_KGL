using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // �÷��̾� ������ ���� ����
    public GameObject bulletPrefab = default;
    public float attackTimer = 0;

    // ���� �ӵ�
    public float attack_Speed = 0.2f;

    void Start()
    {
        
    }

    void Update()
    {
        attackTimer += Time.deltaTime;

        // { �÷��̾� ���� ����
        if (attack_Speed <= attackTimer)
        {
            if (Input.GetKey(KeyCode.Z) == true)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                attackTimer = 0;
            }
        }
        
        
        // } �÷��̾� ���� ���� end
    }
}
