using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : IBullet
{
    public int itemID { get; set; }
    public string itemName { get; set; }
    public bool isStackable { get; set; }
    public int currStack { get; set; }
    public int maxStack { get; set; }

    public string target { get; set; }
    public double damage { get; set; }
    public float bulletSpeed { get; set; }

    public Vector3 initialPos { get; set; }

    public BulletType bulletType { get; set; }

    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag.Equals(target))
        {
            bool sts = other.TryGetComponent(out Target target);
            
            if(!sts) {
                Debug.Log($"{other.transform.name} doesnt have Target component");
                return;
            }
            
            DealDamage(target, other.transform.position);
    
        }
    }

    public bool Use()
    {
        return true;
    }

    public void DealDamage(Target target)
    {
        double finalDmg = damage;

        //Damage-related logic


        target.RecieveDamage(finalDmg);
    }

    public void DealDamage(Target target, Vector3 targetPos)
    {
        double finalDmg = damage;

        //Damage-related logic


        target.RecieveDamage(finalDmg);
    }
}