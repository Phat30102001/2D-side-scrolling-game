using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public Message[] message;
 
    public void StartDialog()
    {
        //FindObjectOfType <DialogManager>().OpenDialog(message);
    }
}

[System.Serializable]
public class Message
{
    //public int actorID;
    public int phase;
    public string mess;
}


