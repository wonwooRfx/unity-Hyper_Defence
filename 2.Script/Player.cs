using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f; // �̵��ӵ�

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
        PlayerMove(); // ����ϰ� �̵� ���� �Լ��� ����� ����
    }

    void PlayerMove()
    {
        // float Ű �� �Է�
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // �⺻ ������
        moveVec = new Vector3(h, v, 0).normalized;

        transform.position += moveVec * moveSpeed * Time.deltaTime;
      
        if ( Input.GetKey(KeyCode.W)) // w�� ������ ���� �̵�
        {
            ani.SetTrigger("isUp");
        }
        if (Input.GetKey(KeyCode.S)) // �Ʒ��� �̵�
        {
            ani.SetTrigger("isDown");
        }
        if (Input.GetKey(KeyCode.D)) // ���������� �̵�
        {
            ani.SetTrigger("isRight");
        }
        if (Input.GetKey(KeyCode.A)) // �������� �̵�
        {
            ani.SetTrigger("isLeft");
        }
    }
}
