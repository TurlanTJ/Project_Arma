using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : IWeapon
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public override IEnumerator Fire()
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

    public override void Reload()
    {
        base.Reload();
    }
}
