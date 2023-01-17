using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI message;

    public Animator animator;

    Message[] currentMessage;
    int activeMessage;

    public void OpenDialog(Message[] message)
    {
        currentMessage = message;
        activeMessage = 0;

        animator.SetBool("fadeIn",true);
        Debug.Log("Start conversation: " + message.Length);
        DisplayMessage();
    }

    public void DisplayMessage()
    {
        Message messToDisplay = currentMessage[activeMessage];
        message.text = messToDisplay.mess;
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessage.Length)
            DisplayMessage();
        else
        {

            animator.Play("dialBoardFadeOut");
            Debug.Log("End");
            activeMessage = 0;

        }
            
    }
}
