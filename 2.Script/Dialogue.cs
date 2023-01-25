using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Dialogue : MonoBehaviour
{
    [System.Serializable]
    public class DialogDataProperty
    {
        public Sprite sprite1, sprite2; // 들어갈 이미지들
        public string name; // 들어갈 이름
        public string description; // 들어갈 내용

    }
    public Button perviousPageButton, nextPageButton; // 이전 버튼, 다음 버튼
    public Image dialogImg1, dialogImg2; // 캐릭터 이미지들 
    public Text nameTxt; // 이름 텍스트
    public Text desciptionTxt; // 내용 텍스트
    public GameObject paseBtn; // 2Pase 진행 버튼

    public List<DialogDataProperty> dialogData;

    int currentPage;
    // Start is called before the first frame update
    void Start()
    {

        currentPage = 0; // 시작은 0
        desciptionTxt.text = dialogData[currentPage].description; // 각각의 텍스트와 이미지들을 담는다.
        dialogImg1.sprite = dialogData[currentPage].sprite1;
        dialogImg2.sprite = dialogData[currentPage].sprite2;
        nameTxt.text = dialogData[currentPage].name;

    }


    public void nextPage() // 다음 페이지로 넘어가는 함수
    {
        currentPage++; // 1씩 추가
        desciptionTxt.text = dialogData[currentPage].description;
        dialogImg1.sprite = dialogData[currentPage].sprite1;
        dialogImg2.sprite = dialogData[currentPage].sprite2;
        nameTxt.text = dialogData[currentPage].name;

    }

    public void PrevPage() // 전 페이지로 돌아가는 함수
    {
        currentPage--; // 1씩 제거
        desciptionTxt.text = dialogData[currentPage].description;
        dialogImg1.sprite = dialogData[currentPage].sprite1;
        dialogImg2.sprite = dialogData[currentPage].sprite2;
        nameTxt.text = dialogData[currentPage].name;

    }

    public void PaseBtn()
    {
        SceneManager.LoadScene("2Pase"); // 2페이즈로 전환
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPage >= dialogData.Count - 1) // 끝 페이지에 도달했다면
        {
            nextPageButton.interactable = false; // 다음버튼 비활성화
            paseBtn.SetActive(true); // 2pase 진행 버튼 활성화
        }
        else
        {
            nextPageButton.interactable = true;
            paseBtn.SetActive(false); // 2pase 진행 버튼 비활성화
        }

        if (currentPage == 0) // 첫 페이지라면
        {
            perviousPageButton.interactable = false; // 이전버튼 비활성화
        }
        else
        {
            perviousPageButton.interactable = true;
        }
    }

}