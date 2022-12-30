using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="UnitStat",menuName ="Unit")]
public class UnitStat : ScriptableObject
{
    public int hp;
    public int damage;
    public float movingSpeed;
    public float detectRange;
}
