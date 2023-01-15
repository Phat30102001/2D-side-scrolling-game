using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHeal : MonoBehaviour
{
    private UnitStatReceiver unit;

    private void Awake()
    {
        unit = GameObject.Find("PlayerStat").GetComponent<UnitStatReceiver>();
    }

    public void Heal(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            unit.Heal(1);
        }
    }
}
