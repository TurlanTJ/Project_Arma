using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : IWeapon
{

    public override IEnumerator Fire(){
        if(CanFire()){
            Instantiate(bullet, bulletSpawnPos.transform.position, Quaternion.identity);
            bullet.AddComponent<BoxCollider>().isTrigger = true;

            currMagSize--;
            yield return new WaitForSeconds(fireDelay);
        }
        
        Debug.Log("RELOAD");

        Reload();
    }

}

