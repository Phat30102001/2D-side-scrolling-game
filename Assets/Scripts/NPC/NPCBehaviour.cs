using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum NPCState {IDLE, TALKABLE }

public class NPCBehaviour : MonoBehaviour
{
    //public static NPCBehaviour instance;

    public NPCState state;

    public GameObject talkButton;

    public bool playerDetect;

    private InputManager input;

    private Transform playerTransform;
    private UnitStatReceiver unit;



    private void Awake()
    {
        //instance = this;

        playerTransform = GameObject.Find("Player").transform;
        unit= transform.GetChild(1).GetComponent<UnitStatReceiver>();
        input = GameObject.Find("InputManager").GetComponent<InputManager>();
    }

    private void Start()
    {
        talkButton.SetActive(false);
        UpdateNPCBehaivour(NPCState.IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        if (unit.DetectRange > DistanceToPlayer())
            UpdateNPCBehaivour(NPCState.TALKABLE);
        else
            UpdateNPCBehaivour(NPCState.IDLE);
    }

    public void UpdateNPCBehaivour(NPCState newState)
    {
        state = newState;
        switch (state)
        {
            case NPCState.IDLE:
                talkButton.SetActive(false);
                break;

            case NPCState.TALKABLE:
                input.Npc = gameObject;
                talkButton.SetActive(true);
                break;
        }
    }

    public float DistanceToPlayer()
    {
        return Vector2.Distance(playerTransform.position, transform.position);
    }
}
