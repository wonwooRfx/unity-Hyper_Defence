using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarpetBombing : MonoBehaviour
{
    public bool isShoot; // 발사 쿨타임을 정할 논리형 변수

    public Canvas skillCanvas;
    public Image skillImg;

    public GameObject coolText; // 타이머 텍스트 담은 오브젝트
    public Text coolTxt; // 타이머 텍스트
    float time = 10f; // 타이머 10f

    public float speed = 10f;

    public GameObject crossHair; // 조준점

    GameObject[] carpetBombs; // 미사일들을 담을 배열
    public GameObject carpetBombPre; // 미사일 프리팹
    GameObject missile; // 프리팹을 담을 변수

    bool isCrossing; // 조준점 있을때만 공격 가능하게 하는 변수
   
    private void Awake()
    {
        isShoot = true;
        isCrossing = false;
        skillImg.fillAmount = 0; // 시작할 때는 0으로 해둔다
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
                crossHair.SetActive(true); // 조준점을 켜기
                isCrossing = true;
            }
           
            if ( Input.GetKey(KeyCode.R) && isCrossing == true)
            {
                coolText.SetActive(true);
                skillImg.fillAmount = 1;

                carpetBombs = new GameObject[8]; // 8개 담아줌
                for (int i = 0; i < 8; i++)
                {
                    missile = Instantiate(carpetBombPre);
                    carpetBombs[i] = missile;
                    missile.transform.position = new Vector3(transform.position.x, transform.position.y + 23f, transform.position.z); // 담아진 미사일 프리팹이 조준점 23f 위로 생성
                }

                isShoot = false; // 발사 안되게 바꿔줌
                isCrossing = false; //조준점 안켜졌을때 공격 안되게 바꿔줌

                StartCoroutine(CoolTime()); // 코루틴 사용
                StartCoroutine(ImgCoolTime()); // 이미지 쿨타임 코루틴


                time = 10f; // 다시 10f을 담아 둬야한다.


            }

        }

    }

    IEnumerator CoolTime()
    {
        crossHair.SetActive(false); // 조준점 끄기
        yield return new WaitForSeconds(10f); // 10f 뒤에 true로 바꿔줌
        isShoot = true;
    }

    IEnumerator ImgCoolTime()
    {
        while (skillImg.fillAmount > 0) // 이미지 필양이 0보다 크면
        {
            this.time -= Time.deltaTime;
            coolTxt.text = this.time.ToString("F0"); // 소수점 표시 x
            skillImg.fillAmount -= Time.deltaTime / 10f; //fillAmount는 1이므로 10f 쿨타임을 하고 싶다면 10f을 나눈다
            yield return null;
        }
        yield break;
    }


}
