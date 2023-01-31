using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NpcTalking : MonoBehaviour
{   
    public Animator animator;
    public GameObject dialogPanel;
    public TextMeshProUGUI text;
    public string[] dialog;
    

    private int index;
    private bool panelOpened;

    private NPCBehaviour npc;
    private void Start()
    {
        npc=GetComponent<NPCBehaviour>();
        panelOpened = false;
    }

    private void Update()
    {
        if (npc.state == NPCState.IDLE&&panelOpened)
        {
            ZeroText();
        }
    }
    public void Talk()
    {
        if (panelOpened)
        {

            NextLine();
        }
        else
        {
            animator.SetBool("fadeIn", true);
            panelOpened = true;
            Typing();
        }
    }

    public void ZeroText()
    {   
        animator.SetBool("fadeIn", false);
        text.text = "";
        index= 0;
        panelOpened= false;
        
    }

    void Typing()
    {
        text.text = dialog[index];
        Debug.Log(dialog[index]);   
    }

    public void NextLine()
    {
        if(index< dialog.Length - 1)
        {
            index++;
            Typing();
        }
        else
            ZeroText();
    }
}
