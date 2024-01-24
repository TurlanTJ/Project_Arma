using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : IItem
{
    public override void Use()
    {
        IWeapon weapon = new Rifle();

        Debug.Log($"{itemName} is used");
        return;
    }
}
