using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet : IItem
{
    string target { get; set; }
    double damage { get; set; }
    float bulletSpeed { get; set; }

    Vector3 initialPos { get; set; }

    BulletType bulletType { get; set; }
    
    void DealDamage(Target target){}
    void DealDamage(Target target, Vector3 targetPos){}
}
