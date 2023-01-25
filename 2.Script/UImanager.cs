using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ����ȯ�� ���� ���ӽ����̽�
using UnityEngine.UI;


public class UImanager : MonoBehaviour
{
    public GameObject UIbg1, UIbg2; // �Ʊ� ����â 1, �Ʊ�����â 2
    public GameObject slotBtn1, slotBtn2; // ����ü���� ��ư 1, ���� ü���� ��ư 2
    public GameObject[] ourMonsters = new GameObject[8]; // �Ʊ��� ���� �迭
    public GameObject spwnManagerOur; // �Ʊ��� ������ ��ġ

    public GameObject mc; // ����ī�޶�
    public JellyData[] Jdatas = new JellyData[8]; // ���������͸� ���� �迭

    public void GameScene()
    {
        SceneManager.LoadScene("1Pase"); // 1Pase ������ ��ȯ
    }
    public void StartScene()
    {
        SceneManager.LoadScene("Start"); // Start ������ ��ȯ
    }

    public void Stage1Clear()
    {
        SceneManager.LoadScene("Stage1 Clear");// Stage1 Clear ������ ��ȯ
    }
    public void GameStop()
    {
        Time.timeScale = 0; // ���� ����
        return;
    }

    public void GameResume()
    {
        Time.timeScale = 1; // ���� �ٽý���
        return;
    }

    public void SlotChange1() // 2�� ����â�� ������
    {
        slotBtn1.SetActive(false);
        slotBtn2.SetActive(true);
        UIbg1.SetActive(false);
        UIbg2.SetActive(true);
    }

    public void SlotChange2() // 1�� ����â�� ������
    {
        slotBtn1.SetActive(true);
        slotBtn2.SetActive(false);
        UIbg1.SetActive(true);
        UIbg2.SetActive(false);
    }

    public void ourMonster1()
    {
        mc.GetComponent<MoneyTouch>().JellyBuy(Jdatas[0].price); // �Ӵ���ġ ��ũ��Ʈ���� jellybuy�Լ��� �Ű������� ������������ ������ ��´�. 
        Instantiate(ourMonsters[0], spwnManagerOur.transform.position, Quaternion.identity); // SpwnManagerOur ��ġ���� �迭[0]�� �Ʊ� ���͸� ������Ų��.
        
    }

    public void ourMonster2()
    {
        mc.GetComponent<MoneyTouch>().JellyBuy(Jdatas[1].price);
        Instantiate(ourMonsters[1], spwnManagerOur.transform.position, Quaternion.identity);
    }

    public void ourMonster3()
    {
        mc.GetComponent<MoneyTouch>().JellyBuy(Jdatas[2].price);
        Instantiate(ourMonsters[2], spwnManagerOur.transform.position, Quaternion.identity);
    }

    public void ourMonster4()
    {
        mc.GetComponent<MoneyTouch>().JellyBuy(Jdatas[3].price);
        Instantiate(ourMonsters[3], spwnManagerOur.transform.position, Quaternion.identity);
    }

    public void ourMonster5()
    {
        mc.GetComponent<MoneyTouch>().JellyBuy(Jdatas[4].price);
        Instantiate(ourMonsters[4], spwnManagerOur.transform.position, Quaternion.identity);
    }

    public void ourMonster6()
    {
        mc.GetComponent<MoneyTouch>().JellyBuy(Jdatas[5].price);
        Instantiate(ourMonsters[5], spwnManagerOur.transform.position, Quaternion.identity);
    }

    public void ourMonster7()
    {
        mc.GetComponent<MoneyTouch>().JellyBuy(Jdatas[6].price);
        Instantiate(ourMonsters[6], spwnManagerOur.transform.position, Quaternion.identity);
    }

    public void ourMonster8()
    {
        mc.GetComponent<MoneyTouch>().JellyBuy(Jdatas[7].price);
        Instantiate(ourMonsters[7], spwnManagerOur.transform.position, Quaternion.identity);
    }


}
