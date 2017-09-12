using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    protected override void Start() {
        weaponDestroyTime_ = 1f;
        attackedReach_ = 1.0f;
        weakType_ = WeaponType.Bow;
        strengthType_ = WeaponType.Punch;
        thisType_ = WeaponType.Sword;
        base.Start();
    }

    public override void Attack(float InputValue) {
        transform.parent.localEulerAngles = (Vector3.MoveTowards(transform.forward * 0F, transform.forward * 90F, InputValue) * 120F);
    }
}
