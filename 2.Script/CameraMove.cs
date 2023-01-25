using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float moveSpeed = 20f; // ī�޶� �ӵ�
    float count = 0; // �ð� ����� �˷��� ����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) // ���콺 ���� Ŭ��
        {
           
            Vector3 mousePoint = Camera.main.ScreenToViewportPoint(Input.mousePosition); // ī�޶� �ȿ����� ���콺 ��ġ, mousePoint�� ī�޶��� �߽� (0,0,0)
            
            if(mousePoint.x < 0.5) // ī�޶� ���� ����
            {
                count += Time.deltaTime; //�ð��� ��� ���Ѵ�.
                if(count >= 0.5f) // �ð��� 0.5f�� �����ٸ�
                {
                    transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); // �������� �̵�

                    if (Camera.main.transform.position.x <= 5) // ���� ī�޶� x��ǥ�� 5���� �۰ų� ���ٸ�
                    {
                        Camera.main.transform.position = new Vector3(5, Camera.main.transform.position.y, Camera.main.transform.position.z); // x��ǥ�� ��� 5�� �д�.
                    }
                }
               
            }
            
            if(mousePoint.x >= 0.5) // ī�޶� ���� ������ (�߽ɵ� ���������� �������� ũ�� �ǹ� ����)
            {
                count += Time.deltaTime;
                if(count >= 0.5f)
                {
                    transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); // ���������� �̵�

                    if (Camera.main.transform.position.x >= 52) // ���� ī�޶� x��ǥ�� 52���� ũ�ų� ���ٸ�
                    {
                        Camera.main.transform.position = new Vector3(52, Camera.main.transform.position.y, Camera.main.transform.position.z); // x��ǧ�� ��� 52�� �д�.
                    }
                }
               
            }

            Debug.Log(mousePoint.ToString()); // Ŭ���ϴ� ���콺�� ��ǥ��
             //Debug.Log(Camera.main.transform.position); // ī�޶� ��ǥ
            
        }

        if (Input.GetMouseButtonUp(0)) // ���콺�� ����
        {
            count = 0; // �ð� ����� 0���� �ǵ�����.
        }

    }
   
}
