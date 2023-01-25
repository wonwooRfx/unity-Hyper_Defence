using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnManager : MonoBehaviour
{
    public GameObject[] enemyPre = new GameObject[5]; // �迭�� ����ݴϴ�
    float currentTime = 0;

    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > 1) // 1f�� ������
        {
            switch (Random.Range(0, 5)) // ��������
            {
                case 0:
                    Instantiate(enemyPre[0], transform.position, Quaternion.identity); // �迭�� ����
                    break;
                case 1:
                    Instantiate(enemyPre[1], transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(enemyPre[2], transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(enemyPre[3], transform.position, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(enemyPre[4], transform.position, Quaternion.identity);
                    break;
            }
            currentTime = 0; // �ð��ʱ�ȭ(�ٽ� ���� �� �� �ֵ���) 
        }
     
    }
}
