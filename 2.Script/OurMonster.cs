using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurMonster : MonoBehaviour
{
    Rigidbody2D rid;
    float speed = 5f; // 이동속도

    public JellyData Jdata; // 젤리데이터
    int attackPower; // 공격력
    int hp; // 체력
    int maxHp; // 최대체력

    public GameObject[] enemys = new GameObject[5];

    GameObject ufo; // 적군 기지인 ufo  

    Animator ani; // 애니메이션
    // Start is called before the first frame update
    void Start()
    {
        rid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        attackPower = Jdata.Attack;
        hp = Jdata.Hp;
        maxHp = Jdata.MaxHP;

        hp = maxHp;

        ufo = GameObject.Find("UFO"); // UFO를 이름으로 찾는다.


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime); // 오른쪽으로 이동

       // for (int i = 0; i < 5; i++)
       // {
           // if (Vector3.Distance(enemys[i].transform.position, transform.position) <= 10f) // 만약 적들과 거리가 10f이하라면
           // {
                //speed = 0; //멈춰라
           // }
       // }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") // 태그가 Enemy라면
        {
            speed = 0;
          // collision.gameObject.GetComponent<Enemy>().Damage(attackPower); // Enemy 스크립트에 Damage 함수 호출
           InvokeRepeating("EnemyAttackTime", 0.5f, 2f); // 0.5f 지연 후 2f 마다 반복
        }
        else
        {
            speed = 5f; // 속도를 다시 돌린다
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

    public void Damage(int Damage) // 데미지 함수
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
        if (collision.gameObject.tag == "UFO") // 태그가 UFO라면
        {
            speed = 0;
            InvokeRepeating("AttackTime", 0.5f, 2f); // 0.5f 지연 후 2f 마다 반복
            
        }
    }

    void AttackTime()
    {
        ani.SetTrigger("doAttack"); // 애니메이션 발동
        ufo.GetComponent<UFO>().Damage(attackPower); // UFO 스크립트에 Damage 함수 호출
    }


}

  
