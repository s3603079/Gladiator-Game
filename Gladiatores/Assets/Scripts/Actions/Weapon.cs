﻿using UnityEngine;

public enum WeaponType
{
    Punch,
    Sword,
    Shield,
    Bow,

    Max,
}

public class Weapon : MonoBehaviour
{
    protected float attackedReach_;                             //  !<  武器の届く距離
    protected WeaponType weakToType_;
    protected WeaponType strengthToType_;
    protected WeaponType thisType_;   //  !<  武器の種類と相性
    
    float gravity_ = 0.0f;
    float accel_ = 9.8f * 0.001f;

    public float AttackedReach
    {
        get { return attackedReach_; }
    }
    public WeaponType ThisWeaponType
    {
        get { return thisType_; }
    }
    public WeaponType WeakWeaponType
    {
        get { return weakToType_; }
    }
    public WeaponType StrengthWeaponType
    {
        get { return strengthToType_; }
    }


    protected virtual void Start ()
    {
    }

    protected virtual void Update ()
    {
        if(!transform.parent)
        {
            if (transform.position.y >= -4.0f)
            {// 地面に落ちるまで落下
                gravity_ -= accel_;
                transform.position = new Vector2(transform.position.x, transform.position.y + gravity_);
            }
            else
            {// 地面に落ちたらマネージャーに登録
                WeaponManager.Instance.ActiveWeapons[0] = this;
            }
        }
	}
    public virtual void Attack(float InputValue)
    {
    }
<<<<<<< HEAD:GladiatorGame/Assets/Scripts/Actions/Weapon.cs

    void OnTriggerEnter2D(Collider2D collision)
    {
        //  装備されていたら判定なし
        if (gameObject.transform.parent)
            return;

        //  キャラクターが取得したら
        var charcter = collision.gameObject.GetComponent<Character>();
        if (!charcter)
            return;
    }
=======
>>>>>>> develop:Gladiatores/Assets/Scripts/Actions/Weapon.cs
}