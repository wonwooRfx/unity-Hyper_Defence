using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    //자원을 인스터스화 하기 위한 프리팹
    public GameObject[] moneyPrefabs = new GameObject[3];
    //MoneyManager가 움직이는 속도(m/s)
    public float speed = 1f;
    //MoneyManager가 움직일 수 있는 좌우 거리
    public float leftAndRight = 15f;
    //MoneyManager가 방향을 바꾸는 확률
    public float chanceToChangeDirections = 0.1f;
    // 자원이 떨어질 시간
    float currentTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // 기본적인 이동
        Vector3 pos = transform.localPosition;
        pos.x += speed * Time.deltaTime;
        transform.localPosition = pos;
        // 방향 바꾸기
        if (pos.x < -leftAndRight)
        {
            speed = Mathf.Abs(speed); //오른쪽으로 이동
        }
        else if (pos.x > leftAndRight)
        {
            speed = -Mathf.Abs(speed); //왼쪽으로 이동
        }

        currentTime += Time.deltaTime;
        if (currentTime > 1) // 1f이 지나면
        {
            switch (Random.Range(0, 5)) // 랜덤변수
            {
                case 0:
                    Instantiate(moneyPrefabs[0], transform.position, Quaternion.identity); // 배열로 변경
                    break;
                case 1:
                    Instantiate(moneyPrefabs[1], transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(moneyPrefabs[2], transform.position, Quaternion.identity);
                    break;
               
            }
            currentTime = 0; // 시간초기화(다시 생성 할 수 있도록) 
        }

    }


    private void FixedUpdate() // 컴퓨터 속도에 관계없이 초당 50회 호출
    {
        //임의로 방향 바꾸기
        if (Random.value < chanceToChangeDirections)
        {
            speed += -1; // 방향 바꾸기
        }
    }

}
