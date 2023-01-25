using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UFO : MonoBehaviour
{
    Rigidbody2D rid;

    public int HP = 300; // ü��
    int MaxHP = 300; // �ִ�ü��

    public Text hpTxt; // ü�� �ؽ�Ʈ
    Camera cam; // ī�޶�
    public GameObject win; // �¸� UI

    public Animator ani;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        ani = player.GetComponent<Animator>();// �÷��̾��� �ִϸ����͸�
        rid = GetComponent<Rigidbody2D>();
        HP = MaxHP; // ü�°� �ִ�ü���� ���� �д�
        cam = Camera.main;
    }

    public void Damage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            HP = 0; // ������� ������ ü���� 0���� ����
            cam.orthographicSize = 5; // ī�޶� ������ ����
            cam.transform.position = new Vector3(-4, 14, -25); // ī�޶� ��ġ

            win.SetActive(true); // �¸� UI Ȱ��ȭ
            ani.SetTrigger("doWin"); // �¸� �ִϸ��̼�
        }

    }

    // Update is called once per frame
    void Update()
    {
        hpTxt.text = "<color=#ff0000>" + HP + "</color>" + "/" + MaxHP.ToString(); // ����ü��/�ִ�ü��
    }


}
