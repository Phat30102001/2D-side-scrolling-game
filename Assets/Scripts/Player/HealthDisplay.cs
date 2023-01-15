using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private UnitStatReceiver unit;

    //public int health;
    //public int numOfHeart;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Awake()
    {
        unit = GameObject.Find("PlayerStat").GetComponent<UnitStatReceiver>();
    }


    private void Update()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if (i < unit.CurrentHp)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;

            if (i < unit.MaxHp)
            {
                hearts[i].enabled = true;
            }
            else
                hearts[i].enabled = false;
        }
    }
}
