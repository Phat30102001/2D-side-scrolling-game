using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState { TALK,DIE,IDLE}
public class PlayerBehaviour : MonoBehaviour
{
    public PlayerState state;

    public static PlayerBehaviour instace;
    private void Awake()
    {
        instace = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerState(PlayerState.IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePlayerState(PlayerState newstate)
    {
        state = newstate;
        switch(state)
        {
            case PlayerState.TALK:
                break; 
            case PlayerState.DIE:
                break;
            case PlayerState.IDLE:
                break;
        }
    }
}
