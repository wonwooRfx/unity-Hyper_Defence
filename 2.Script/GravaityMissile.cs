using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravaityMissile : MonoBehaviour
{
    Rigidbody2D rid;
    int attackPower = 100; // �������� ���ݷ�
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
        if (collision.gameObject.tag == "Ground") // �΋H���� ��ü�� �±װ� Ground���
        {
            Destroy(gameObject); // �����ض�
        }

        if (collision.gameObject.tag == "Enemy") // �±װ� ���ʹ̶��
        {
            collision.gameObject.GetComponent<Enemy>().Damage(attackPower); // Enemy ��ũ��Ʈ�� Damage �Լ� ȣ��
            Destroy(gameObject); // ��ź
            Destroy(collision.gameObject); // ���ʹ�(��)
        }
    }
}
