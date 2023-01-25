using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnManager : MonoBehaviour
{
    public GameObject[] enemyPre = new GameObject[5]; // 배열로 담아줍니다
    float currentTime = 0;

    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > 1) // 1f이 지나면
        {
            switch (Random.Range(0, 5)) // 랜덤변수
            {
                case 0:
                    Instantiate(enemyPre[0], transform.position, Quaternion.identity); // 배열로 변경
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
            currentTime = 0; // 시간초기화(다시 생성 할 수 있도록) 
        }
     
    }
}
