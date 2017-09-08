using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Weapon equipmentWeapon_;                  //  !<  装備している武器
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
    protected Hashtable logNum_ = new Hashtable();      //  !<  ログを消すためのインデックス
    protected bool isJumping_ = false;                  //  !<  ジャンプ中フラグ

    const float AttackFinishFrame_ = 60;                //  !<  攻撃終了時間
    float currentAttackFrame_ = AttackFinishFrame_;     //  !<  現在の攻撃時間

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
    public Hashtable LogNumTable
    {
        get { return logNum_; }
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
        var fist = transform.GetChild(0);
        equipmentWeapon_ = fist.GetComponent<Punch>();
        equipmentWeaponType_ = WeaponType.Punch;
        rigid2d_ = GetComponent<Rigidbody2D>();
        direction_ = transform.localScale;
        degree_ = 0f;
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
                RemoveLog(0);
            }
        }
    }

    public void Attack()
    {
        // TODO    :   武器のON、OFF

        rigid2d_.velocity = new Vector2(0, 0);
        isAttacking_ = true;
    }

    protected void RemoveLog(int argIndex)
    {
        Logger.RemoveLog((int)logNum_[argIndex]);
        logNum_.Remove(argIndex);
    }
    public void ChangeWeapon(WeaponType argWeaponType)
    {
        equipmentWeapon_.gameObject.SetActive(false);
        switch(argWeaponType)
        {
            case WeaponType.Sword:
                break;
            case WeaponType.Shield:

                break;
            case WeaponType.Bow:

                break;
        }
    }
}