using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Item")]

public class ItemSO : ScriptableObject
{

    public string id;
    public string description;


    public string Id { get => id; }
    public string Description { get => description; }

}
