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

    public void Healing(InputAction.CallbackContext context)
    {
        if (context.performed)
        {


            StartCoroutine(unit.Heal(1));
        }
    }
}
