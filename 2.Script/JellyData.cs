using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JellyData", menuName = "Data/JellyData", order = 0)]
public class JellyData : ScriptableObject
{
    public string Jname; // 이름
    public int price; // 가격
    public int Hp; // 체력
    public int MaxHP; // 최대체력
    public int Attack; // 공격력
}
