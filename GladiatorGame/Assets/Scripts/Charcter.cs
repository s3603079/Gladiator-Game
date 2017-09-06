using System.Collections;
using UnityEngine;

public class Charcter : MonoBehaviour
{
    [SerializeField]
    GameObject fist_;                                   //  !<  パンチオブジェクト

    protected bool isAttacking_ = false;                //  !<  攻撃中フラグ
    protected bool isHitting_ = false;                  //  !<  攻撃を受けたフラグ
    protected Rigidbody2D rigid2d_;                     //  !<  剛体
    protected Vector2 pos_;                             //  !<  座標
    protected Vector2 spd_;                             //  !<  移動速度
    protected Vector2 direction_;                       //  !<  移動方向
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
    public Hashtable LogNumTable
    {
        get { return logNum_; }
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

    protected void Punch()
    {
        rigid2d_.velocity = new Vector2(0f, 0f);
        GameObject fist = Instantiate(fist_, transform.position, Quaternion.identity) as GameObject;
        float adjustPosition = fist.transform.localScale.x * 2;
        if (transform.localScale.x < 0)
        {
            adjustPosition = -adjustPosition;
            fist.transform.localScale = -fist.transform.localScale;
        }
        fist.transform.parent = this.transform;
        fist.transform.position = new Vector3(transform.position.x - adjustPosition, transform.position.y, transform.position.z);

        isAttacking_ = true;
        const float FistDestroyTime = 1f;
        Destroy(fist, FistDestroyTime);
        logNum_.Add(0, Logger.Log("Attaking : Punch"));
    }

    protected void RemoveLog(int argIndex)
    {
        Logger.RemoveLog((int)logNum_[argIndex]);
        logNum_.Remove(argIndex);
    }
}