using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    float speed = 2f; // �̵��ӵ�
    public GameObject bossBullet; // �����Ѿ� ������
    public Transform bossShootPos; // �߻��� ��

    Animator ani; // �ִϸ�����
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootBullet", 2f, 1f);
        ani = GetComponent<Animator>(); // �ִϸ�����
        
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
        // �⺻���� �̵�
        Vector3 pos = transform.position;
        pos.y += speed * Time.deltaTime;
        transform.position = pos;
        // ���� �ٲٱ�
        if (pos.y < -3f)
        {
            speed = Mathf.Abs(speed); //���� �̵�
        }
        if (pos.y > 3f)
        {
            speed = -Mathf.Abs(speed); //�Ʒ��� �̵�
        }

    }
    void BossAttack()
    {
        Instantiate(bossBullet, bossShootPos.position, Quaternion.identity); // �Ѿ� ������ ���� ��ġ�� BossShootPos
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�΋H���� ��ü�� �±װ� ��������
        if(collision.gameObject.tag == "Knife")
        {
            // �ǰ� �ִϸ��̼� �ߵ�
            ani.SetTrigger("isDamage");
        }
    }
}


