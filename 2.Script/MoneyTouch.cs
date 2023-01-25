using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTouch : MonoBehaviour
{
    public Text txt; // �ڿ� �ؽ�Ʈ
    public int moneyPrice = 0; // ���� ����
    public Button[] btns = new Button[8]; // ��ư���� ������ ���ϰ� �ϱ� ���ؼ� ��Ƶα�
   
   
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
            
            // �浹ü�� ���� �ʴٸ� (��, �ִٸ�)
             if (hit.collider != null)
             {
                //�浹ü�� ��ũ ������ Money ���� Ȯ��
                if (hit.collider.CompareTag("Money"))
                {
                    moneyPrice += hit.collider.GetComponent<Money>().price; // �΋H���� ��ü�� Money��ũ��Ʈ�� price�� �޾ƿ´�.
                    Destroy(hit.collider.gameObject);

                }
                 
             } 

        }
        
        txt.text = moneyPrice.ToString(); // �ؽ�Ʈ�� ������ ��´�

    }

    public void JellyBuy(int money)
    {
        moneyPrice -= money; // UImanager���� �޾ƿ� �Ű�����
        txt.text = moneyPrice.ToString(); // �ؽ�Ʈ�� ������ ��´�
    }

}
