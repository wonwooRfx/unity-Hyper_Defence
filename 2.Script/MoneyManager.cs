using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    //�ڿ��� �ν��ͽ�ȭ �ϱ� ���� ������
    public GameObject[] moneyPrefabs = new GameObject[3];
    //MoneyManager�� �����̴� �ӵ�(m/s)
    public float speed = 1f;
    //MoneyManager�� ������ �� �ִ� �¿� �Ÿ�
    public float leftAndRight = 15f;
    //MoneyManager�� ������ �ٲٴ� Ȯ��
    public float chanceToChangeDirections = 0.1f;
    // �ڿ��� ������ �ð�
    float currentTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // �⺻���� �̵�
        Vector3 pos = transform.localPosition;
        pos.x += speed * Time.deltaTime;
        transform.localPosition = pos;
        // ���� �ٲٱ�
        if (pos.x < -leftAndRight)
        {
            speed = Mathf.Abs(speed); //���������� �̵�
        }
        else if (pos.x > leftAndRight)
        {
            speed = -Mathf.Abs(speed); //�������� �̵�
        }

        currentTime += Time.deltaTime;
        if (currentTime > 1) // 1f�� ������
        {
            switch (Random.Range(0, 5)) // ��������
            {
                case 0:
                    Instantiate(moneyPrefabs[0], transform.position, Quaternion.identity); // �迭�� ����
                    break;
                case 1:
                    Instantiate(moneyPrefabs[1], transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(moneyPrefabs[2], transform.position, Quaternion.identity);
                    break;
               
            }
            currentTime = 0; // �ð��ʱ�ȭ(�ٽ� ���� �� �� �ֵ���) 
        }

    }


    private void FixedUpdate() // ��ǻ�� �ӵ��� ������� �ʴ� 50ȸ ȣ��
    {
        //���Ƿ� ���� �ٲٱ�
        if (Random.value < chanceToChangeDirections)
        {
            speed += -1; // ���� �ٲٱ�
        }
    }

}
