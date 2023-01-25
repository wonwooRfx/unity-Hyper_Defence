using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    float bulletSpeed = 7f;

    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        //0���� 9���� ���߿� �ϳ��� �������� �����ͼ�
        int randValue = Random.Range(0, 10);
        GameObject target = GameObject.Find("Player");
        // ���� 3���� ������ �÷��̾����
        if (target != null)
        {
            if (randValue < 3)
            {
                //GameObject target = GameObject.Find("Player");
                //������ ���ϰ� �ʹ� target - me
                dir = target.transform.position - transform.position;
                //������ ũ�� 1
                dir.Normalize();

            }
            //�׷��� ������ ���ʹ���
            else
            {
                dir = Vector3.left;

            }
        }

        else
        {
            dir = Vector3.left;
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += dir * bulletSpeed * Time.deltaTime;

        if(transform.position.x <= -10f) // -10f ���� �� �ִٸ� �����ض�
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �΋H���� ��ü�� �±װ� Player��� �������.
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
