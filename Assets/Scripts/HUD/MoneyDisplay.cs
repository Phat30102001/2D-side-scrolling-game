using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyDisplay : MonoBehaviour
{

    public UnitStatReceiver playerStat;

    private TextMeshProUGUI moneyValue;


    private void Awake()
    {
        moneyValue = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyValue.text = playerStat.Money.ToString() ;
    }
}
