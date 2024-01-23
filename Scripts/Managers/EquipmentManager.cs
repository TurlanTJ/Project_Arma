using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;

    private void Awake()
    {
        if(instance != null)
            return;
        
        instance = this;
    }

    [SerializeField] private Dictionary<EquipmentSlots, IWeapon> _equipmentList;
    
    void Start()
    {
        _equipmentList = new Dictionary<EquipmentSlots, IWeapon>
        {
            { EquipmentSlots.MainHand, null },
            { EquipmentSlots.OffHand, null }
        };
    }

    // public bool EquipWeapon(IWeapon weapon)
    // {
    //     if(weapon == null)
    //         return false;

    //     int reqSlots = weapon.GetReqSlotsNumber();
    //     EquipmentSlots[] slots = weapon.GetWeaponSlots();

    //     if(reqSlots == 1)
    //     {
    //         UnequipWeapon(_equipmentList[slots[0]]);

    //         _equipmentList[slots[0]] = weapon;
    //         _equipmentList[slots[0]].SetEquippedSts(true);
    //     }
    //     else if(reqSlots > 1)
    //     {
    //         UnequipWeapon(_equipmentList[slots[0]]);
    //         UnequipWeapon(_equipmentList[slots[1]]);
            
    //         _equipmentList[slots[0]] = weapon;
    //         _equipmentList[slots[1]] = weapon;

    //         _equipmentList[slots[0]].SetEquippedSts(true);
    //     }

    //     return true;
    // }

    // public bool UnequipWeapon(IWeapon weapon)
    // {
    //     if(weapon == null)
    //         return false;

    //     if(_equipmentList[weapon.GetWeaponSlots()[0]] != null)
    //     {
    //         _equipmentList[weapon.GetWeaponSlots()[0]]= null;
    //         weapon.SetEquippedSts(false);
    //         return true;
    //     }
    //     else
    //         return false;     
    // }
}
public enum EquipmentSlots {
    MainHand,
    OffHand
}