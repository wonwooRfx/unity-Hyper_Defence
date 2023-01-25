using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    float shootSpeed = 10f; // ���ư� �ӵ�
    Rigidbody2D rid;
    int attackPower = 20; // �̻��� ���ݷ�

    void Start()
    {
        // GetComponent<Rigidbody2D>().AddForce(transform.right * shootSpeed); // ���� �޾� ���������� ���ư���
       
        rid = GetComponent<Rigidbody2D>();
        rid.velocity = transform.right * shootSpeed; // �ӵ������� ���ư���

    }
    // Update is called once per frame
    void Update()
    {
        //transform.Translate(shootSpeed * Time.deltaTime, 0, 0); // x������ ���ư���. 

        //Mathf.Atan2(y ���Ͱ�, x ���Ͱ�) * Mathf.Rad2Deg = Degree ������ ��ȯ
        float shootAngle = Mathf.Atan2(rid.velocity.y, rid.velocity.x) * Mathf.Rad2Deg; //���� -> ����, 180/����
        transform.eulerAngles = new Vector3(0, 0, shootAngle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" )
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Enemy") // �±װ� ���ʹ̶��
        {
            collision.gameObject.GetComponent<Enemy>().Damage(attackPower); // Enemy ��ũ��Ʈ�� Damage �Լ� ȣ��
            Destroy(gameObject); // ��ź
            //Destroy(collision.gameObject); // ���ʹ�(��)
        }
    }



}
