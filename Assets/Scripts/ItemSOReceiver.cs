using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSOReceiver : MonoBehaviour
{
    public ItemSO item;

    private string id;
    private string description;

    public string Id { get => id; set => id = value; }
    public string Description { get => description; set => description = value; }

    private void Start()
    {
        this.id = item.Id;
        this.description = item.Description;
    }
}
