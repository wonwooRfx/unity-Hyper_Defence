using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int price; // ����

    //public GameObject moneyBule, moneyRed, moneyOrange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.position.y <= -15f) // y���� 15f ���ϸ� �������
        {
           Destroy(gameObject);
          
        }
    }

  
}
