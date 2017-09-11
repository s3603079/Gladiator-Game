using UnityEngine;

public class Punch : Weapon
{
    void Start()
    {
        weaponDestroyTime_ = 1f;
        attackedReach_ = 1.0f;
        weakType_ = WeaponType.Sword;
        strengthType_ = WeaponType.Shield;
        thisType_ = WeaponType.Punch;
        base.Start();
    }

    void Update ()
    {
	}

}
