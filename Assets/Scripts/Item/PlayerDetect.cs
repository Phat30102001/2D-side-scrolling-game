using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    private Transform player;

    public GameObject Btn;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        Btn.SetActive(Detect());
    }

    public bool Detect()
    {
        float disToPlayer= Vector2.Distance(player.position, transform.position);
        //Debug.Log(disToPlayer);

        if (disToPlayer <= 2)
        {
            //Debug.Log(gameObject.name);
            InputManager.instance.Item = gameObject;
            return true;
        }
        else
            return false;
    }
}
