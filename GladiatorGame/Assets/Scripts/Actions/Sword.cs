using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
<<<<<<< HEAD:GladiatorGame/Assets/Scripts/Actions/Sword.cs
    protected override void Start() {
        weaponDestroyTime_ = 1f;
=======
    void Start()
    {
>>>>>>> feature/Enemy:GladiatorGame/Assets/Scripts/Actions/Sword/Sword.cs
        attackedReach_ = 1.0f;
        weakToType_ = WeaponType.Bow;
        strengthToType_ = WeaponType.Punch;
        thisType_ = WeaponType.Sword;
        base.Start();
    }

<<<<<<< HEAD:GladiatorGame/Assets/Scripts/Actions/Sword.cs
    public override void Attack(float InputValue) {
        transform.parent.localEulerAngles = (Vector3.MoveTowards(transform.forward * 0F, transform.forward * 90F, InputValue) * 120F);
=======
    void Update()
    {
        base.Update();
>>>>>>> feature/Enemy:GladiatorGame/Assets/Scripts/Actions/Sword/Sword.cs
    }
}
