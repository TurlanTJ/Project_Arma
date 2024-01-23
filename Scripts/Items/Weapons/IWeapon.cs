using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon : IItem
{
    new int itemID { get; set; }
    new string itemName { get; set; }
    int magSize { get; set; }
    int currMagSize { get; set; }
    float fireRate { get; set; }
    float fireDelay { get; set; }
    float fireRange { get; set; }
    float reloadTime { get; set; }
    BulletType reqBulletType { get; set; }
    GameObject bullet { get; set; }
    GameObject bulletSpawnPos { get; set; }

    bool CanFire();
    IEnumerator Fire();
    void Reload();
}

public enum BulletType
{
    Pistol,
    SMG,
    Rifle,
    Shotgun,
    Grenade
}
