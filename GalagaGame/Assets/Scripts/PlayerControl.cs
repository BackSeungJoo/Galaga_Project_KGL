using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // 플레이어 이동을 위한 변수
    private Rigidbody playerRigid = default;
    public float speed = 8f;

    void Start()
    {
        // 플레이어 캐릭터 본인의 컴포넌트를 가져옴.
        playerRigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // { 플레이어 이동 로직
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigid.velocity = newVelocity;
        // } 플레이어 이동 로직 end
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
