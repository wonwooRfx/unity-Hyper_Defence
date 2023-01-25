using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurMonster : MonoBehaviour
{
    Rigidbody2D rid;
    float speed = 5f; // �̵��ӵ�

    public JellyData Jdata; // ����������
    int attackPower; // ���ݷ�
    int hp; // ü��
    int maxHp; // �ִ�ü��

    public GameObject[] enemys = new GameObject[5];

    GameObject ufo; // ���� ������ ufo  

    Animator ani; // �ִϸ��̼�
    // Start is called before the first frame update
    void Start()
    {
        rid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        attackPower = Jdata.Attack;
        hp = Jdata.Hp;
        maxHp = Jdata.MaxHP;

        hp = maxHp;

        ufo = GameObject.Find("UFO"); // UFO�� �̸����� ã�´�.


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime); // ���������� �̵�

       // for (int i = 0; i < 5; i++)
       // {
           // if (Vector3.Distance(enemys[i].transform.position, transform.position) <= 10f) // ���� ����� �Ÿ��� 10f���϶��
           // {
                //speed = 0; //�����
           // }
       // }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") // �±װ� Enemy���
        {
            speed = 0;
          // collision.gameObject.GetComponent<Enemy>().Damage(attackPower); // Enemy ��ũ��Ʈ�� Damage �Լ� ȣ��
           InvokeRepeating("EnemyAttackTime", 0.5f, 2f); // 0.5f ���� �� 2f ���� �ݺ�
        }
        else
        {
            speed = 5f; // �ӵ��� �ٽ� ������
        }
    }

    void EnemyAttackTime()
    {
        enemys[0].gameObject.GetComponent<Enemy>().Damage(attackPower);
        enemys[1].gameObject.GetComponent<Enemy>().Damage(attackPower);
        enemys[2].gameObject.GetComponent<Enemy>().Damage(attackPower);
        enemys[3].gameObject.GetComponent<Enemy>().Damage(attackPower);
        enemys[4].gameObject.GetComponent<Enemy>().Damage(attackPower);
    }

    public void Damage(int Damage) // ������ �Լ�
    {
        GameObject jelly = Instantiate(gameObject);
        hp -= Damage;
        if (hp <= 0)
        {
            Destroy(jelly);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UFO") // �±װ� UFO���
        {
            speed = 0;
            InvokeRepeating("AttackTime", 0.5f, 2f); // 0.5f ���� �� 2f ���� �ݺ�
            
        }
    }

    void AttackTime()
    {
        ani.SetTrigger("doAttack"); // �ִϸ��̼� �ߵ�
        ufo.GetComponent<UFO>().Damage(attackPower); // UFO ��ũ��Ʈ�� Damage �Լ� ȣ��
    }


}

  
