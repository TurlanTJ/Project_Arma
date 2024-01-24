using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IBullet : IItem
{
    public string target { get; protected set; }
    public double damage { get; protected set; }
    public float bulletSpeed { get; protected set; }

    public Vector3 initialPos { get; protected set; }

    public BulletType bulletType { get; protected set; }
    
    void Update()
    {
        
    }

    protected abstract void DealDamage(Target target);
    protected abstract void DealDamage(Target target, Vector3 targetPos);
}
