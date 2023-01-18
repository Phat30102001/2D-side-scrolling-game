using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<ItemSOReceiver> itemSO=new List<ItemSOReceiver>();

    public void AddItem(ItemSOReceiver item)
    {
        itemSO.Add(item);

        //int slot = itemList.Length;
        //Debug.Log(slot);
        //itemList[slot-1] = item;
        //item.SetActive(false);
    }

    public void CheckItem()
    {
        foreach(ItemSOReceiver item in itemSO)
        {
            Debug.Log(item);
        }
    }
}
