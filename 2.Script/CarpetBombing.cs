using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarpetBombing : MonoBehaviour
{
    public bool isShoot; // �߻� ��Ÿ���� ���� ���� ����

    public Canvas skillCanvas;
    public Image skillImg;

    public GameObject coolText; // Ÿ�̸� �ؽ�Ʈ ���� ������Ʈ
    public Text coolTxt; // Ÿ�̸� �ؽ�Ʈ
    float time = 10f; // Ÿ�̸� 10f

    public float speed = 10f;

    public GameObject crossHair; // ������

    GameObject[] carpetBombs; // �̻��ϵ��� ���� �迭
    public GameObject carpetBombPre; // �̻��� ������
    GameObject missile; // �������� ���� ����

    bool isCrossing; // ������ �������� ���� �����ϰ� �ϴ� ����
   
    private void Awake()
    {
        isShoot = true;
        isCrossing = false;
        skillImg.fillAmount = 0; // ������ ���� 0���� �صд�
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        h = h * speed * Time.deltaTime;
        transform.Translate(Vector3.right * h);
       
        if (isShoot == true)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                crossHair.SetActive(true); // �������� �ѱ�
                isCrossing = true;
            }
           
            if ( Input.GetKey(KeyCode.R) && isCrossing == true)
            {
                coolText.SetActive(true);
                skillImg.fillAmount = 1;

                carpetBombs = new GameObject[8]; // 8�� �����
                for (int i = 0; i < 8; i++)
                {
                    missile = Instantiate(carpetBombPre);
                    carpetBombs[i] = missile;
                    missile.transform.position = new Vector3(transform.position.x, transform.position.y + 23f, transform.position.z); // ����� �̻��� �������� ������ 23f ���� ����
                }

                isShoot = false; // �߻� �ȵǰ� �ٲ���
                isCrossing = false; //������ ���������� ���� �ȵǰ� �ٲ���

                StartCoroutine(CoolTime()); // �ڷ�ƾ ���
                StartCoroutine(ImgCoolTime()); // �̹��� ��Ÿ�� �ڷ�ƾ


                time = 10f; // �ٽ� 10f�� ��� �־��Ѵ�.


            }

        }

    }

    IEnumerator CoolTime()
    {
        crossHair.SetActive(false); // ������ ����
        yield return new WaitForSeconds(10f); // 10f �ڿ� true�� �ٲ���
        isShoot = true;
    }

    IEnumerator ImgCoolTime()
    {
        while (skillImg.fillAmount > 0) // �̹��� �ʾ��� 0���� ũ��
        {
            this.time -= Time.deltaTime;
            coolTxt.text = this.time.ToString("F0"); // �Ҽ��� ǥ�� x
            skillImg.fillAmount -= Time.deltaTime / 10f; //fillAmount�� 1�̹Ƿ� 10f ��Ÿ���� �ϰ� �ʹٸ� 10f�� ������
            yield return null;
        }
        yield break;
    }


}
