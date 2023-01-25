using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    float bulletSpeed = 7f;

    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        //0뷰터 9까지 값중에 하나를 랜덤으로 가져와서
        int randValue = Random.Range(0, 10);
        GameObject target = GameObject.Find("Player");
        // 만약 3보다 작으면 플레이어방향
        if (target != null)
        {
            if (randValue < 3)
            {
                //GameObject target = GameObject.Find("Player");
                //방향을 구하고 싶다 target - me
                dir = target.transform.position - transform.position;
                //방향의 크기 1
                dir.Normalize();

            }
            //그렇지 않으면 왼쪽방향
            else
            {
                dir = Vector3.left;

            }
        }

        else
        {
            dir = Vector3.left;
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += dir * bulletSpeed * Time.deltaTime;

        if(transform.position.x <= -10f) // -10f 보다 더 멀다면 삭제해라
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 부딫히는 물체의 태그가 Player라면 사라진다.
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
