using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Data/MonsterData", order =0)]
public class MonsterData : ScriptableObject
{
    public string Mname;
    public string Job;
    public int Hp;
    public int MaxHP;
    public int Attack;

}
