using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTouch : MonoBehaviour
{
    public Text txt; // 자원 텍스트
    public int moneyPrice = 0; // 담을 변수
    public Button[] btns = new Button[8]; // 버튼들을 누르지 못하게 하기 위해서 담아두기
   
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      

         if (Input.GetMouseButtonDown(0))
         {
             Vector2 moneyPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             Ray2D ray = new Ray2D(moneyPos, Vector2.zero);
             RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            
            // 충돌체가 없지 않다면 (즉, 있다면)
             if (hit.collider != null)
             {
                //충돌체의 테크 정보가 Money 인지 확인
                if (hit.collider.CompareTag("Money"))
                {
                    moneyPrice += hit.collider.GetComponent<Money>().price; // 부딫히는 물체의 Money스크립트의 price를 받아온다.
                    Destroy(hit.collider.gameObject);

                }
                 
             } 

        }
        
        txt.text = moneyPrice.ToString(); // 텍스트의 가격을 담는다

    }

    public void JellyBuy(int money)
    {
        moneyPrice -= money; // UImanager에서 받아올 매개변수
        txt.text = moneyPrice.ToString(); // 텍스트의 가격을 담는다
    }

}
