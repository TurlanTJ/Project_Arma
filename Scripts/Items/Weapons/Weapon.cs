using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    public int itemID { get; set; }
    public string itemName { get; set; }
    public bool isStackable { get; set; }
    public int currStack { get; set; }
    public int maxStack { get; set; }

    public int magSize { get; set; }
    public int currMagSize { get; set; }
    public float fireRate { get; set; }
    public float fireDelay { get; set; }
    public float fireRange { get; set; }
    public float reloadTime { get; set; }

    public BulletType reqBulletType { get; set; }
    public GameObject bullet { get; set; }
    public GameObject bulletSpawnPos { get; set; }

    private InventoryManager _inventoryManager;

    void Start() 
    {
        fireDelay = 60f / fireRate; 
        _inventoryManager = InventoryManager.instance;
    }

    public bool CanFire()
    {
        if(currMagSize <= 0)
            return false;

        return true;
    }

    public IEnumerator Fire()
    {
        if(CanFire()){
            Instantiate(bullet, bulletSpawnPos.transform.position, Quaternion.identity);
            bullet.AddComponent<BoxCollider>().isTrigger = true;

            currMagSize--;
            yield return new WaitForSeconds(fireDelay);
        }
        
        Debug.Log("RELOAD");

        Reload();
    }

    public void Reload()
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

    public bool Use()
    {
        throw new System.NotImplementedException();
    }
}

