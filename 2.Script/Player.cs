using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f; // 이동속도

    Vector3 moveVec;

    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove(); // 깔끔하게 이동 관련 함수를 만들어 뒀음
    }

    void PlayerMove()
    {
        // float 키 값 입력
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 기본 움직임
        moveVec = new Vector3(h, v, 0).normalized;

        transform.position += moveVec * moveSpeed * Time.deltaTime;
      
        if ( Input.GetKey(KeyCode.W)) // w를 누르면 위로 이동
        {
            ani.SetTrigger("isUp");
        }
        if (Input.GetKey(KeyCode.S)) // 아래로 이동
        {
            ani.SetTrigger("isDown");
        }
        if (Input.GetKey(KeyCode.D)) // 오른쪽으로 이동
        {
            ani.SetTrigger("isRight");
        }
        if (Input.GetKey(KeyCode.A)) // 왼쪽으로 이동
        {
            ani.SetTrigger("isLeft");
        }
    }
}
