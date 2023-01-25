using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int price; // 가격

    //public GameObject moneyBule, moneyRed, moneyOrange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.position.y <= -15f) // y축이 15f 이하면 사라져라
        {
           Destroy(gameObject);
          
        }
    }

  
}
