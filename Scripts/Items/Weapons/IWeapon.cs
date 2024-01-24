using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeapon : IItem
{
    public int magSize { get; protected set; }
    public int currMagSize { get; protected set; }
    public float fireRate { get; protected set; }
    public float fireDelay { get; protected set; }
    public float reloadTime { get; protected set; }
    public BulletType reqBulletType { get; protected set; }
    public GameObject bullet { get; protected set; }
    public GameObject bulletSpawnPos { get; protected set; }

    protected InventoryManager _inventoryManager;

    void Start()
    {
        fireDelay = 60f / fireRate; 
        _inventoryManager = InventoryManager.instance;        
    }

    public override void Use()
    {
        base.Use();
        throw new System.NotImplementedException();
    }

    public bool CanFire()
    {
        if(currMagSize <= 0)
            return false;

        return true;
    }

    public virtual void Reload()
    {
        if(currMagSize.Equals(magSize))
            return;
        
        if(_inventoryManager.ContainsBullets(reqBulletType, out int existingAmount))
        {
            if(existingAmount >= magSize)
            {
                currMagSize = magSize;
                _inventoryManager.RemoveItemFromInventory(bullet.GetComponent<IBullet>(), magSize);
            }    
            else
            {
                currMagSize = existingAmount;
                _inventoryManager.RemoveItemFromInventory(bullet.GetComponent<IBullet>());
            }  
        }
    }

    public abstract IEnumerator Fire();
}

public enum BulletType
{
    Pistol,
    SMG,
    Rifle,
    Shotgun,
    Grenade
}
