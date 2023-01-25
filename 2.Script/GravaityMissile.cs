using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravaityMissile : MonoBehaviour
{
    Rigidbody2D rid;
    int attackPower = 100; // 융단폭격 공격력
    // Start is called before the first frame update
    void Start()
    {
        rid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") // 부딫히는 물체의 태그가 Ground라면
        {
            Destroy(gameObject); // 삭제해라
        }

        if (collision.gameObject.tag == "Enemy") // 태그가 에너미라면
        {
            collision.gameObject.GetComponent<Enemy>().Damage(attackPower); // Enemy 스크립트에 Damage 함수 호출
            Destroy(gameObject); // 포탄
            Destroy(collision.gameObject); // 에너미(적)
        }
    }
}
