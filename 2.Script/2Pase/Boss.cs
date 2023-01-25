using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    float speed = 2f; // 이동속도
    public GameObject bossBullet; // 보스총알 프리팹
    public Transform bossShootPos; // 발사할 곳

    Animator ani; // 애니메이터
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootBullet", 2f, 1f);
        ani = GetComponent<Animator>(); // 애니메이터
        
    }

    void ShootBullet()
    {
        BossAttack();
    }

    // Update is called once per frame
    void Update()
    {
        BossMove();
      
    }

    void BossMove()
    {
        // 기본적인 이동
        Vector3 pos = transform.position;
        pos.y += speed * Time.deltaTime;
        transform.position = pos;
        // 방향 바꾸기
        if (pos.y < -3f)
        {
            speed = Mathf.Abs(speed); //위로 이동
        }
        if (pos.y > 3f)
        {
            speed = -Mathf.Abs(speed); //아래로 이동
        }

    }
    void BossAttack()
    {
        Instantiate(bossBullet, bossShootPos.position, Quaternion.identity); // 총알 프리팹 생성 위치는 BossShootPos
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //부딫히는 물체의 태그가 나이프면
        if(collision.gameObject.tag == "Knife")
        {
            // 피격 애니메이션 발동
            ani.SetTrigger("isDamage");
        }
    }
}


