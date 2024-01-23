using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private double _healthPoint = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecieveDamage(double dmg)
    {
        //Damage-reducing modifiers' logic

        _healthPoint -= dmg;

        if(_healthPoint <= 0)
            Die();
    }

    private void Die()
    {
        //Death-related logic

        
    }
}
