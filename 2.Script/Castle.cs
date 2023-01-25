using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    Rigidbody2D rid;

    public int HP = 200; // ü��
    int MaxHP = 200; // �ִ�ü��

    public Text hpTxt; // ü�� �ؽ�Ʈ

    Camera cam; // ī�޶�
    public GameObject lose; // �й� UI
    public GameObject player; // �÷��̾�
    public Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        rid = GetComponent<Rigidbody2D>();
        ani = player.GetComponent<Animator>();// �÷��̾��� �ִϸ����͸� 
        HP = MaxHP; // ü�°� �ִ�ü���� ���� �д�
        cam = Camera.main; // ����ī�޶�
    }

    public void Damage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            HP = 0; // ������� ������ ü���� 0���� ����
            cam.orthographicSize = 5; // ī�޶� ������ ����
            cam.transform.position = new Vector3(-10, 14, -25); // ī�޶� ��ġ
           
            lose.SetActive(true); // �й� UI Ȱ��ȭ
            ani.SetTrigger("doDie"); // �й� �ִϸ��̼�

        }

        // Debug.Log(HP); // ü�� Ȯ��
    }

    // Update is called once per frame
    void Update()
    {
                     // ������
        hpTxt.text = "<color=#ff0000>" + HP + "</color>" + "/" + MaxHP.ToString(); // ����ü��/�ִ�ü��
    }


}
