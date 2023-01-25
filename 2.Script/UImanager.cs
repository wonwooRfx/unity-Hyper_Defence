using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬전환을 위한 네임스페이스
using UnityEngine.UI;


public class UImanager : MonoBehaviour
{
    public GameObject UIbg1, UIbg2; // 아군 선택창 1, 아군선택창 2
    public GameObject slotBtn1, slotBtn2; // 슬롯체인지 버튼 1, 슬롯 체인지 버튼 2
    public GameObject[] ourMonsters = new GameObject[8]; // 아군을 담을 배열
    public GameObject spwnManagerOur; // 아군을 생성할 위치

    public GameObject mc; // 메인카메라
    public JellyData[] Jdatas = new JellyData[8]; // 젤리데이터를 담을 배열

    public void GameScene()
    {
        SceneManager.LoadScene("1Pase"); // 1Pase 씬으로 전환
    }
    public void StartScene()
    {
        SceneManager.LoadScene("Start"); // Start 씬으로 전환
    }

    public void Stage1Clear()
    {
        SceneManager.LoadScene("Stage1 Clear");// Stage1 Clear 씬으로 전환
    }
    public void GameStop()
    {
        Time.timeScale = 0; // 게임 정지
        return;
    }

    public void GameResume()
    {
        Time.timeScale = 1; // 게임 다시시작
        return;
    }

    public void SlotChange1() // 2번 선택창이 열린다
    {
        slotBtn1.SetActive(false);
        slotBtn2.SetActive(true);
        UIbg1.SetActive(false);
        UIbg2.SetActive(true);
    }

    public void SlotChange2() // 1번 선택창이 열린다
    {
        slotBtn1.SetActive(true);
        slotBtn2.SetActive(false);
        UIbg1.SetActive(true);
        UIbg2.SetActive(false);
    }

    public void ourMonster1()
    {
        mc.GetComponent<MoneyTouch>().JellyBuy(Jdatas[0].price); // 머니터치 스크립트에서 jellybuy함수의 매개변수에 젤리데이터의 가격을 담는다. 
        Instantiate(ourMonsters[0], spwnManagerOur.transform.position, Quaternion.identity); // SpwnManagerOur 위치에서 배열[0]의 아군 몬스터를 생성시킨다.
        
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
