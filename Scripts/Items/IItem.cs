using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IItem : MonoBehaviour
{
    public int itemID { get; protected set; }
    public bool isStackable { get; protected set; }
    public int currStack { get; protected set; }
    public int maxStack { get; protected set; }

    public string itemName;

    public virtual void Use(){}

    public void SetStackableSts(bool sts)
    {
        isStackable = sts;
    }

    public void SetCurrStack(int amount)
    {
        currStack = amount;
    }
}
