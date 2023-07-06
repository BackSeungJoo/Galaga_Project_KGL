using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float Speed = default;
    private Rigidbody rigid = default;
    private Transform target = default;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        target = FindObjectOfType<PlayerControl>().transform;

        transform.LookAt(target);
        rigid.velocity = transform.forward * Speed; // z 방향
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    // 플레이어를 죽이는 코드
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerControl playerControl = other.GetComponent<PlayerControl>();

            if (playerControl != null)
            {
                playerControl.Die();
            }
        }
    }
    
}
