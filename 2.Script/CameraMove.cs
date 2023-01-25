using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float moveSpeed = 20f; // 카메라 속도
    float count = 0; // 시간 경과를 알려줄 변수

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) // 마우스 왼쪽 클릭
        {
           
            Vector3 mousePoint = Camera.main.ScreenToViewportPoint(Input.mousePosition); // 카메라 안에서의 마우스 위치, mousePoint는 카메라의 중심 (0,0,0)
            
            if(mousePoint.x < 0.5) // 카메라 뷰의 왼쪽
            {
                count += Time.deltaTime; //시간을 계속 더한다.
                if(count >= 0.5f) // 시간이 0.5f가 지났다면
                {
                    transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); // 왼쪽으로 이동

                    if (Camera.main.transform.position.x <= 5) // 만약 카메라 x좌표가 5보다 작거나 같다면
                    {
                        Camera.main.transform.position = new Vector3(5, Camera.main.transform.position.y, Camera.main.transform.position.z); // x좌표를 계속 5로 둔다.
                    }
                }
               
            }
            
            if(mousePoint.x >= 0.5) // 카메라 뷰의 오른쪽 (중심도 오른쪽으로 가겠지만 크게 의미 없다)
            {
                count += Time.deltaTime;
                if(count >= 0.5f)
                {
                    transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); // 오른쪽으로 이동

                    if (Camera.main.transform.position.x >= 52) // 만약 카메라 x좌표가 52보다 크거나 같다면
                    {
                        Camera.main.transform.position = new Vector3(52, Camera.main.transform.position.y, Camera.main.transform.position.z); // x좌푤르 계속 52로 둔다.
                    }
                }
               
            }

            Debug.Log(mousePoint.ToString()); // 클릭하는 마우스의 좌표값
             //Debug.Log(Camera.main.transform.position); // 카메라 좌표
            
        }

        if (Input.GetMouseButtonUp(0)) // 마우스를 떼면
        {
            count = 0; // 시간 경과를 0으로 되돌린다.
        }

    }
   
}
