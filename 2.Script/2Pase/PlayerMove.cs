using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5.0f; // 이동속도
    public float jumpPower = 10f; // 점프힘

    Vector3 moveVec;

    Animator ani;

    Rigidbody2D rid;
    public bool isJump; // 점프를 제어할 변수


    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rid = GetComponent<Rigidbody2D>();
        isJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        SideMove(); // 횡이동 함수
        Attack(); // 공격 함수
       
    }

    void SideMove()
    {
        // float 키 값 입력
        float h = Input.GetAxis("Horizontal");

        // 기본 움직임(횡이동)
        moveVec = new Vector3(h, 0, 0).normalized;

        transform.position += moveVec * moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A)) // 왼쪽으로 이동
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0); // 왼쪽보기
            ani.SetTrigger("doRun"); // 뛰는 애니메이션
        }

        if (Input.GetKey(KeyCode.D)) // 오른쪽으로 이동
        {
            transform.rotation = Quaternion.Euler(0, 0f, 0); // 오른쪽보기
            ani.SetTrigger("doRun");
        }

    }

    void Attack() 
    {

        if (Input.GetMouseButtonDown(0)) // 좌클릭을 한다면
        {
            ani.SetTrigger("doShot"); // 공격애니메이션 발동
          
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" && isJump == true) // 부딫히는 물체의 태그가 그라운드 이고 isJump가 true면
        {
            if (Input.GetButtonDown("Jump"))
            {
                // Space바를 누르면
                rid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse); // 질량의 영향을 받으며 짧은 순간에 힘을 발동
                isJump = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isJump = true; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 보스총알에 부딫히면
       if(collision.gameObject.tag == "BossBullet")
        {
            ani.SetTrigger("doDamage"); // 피격애니메이션 발동
        }
    }
}