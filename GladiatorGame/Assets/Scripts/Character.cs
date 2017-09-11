using System.Collections.Generic;
using UnityEngine;

enum LogNum
{
    Attack,
    TakeDamage,

    Max,
}


public class Character : MonoBehaviour
{
    protected Weapon equipmentWeapon_;                  //  !<  装備している武器
    protected GameObject []weaponGroup_ = new GameObject[(int)WeaponType.Max];  //  !<  所持している武器の一覧
    protected Weapon []weaponGroupType_ = new Weapon[(int)WeaponType.Max];      //  !<  所持している武器の種類の一覧
    protected WeaponType equipmentWeaponType_;          //  !<  装備している武器の種類

    protected bool isLiving_;                           //  !<  生死判定フラグ
    protected bool isAttacking_ = false;                //  !<  攻撃中フラグ
    protected bool isHitting_ = false;                  //  !<  攻撃を受けたフラグ
    protected Rigidbody2D rigid2d_;                     //  !<  剛体
    protected Vector2 pos_;                             //  !<  座標
    protected Vector2 spd_;                             //  !<  移動速度
    protected Vector2 direction_;                       //  !<  画像の向き
    protected float degree_;                            //  !<  角度
    protected float power_;                             //  !<  攻撃力
    protected int life_;                                //  !<  耐久値
    protected bool isJumping_ = false;                  //  !<  ジャンプ中フラグ

    const float AttackFinishFrame_ = 60;                //  !<  攻撃終了時間
    float currentAttackFrame_ = AttackFinishFrame_;     //  !<  現在の攻撃時間

    protected object[] logRegistKey_ = new object[(int)WeaponType.Max];

    public Vector2 Spd
    {
        get { return spd_; }
    }
    public bool IsJumping
    {
        get { return isJumping_; }
        set { isJumping_ = value; }
    }
    public Weapon EquipmentWeapon
    {
        get { return equipmentWeapon_; }
    }
    public WeaponType EquipmentWeaponType
    {
        get { return equipmentWeaponType_; }
        set { equipmentWeaponType_ = value; }
    }
    public float Power
    {
        get { return power_; }
    }
    public bool IsAttacking
    {
        get { return isAttacking_; }
        set { isAttacking_ = value; }
    }
    public bool IsLiving
    {
        get { return isLiving_; }
        set { isLiving_ = value; }
    }
    public int Life
    {
        get { return life_; }
        set { life_ = value; }
    }
    public Rigidbody2D RigitBody2D
    {
        get { return rigid2d_; }
    }
    public Vector2 Direction
    {
        get { return direction_; }
    }
    protected void Start()
    {
        rigid2d_ = GetComponent<Rigidbody2D>();
        direction_ = transform.localScale;
        degree_ = 0f;

        weaponGroup_[(int)WeaponType.Punch] = transform.GetChild(0).gameObject;
        weaponGroup_[(int)WeaponType.Sword] = transform.GetChild(1).gameObject;

        //  TODO    :   未実装
        //weaponGroup_[(int)WeaponType.Shield] = transform.GetChild(2).gameObject;
        //weaponGroup_[(int)WeaponType.Bow] = transform.GetChild(3).gameObject;

        equipmentWeapon_ = weaponGroup_[(int)WeaponType.Punch].GetComponent<Weapon>();
        equipmentWeaponType_ = equipmentWeapon_.ThisWeaponType;

        for (int lWeaponType = 0; lWeaponType < (int)WeaponType.Max; lWeaponType++)
        {// パンチ以外の武器を停止

            if (!weaponGroup_[lWeaponType])
                continue;

            weaponGroupType_[lWeaponType] = weaponGroup_[lWeaponType].GetComponent<Weapon>();

            if (lWeaponType == (int)WeaponType.Punch)
                continue;

            weaponGroup_[lWeaponType].SetActive(false);
        }
#if false
        weaponGroup_[(int)WeaponType.Punch].SetActive(false);
        weaponGroup_[(int)WeaponType.Sword].SetActive(true);
#endif
    }

    protected void Update()
    {
        pos_ = transform.position;
        if (isAttacking_)
        {
            if (--currentAttackFrame_ < 0)
            {// 攻撃から1秒たったら普通の状態
                currentAttackFrame_ = AttackFinishFrame_;
                isAttacking_ = false;
                Logger.RemoveLog(logRegistKey_[(int)LogNum.Attack]);
            }
        }
    }

    public virtual void Attack()
    {
        // TODO    :   武器のON、OFF

        rigid2d_.velocity = new Vector2(0, 0);
        isAttacking_ = true;
        string weaponTypeName = equipmentWeapon_.ThisWeaponType.ToString();
        Logger.Log(logRegistKey_[(int)LogNum.Attack], logRegistKey_[(int)LogNum.Attack] + weaponTypeName);
    }

    public void ChangeWeapon(WeaponType argWeaponType)
    {
        //  現在の武器をシャットダウン
        equipmentWeapon_.gameObject.SetActive(false);
        switch(argWeaponType)
        {//  指定の武器をスタートアップ
            case WeaponType.Sword:
                weaponGroup_[(int)WeaponType.Sword].SetActive(true);
                equipmentWeapon_ = weaponGroupType_[(int)WeaponType.Sword];
                break;
            case WeaponType.Shield:

                break;
            case WeaponType.Bow:

                break;
        }
    }
}