using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MissileShooter : MonoBehaviour
{
    public float angle = 50f; // ������ ���� �ӵ�
    public GameObject misPre; // �̻��� ������
    GameObject mis; // �̻��� �������� ���� ������Ʈ
   

    public GameObject shooter; // �߻��� ��ġ ������Ʈ

    

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) //w�� ������ ���� ������ �ö�
        {
            transform.Rotate(0, 0, angle * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.S)) //s�� ������ �Ʒ��� ������ ������
        {
            transform.Rotate(0, 0, -angle * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(misPre, shooter.transform.position, shooter.transform.rotation);
        }

        
        
    }

   
}