using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    void Start()
    {
        attackedReach_ = 1.0f;
        weakToType_ = WeaponType.Bow;
        strengthToType_ = WeaponType.Punch;
        thisType_ = WeaponType.Sword;
        base.Start();
    }

    void Update()
    {
        base.Update();
    }

}
