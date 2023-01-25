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
        public Sprite sprite1, sprite2; // �� �̹�����
        public string name; // �� �̸�
        public string description; // �� ����

    }
    public Button perviousPageButton, nextPageButton; // ���� ��ư, ���� ��ư
    public Image dialogImg1, dialogImg2; // ĳ���� �̹����� 
    public Text nameTxt; // �̸� �ؽ�Ʈ
    public Text desciptionTxt; // ���� �ؽ�Ʈ
    public GameObject paseBtn; // 2Pase ���� ��ư

    public List<DialogDataProperty> dialogData;

    int currentPage;
    // Start is called before the first frame update
    void Start()
    {

        currentPage = 0; // ������ 0
        desciptionTxt.text = dialogData[currentPage].description; // ������ �ؽ�Ʈ�� �̹������� ��´�.
        dialogImg1.sprite = dialogData[currentPage].sprite1;
        dialogImg2.sprite = dialogData[currentPage].sprite2;
        nameTxt.text = dialogData[currentPage].name;

    }


    public void nextPage() // ���� �������� �Ѿ�� �Լ�
    {
        currentPage++; // 1�� �߰�
        desciptionTxt.text = dialogData[currentPage].description;
        dialogImg1.sprite = dialogData[currentPage].sprite1;
        dialogImg2.sprite = dialogData[currentPage].sprite2;
        nameTxt.text = dialogData[currentPage].name;

    }

    public void PrevPage() // �� �������� ���ư��� �Լ�
    {
        currentPage--; // 1�� ����
        desciptionTxt.text = dialogData[currentPage].description;
        dialogImg1.sprite = dialogData[currentPage].sprite1;
        dialogImg2.sprite = dialogData[currentPage].sprite2;
        nameTxt.text = dialogData[currentPage].name;

    }

    public void PaseBtn()
    {
        SceneManager.LoadScene("2Pase"); // 2������� ��ȯ
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPage >= dialogData.Count - 1) // �� �������� �����ߴٸ�
        {
            nextPageButton.interactable = false; // ������ư ��Ȱ��ȭ
            paseBtn.SetActive(true); // 2pase ���� ��ư Ȱ��ȭ
        }
        else
        {
            nextPageButton.interactable = true;
            paseBtn.SetActive(false); // 2pase ���� ��ư ��Ȱ��ȭ
        }

        if (currentPage == 0) // ù ���������
        {
            perviousPageButton.interactable = false; // ������ư ��Ȱ��ȭ
        }
        else
        {
            perviousPageButton.interactable = true;
        }
    }

}