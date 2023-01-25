using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5.0f; // �̵��ӵ�
    public float jumpPower = 10f; // ������

    Vector3 moveVec;

    Animator ani;

    Rigidbody2D rid;
    public bool isJump; // ������ ������ ����


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
        SideMove(); // Ⱦ�̵� �Լ�
        Attack(); // ���� �Լ�
       
    }

    void SideMove()
    {
        // float Ű �� �Է�
        float h = Input.GetAxis("Horizontal");

        // �⺻ ������(Ⱦ�̵�)
        moveVec = new Vector3(h, 0, 0).normalized;

        transform.position += moveVec * moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A)) // �������� �̵�
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0); // ���ʺ���
            ani.SetTrigger("doRun"); // �ٴ� �ִϸ��̼�
        }

        if (Input.GetKey(KeyCode.D)) // ���������� �̵�
        {
            transform.rotation = Quaternion.Euler(0, 0f, 0); // �����ʺ���
            ani.SetTrigger("doRun");
        }

    }

    void Attack() 
    {

        if (Input.GetMouseButtonDown(0)) // ��Ŭ���� �Ѵٸ�
        {
            ani.SetTrigger("doShot"); // ���ݾִϸ��̼� �ߵ�
          
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" && isJump == true) // �΋H���� ��ü�� �±װ� �׶��� �̰� isJump�� true��
        {
            if (Input.GetButtonDown("Jump"))
            {
                // Space�ٸ� ������
                rid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse); // ������ ������ ������ ª�� ������ ���� �ߵ�
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
        // �����Ѿ˿� �΋H����
       if(collision.gameObject.tag == "BossBullet")
        {
            ani.SetTrigger("doDamage"); // �ǰݾִϸ��̼� �ߵ�
        }
    }
}