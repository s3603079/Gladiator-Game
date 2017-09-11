using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    void Start()
    {
        weaponDestroyTime_ = 1f;
        attackedReach_ = 1.0f;
        weakType_ = WeaponType.Bow;
        strengthType_ = WeaponType.Punch;
        thisType_ = WeaponType.Sword;
        base.Start();
    }

    void Update()
    {
    }

}
