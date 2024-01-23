using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : IItem
{
    public int itemID { get; set; }
    public string itemName { get; set; }
    public bool isStackable { get; set; }
    public int currStack { get; set; }
    public int maxStack { get; set; }

    public bool Use()
    {
        Debug.Log($"{itemName} is used");
        return true;
    }
}
