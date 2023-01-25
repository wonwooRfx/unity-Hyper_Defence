using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    float shootSpeed = 10f; // 날아갈 속도
    Rigidbody2D rid;
    int attackPower = 20; // 미사일 공격력

    void Start()
    {
        // GetComponent<Rigidbody2D>().AddForce(transform.right * shootSpeed); // 힘을 받아 오른쪽으로 날아간다
       
        rid = GetComponent<Rigidbody2D>();
        rid.velocity = transform.right * shootSpeed; // 속도값으로 날아간다

    }
    // Update is called once per frame
    void Update()
    {
        //transform.Translate(shootSpeed * Time.deltaTime, 0, 0); // x축으로 날아간다. 

        //Mathf.Atan2(y 벡터값, x 벡터값) * Mathf.Rad2Deg = Degree 값으로 변환
        float shootAngle = Mathf.Atan2(rid.velocity.y, rid.velocity.x) * Mathf.Rad2Deg; //각도 -> 라디안, 180/파이
        transform.eulerAngles = new Vector3(0, 0, shootAngle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" )
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Enemy") // 태그가 에너미라면
        {
            collision.gameObject.GetComponent<Enemy>().Damage(attackPower); // Enemy 스크립트에 Damage 함수 호출
            Destroy(gameObject); // 포탄
            //Destroy(collision.gameObject); // 에너미(적)
        }
    }



}
