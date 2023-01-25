using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JellyData", menuName = "Data/JellyData", order = 0)]
public class JellyData : ScriptableObject
{
    public string Jname; // �̸�
    public int price; // ����
    public int Hp; // ü��
    public int MaxHP; // �ִ�ü��
    public int Attack; // ���ݷ�
}
