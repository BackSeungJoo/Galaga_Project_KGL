using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameManage gameManage;
    public float Speed;
    private Rigidbody rigid;
    private Transform target;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        target = FindObjectOfType<PlayerControl>().transform;

        transform.LookAt(target);
        rigid.velocity = transform.forward * Speed; // z ¹æÇâ

        gameManage = FindObjectOfType<GameManage>();

        Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManage.life -= 1;

            if (gameManage.life < 1)
            {
                PlayerControl playerControl = other.GetComponent<PlayerControl>();

                if (playerControl != null)
                {
                    playerControl.Die();
                }
            }
        }

        // º®¿¡ ºÎµúÈ÷¸é ÆÄ±«
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}