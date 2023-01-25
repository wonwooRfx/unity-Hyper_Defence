using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MissileShooter : MonoBehaviour
{
    public float angle = 50f; // 움직일 각도 속도
    public GameObject misPre; // 미사일 프리팹
    GameObject mis; // 미사일 프리팹을 담을 오브젝트
   

    public GameObject shooter; // 발사할 위치 오브젝트

    

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
        if (Input.GetKey(KeyCode.W)) //w를 누르면 위로 각도가 올라감
        {
            transform.Rotate(0, 0, angle * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.S)) //s를 누르면 아래로 각도가 내려감
        {
            transform.Rotate(0, 0, -angle * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(misPre, shooter.transform.position, shooter.transform.rotation);
        }

        
        
    }

   
}