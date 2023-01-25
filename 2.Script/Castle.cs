using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    Rigidbody2D rid;

    public int HP = 200; // 체력
    int MaxHP = 200; // 최대체력

    public Text hpTxt; // 체력 텍스트

    Camera cam; // 카메라
    public GameObject lose; // 패배 UI
    public GameObject player; // 플레이어
    public Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        rid = GetComponent<Rigidbody2D>();
        ani = player.GetComponent<Animator>();// 플레이어의 애니메이터를 
        HP = MaxHP; // 체력과 최대체력을 같게 둔다
        cam = Camera.main; // 메인카메라
    }

    public void Damage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            HP = 0; // 사라지지 않으니 체력을 0으로 고정
            cam.orthographicSize = 5; // 카메라 사이즈 조절
            cam.transform.position = new Vector3(-10, 14, -25); // 카메라 위치
           
            lose.SetActive(true); // 패배 UI 활성화
            ani.SetTrigger("doDie"); // 패배 애니메이션

        }

        // Debug.Log(HP); // 체력 확인
    }

    // Update is called once per frame
    void Update()
    {
                     // 빨간색
        hpTxt.text = "<color=#ff0000>" + HP + "</color>" + "/" + MaxHP.ToString(); // 현재체력/최대체력
    }


}
