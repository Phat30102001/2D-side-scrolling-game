using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatReceiver : MonoBehaviour
{
    public UnitStat stat;

     private int currentHp;
     private int maxHp;
     private int damage;
     private int money;

     private float movingSpeed;
     private float detectRange;
     //private float ativeAttackRange;

    // player only
     private float kBForce;
     private float kBTotalTime;

    public int CurrentHp { get => currentHp;private set => currentHp = value; }
    public int MaxHp { get => maxHp;private set => maxHp = value; }
    public int Damage { get => damage;private set => damage = value; }
    public float MovingSpeed { get => movingSpeed;private set => movingSpeed = value; }
    public float DetectRange { get => detectRange;private set => detectRange = value; }
    //public float AtiveAttackRange { get => ativeAttackRange;private set => ativeAttackRange = value; }
    public float KBForce { get => kBForce; set => kBForce = value; }
    public float KBTotalTime { get => kBTotalTime; set => kBTotalTime = value; }
    public int Money { get => money; set => money = value; }

    private void Start()
    {
        this.maxHp = stat.Hp;
        this.currentHp = maxHp;

        this.damage = stat.Damage;
        this.money = stat.Money;
        this.movingSpeed = stat.MovingSpeed;
        this.detectRange = stat.DetectRange;
        //this.ativeAttackRange = stat.AtiveAttackRange;

        this.kBForce = stat.KBForce;
        this.kBTotalTime = stat.KBTotalTime;



        //Debug.Log(stat.Damage);
        //Debug.Log(Damage + " " + MovingSpeed + " " + DetectRange + " " + AtiveAttackRange + " " + CurrentHp + " " + MaxHp);
    }

    public void TakeDamage(int damageValue)
    {
        CurrentHp -= damageValue;
        //Debug.Log("HP:" + CurrentHp);
    }
    public IEnumerator Heal(int healValue)
    {
        //Debug.Log("HP:" + CurrentHp);

        yield return new WaitForSeconds(1f);

        if (CurrentHp + healValue > MaxHp)
            CurrentHp = MaxHp;
        else
            CurrentHp += healValue;
        Debug.Log("HP:" + CurrentHp);
    }

    public void TransferMoney(int value)
    {
        Money += value;
    }

    public bool IsDead()
    {
        if(CurrentHp<=0)
                return true;
        else
            return false;
    }
}
