using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // �÷��̾� ������ ���� ����
    public GameObject bulletPrefab = default;

    void Start()
    {
        
    }

    void Update()
    {
        // { �÷��̾� ���� ����
        if (Input.GetKeyDown(KeyCode.Z) == true)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        // } �÷��̾� ���� ���� end
    }
}
