using System.Collections;
using UnityEngine;

public class Charctor : MonoBehaviour
{
    [SerializeField]
    protected Weapon weapon_;                           //  !<  武器

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

    const float AttackFinishFrame_ = 60;                //  !<  攻撃終了時間
    float currentAttackFrame_ = AttackFinishFrame_;     //  !<  現在の攻撃時間

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

    protected void Start()
    {
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
            {
                currentAttackFrame_ = AttackFinishFrame_;
                isAttacking_ = false;
                RemoveLog(0);
            }
        }
    }

    protected void RemoveLog(int argIndex)
    {
        Logger.RemoveLog((int)logNum_[argIndex]);
        logNum_.Remove(argIndex);
    }
}