﻿using UnityEngine;

public class BaseEnemy : Character
{
    int level_ = 0;             //  !<  現在のレベル
    EnemyAI ai_;                //  !<  AIの挙動

#region UnityDefault
    void Start()
    {
        base.Start();
        life_ = 1;
        power_ = 1f;
        spd_ = new Vector2(0.05f, 5f);
        ai_ = GetComponent<EnemyAI>();
        logRegistKey_[(int)LogNum.Attack] = "Enemy Attaking : ";
        logRegistKey_[(int)LogNum.TakeDamage] = "Player Attack for Enemy!! ";
    }

    void Update()
    {
        ai_.Execute(this);
        base.Update();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping_ = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Weapon weapon = collision.gameObject.GetComponent<Weapon>();
        TriggerStay2D(weapon, collision);
    }
#endregion UnityDefault

#region Move
    public bool IsMoveToPick()
    {
        bool res = true;
        if (equipmentWeapon_.ThisWeaponType != WeaponType.Punch)
            res = false;
        TestPlayer player = CharacterManager.Instance.PlayerList[0];
        WeaponType playerWeaponType = player.EquipmentWeaponType;

        //  TODO    :   未実装
        //if(playerWeaponType == equipmentWeapon_.WeakWeaponType)

        //  プレイヤーの弱点以外か、自分と同じ武器タイプなら拾いに行かない
        if (WeaponManager.Instance.ActiveWeapon.StrengthWeaponType != playerWeaponType ||
            WeaponManager.Instance.ActiveWeapon.ThisWeaponType == equipmentWeapon_.ThisWeaponType)
            res = false;

        return res;
    }
#endregion Move
#region Attack

    protected override void ChoiceWeapon(WeaponType argWeaponType = WeaponType.Max, GameObject argGameObject = null)
    {
        TestPlayer player = CharacterManager.Instance.PlayerList[0];
        WeaponType playerWeaponType = player.EquipmentWeaponType;

        //  TODO    :   まだ未実装
        //if(playerWeaponType == equipmentWeapon_.WeakWeaponType)
        if (WeaponManager.Instance.ActiveWeapon.StrengthWeaponType == playerWeaponType &&
            WeaponManager.Instance.ActiveWeapon.ThisWeaponType != equipmentWeapon_.ThisWeaponType)
        {
            base.ChoiceWeapon(argWeaponType, argGameObject);
        }

    }
#endregion Attack
}