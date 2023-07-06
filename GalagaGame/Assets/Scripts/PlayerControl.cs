using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // �÷��̾� �̵��� ���� ����
    private Rigidbody playerRigid = default;
    public float speed = 8f;

    void Start()
    {
        // �÷��̾� ĳ���� ������ ������Ʈ�� ������.
        playerRigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // { �÷��̾� �̵� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigid.velocity = newVelocity;
        // } �÷��̾� �̵� ���� end
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
