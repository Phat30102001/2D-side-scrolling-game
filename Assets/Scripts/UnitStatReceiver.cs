using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatReceiver : MonoBehaviour
{
    public UnitStat stat;

    [SerializeField] private int currentHp;
    [SerializeField] private int maxHp;
    [SerializeField] private int damage;
    [SerializeField] private float movingSpeed;
    [SerializeField] private float detectRange;
    [SerializeField] private float ativeAttackRange;

    // player only
    [SerializeField] private float kBForce;
    [SerializeField] private float kBTotalTime;

    public int CurrentHp { get => currentHp;private set => currentHp = value; }
    public int MaxHp { get => maxHp;private set => maxHp = value; }
    public int Damage { get => stat.Damage;private set => damage = value; }
    public float MovingSpeed { get => movingSpeed;private set => movingSpeed = value; }
    public float DetectRange { get => detectRange;private set => detectRange = value; }
    public float AtiveAttackRange { get => ativeAttackRange;private set => ativeAttackRange = value; }
    public float KBForce { get => kBForce; set => kBForce = value; }
    public float KBTotalTime { get => kBTotalTime; set => kBTotalTime = value; }

    private void Start()
    {
        this.maxHp = stat.Hp;
        this.currentHp = maxHp;

        this.damage = stat.Damage;
        this.movingSpeed = stat.MovingSpeed;
        this.detectRange = stat.DetectRange;
        this.ativeAttackRange = stat.AtiveAttackRange;

        this.kBForce = stat.KBForce;
        this.kBTotalTime = stat.KBTotalTime;



        //Debug.Log(stat.Damage);
        Debug.Log(Damage + " " + MovingSpeed + " " + DetectRange + " " + AtiveAttackRange + " " + CurrentHp + " " + MaxHp);
    }

    public void TakeDamage(int damageValue)
    {
        CurrentHp -= damageValue;
        Debug.Log("HP:" + CurrentHp);
    }
    public void Heal(int healValue)
    {
        if (CurrentHp + healValue > MaxHp)
            CurrentHp = MaxHp;
        else
            CurrentHp += healValue;
        Debug.Log("HP:" + CurrentHp);
    }
}
