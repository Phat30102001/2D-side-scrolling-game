using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public UnitStat unit;

    private float maxHealth;
    private float currentHealth;

    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = unit.Hp;
    }

    
}
