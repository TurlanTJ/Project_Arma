using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HCalRound : IBullet
{
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

    protected override void DealDamage(Target target)
    {
        double finalDmg = damage;

        //Damage-related logic


        target.RecieveDamage(finalDmg);
    }

    protected override void DealDamage(Target target, Vector3 targetPos)
    {
        double finalDmg = damage;

        //Damage-related logic


        target.RecieveDamage(finalDmg);
    }
}
