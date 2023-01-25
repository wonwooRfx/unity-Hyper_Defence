using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rid;
    float speed = 5f; // 이동속도
    
    public MonsterData Mdata; // 몬스터 데이터
    public int HP;
    public int MaxHP;
    public int attackPower; // 공격력

    public Slider hpSlider; // 체력바
    public Canvas hpCanvas; // 체력바 캔버스

    GameObject castle; // 성문

    Animator ani; // 애니메이션

    // Start is called before the first frame update
    void Start()
    {
        rid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        HP = Mdata.Hp; // 몬스터 데이터에서 받아옴
        MaxHP = Mdata.MaxHP;
        attackPower = Mdata.Attack;
       
        castle = GameObject.Find("Castle"); // 성문을 이름으로 찾는다.
       
        HP = MaxHP; //비율로 조절할 것이기 때문에 둘의 체력을 같다고 논다

      

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime); // 왼쪽으로 이동
        hpSlider.value = (float)HP / (float)MaxHP; // 현재 체력바의 value에 반영한다.
    }

    public void Damage(int Damage) // 데미지 함수
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
        if (collision.gameObject.tag == "Castle") // 태그가 castle라면
        {
            speed = 0;
            InvokeRepeating("AttackTime", 0.5f, 2f); // 0.5f 지연 후 2f 마다 반복
            //collision.gameObject.GetComponent<Castle>().Damage(attackPower); // Castle 스크립트에 Damage 함수 호출
        }
    }

    void AttackTime()
    {
        ani.SetTrigger("doAttack"); // 애니메이션 발동
        castle.GetComponent<Castle>().Damage(attackPower); // Castle 스크립트에 Damage 함수 호출
    }
}
