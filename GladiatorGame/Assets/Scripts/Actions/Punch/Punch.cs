using UnityEngine;

public class Punch : Weapon
{
    void Start()
    {
        attackedReach_ = 1.0f;
        weakToType_ = WeaponType.Sword;
        strengthToType_ = WeaponType.Shield;
        thisType_ = WeaponType.Punch;
        base.Start();
    }

    void Update ()
    {
        base.Update();
    }

}
