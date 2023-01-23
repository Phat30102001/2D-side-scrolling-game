using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHeal : MonoBehaviour
{
    private UnitStatReceiver unit;

    public static PlayerHeal instance;

    private void Awake()
    {
        unit = GameObject.Find("PlayerStat").GetComponent<UnitStatReceiver>();

        instance = this;
    }

    public void Healing()
    {
        //if (PlayerBehaviour.instace.state != PlayerState.IDLE) return;
        StartCoroutine(unit.Heal(1));
    }
}
