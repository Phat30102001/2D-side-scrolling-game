using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="UnitStat",menuName ="Unit")]
public class UnitStat : ScriptableObject
{
    [SerializeField] private int hp;
    [SerializeField] private int damage;
    [SerializeField] private float movingSpeed;
    [SerializeField] private float detectRange;
    [SerializeField] private float ativeAttackRange;


    public int Hp { get => hp; set => hp = value; }
    public int Damage { get => damage; set => damage = value; }
    public float MovingSpeed { get => movingSpeed; set => movingSpeed = value; }
    public float DetectRange { get => detectRange; set => detectRange = value; }
    public float AtiveAttackRange { get => ativeAttackRange; set => ativeAttackRange = value; }
    //public float AtiveAttackRange 
    //{ 

    //    get => ativeAttackRange;
    //    set 
    //    {
    //        if (ativeAttackRange>detectRange)
    //            ativeAttackRange = detectRange;
    //        else
    //            ativeAttackRange = value;
    //    } 
    //}
}
