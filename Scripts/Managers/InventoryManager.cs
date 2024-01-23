using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    private void Awake() {
        if(instance != null)
            return;
        
        instance = this;
    }

    public List<IItem> playerInventory = new List<IItem>();
    public int playerInventorySize = 25;

    public void UseItem(IItem item)
    {
        item.Use();
    }

    public bool AddItemToInventory(IItem item)
    {
        if(!item.isStackable && playerInventory.Count + 1 > playerInventorySize)
            return false;


        if(item.isStackable && playerInventory.Contains(item))
        {
            int newStack = playerInventory[playerInventory.IndexOf(item)].currStack + item.currStack;

            if(newStack <= item.maxStack)
            {
                playerInventory[playerInventory.IndexOf(item)].currStack = newStack;
                return true;
            }
            else
            {
                int excessStack = newStack - item.maxStack;

                item.currStack = excessStack;
                playerInventory[playerInventory.IndexOf(item)].currStack = item.maxStack;

                if(playerInventory.Count + 1 > playerInventorySize)
                    return true;
            }
        }

        playerInventory.Add(item);
        return true;
    }

    public bool TryGetItem(IItem searchedItem, out IItem item, out int currStack)
    {
        item = null;
        currStack = 0;
        
        foreach(IItem i in playerInventory)
        {
            if(!i.Equals(searchedItem))
                continue;
            
            item = i;
            currStack = i.currStack;
            return true;
        }

        return false;
    }

    public bool ContainsBullets(BulletType type, out int amount)
    {

        foreach(IItem item in playerInventory)
        {
            if(!(item is IBullet bullet) || !bullet.bulletType.Equals(type))
                continue;

            amount = item.currStack;
            return true;
        }
        
        amount = 0;
        return false;
    }

    public bool RemoveItemFromInventory(IItem item)
    {
        if(item == null | !playerInventory.Contains(item))
            return false;

        playerInventory.Remove(item);
        return true;
    }

    public bool RemoveItemFromInventory(IItem item, int stack)
    {
        if(item == null | !playerInventory.Contains(item))
            return false;

        int newStack = playerInventory[playerInventory.IndexOf(item)].currStack - stack;

        if(newStack <= 0)
            playerInventory.Remove(item);
        else
            playerInventory[playerInventory.IndexOf(item)].currStack = newStack;

        return true;
    }
}
