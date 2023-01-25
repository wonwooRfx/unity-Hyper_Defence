using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rid;
    float speed = 5f; // �̵��ӵ�
    
    public MonsterData Mdata; // ���� ������
    public int HP;
    public int MaxHP;
    public int attackPower; // ���ݷ�

    public Slider hpSlider; // ü�¹�
    public Canvas hpCanvas; // ü�¹� ĵ����

    GameObject castle; // ����

    Animator ani; // �ִϸ��̼�

    // Start is called before the first frame update
    void Start()
    {
        rid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        HP = Mdata.Hp; // ���� �����Ϳ��� �޾ƿ�
        MaxHP = Mdata.MaxHP;
        attackPower = Mdata.Attack;
       
        castle = GameObject.Find("Castle"); // ������ �̸����� ã�´�.
       
        HP = MaxHP; //������ ������ ���̱� ������ ���� ü���� ���ٰ� ���

      

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime); // �������� �̵�
        hpSlider.value = (float)HP / (float)MaxHP; // ���� ü�¹��� value�� �ݿ��Ѵ�.
    }

    public void Damage(int Damage) // ������ �Լ�
    {
        GameObject enemy = Instantiate(this.gameObject);
        HP -= Damage;
        if(HP <= 0)
        {
            Destroy(enemy);
            print(HP);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Castle") // �±װ� castle���
        {
            speed = 0;
            InvokeRepeating("AttackTime", 0.5f, 2f); // 0.5f ���� �� 2f ���� �ݺ�
            //collision.gameObject.GetComponent<Castle>().Damage(attackPower); // Castle ��ũ��Ʈ�� Damage �Լ� ȣ��
        }
    }

    void AttackTime()
    {
        ani.SetTrigger("doAttack"); // �ִϸ��̼� �ߵ�
        castle.GetComponent<Castle>().Damage(attackPower); // Castle ��ũ��Ʈ�� Damage �Լ� ȣ��
    }
}
