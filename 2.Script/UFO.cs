using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UFO : MonoBehaviour
{
    Rigidbody2D rid;

    public int HP = 300; // 체력
    int MaxHP = 300; // 최대체력

    public Text hpTxt; // 체력 텍스트
    Camera cam; // 카메라
    public GameObject win; // 승리 UI

    public Animator ani;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        ani = player.GetComponent<Animator>();// 플레이어의 애니메이터를
        rid = GetComponent<Rigidbody2D>();
        HP = MaxHP; // 체력과 최대체력을 같게 둔다
        cam = Camera.main;
    }

    public void Damage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            HP = 0; // 사라지지 않으니 체력을 0으로 고정
            cam.orthographicSize = 5; // 카메라 사이즈 조절
            cam.transform.position = new Vector3(-4, 14, -25); // 카메라 위치

            win.SetActive(true); // 승리 UI 활성화
            ani.SetTrigger("doWin"); // 승리 애니메이션
        }

    }

    // Update is called once per frame
    void Update()
    {
        hpTxt.text = "<color=#ff0000>" + HP + "</color>" + "/" + MaxHP.ToString(); // 현재체력/최대체력
    }


}
