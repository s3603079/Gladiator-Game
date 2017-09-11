using UnityEngine;

public class BaseEnemy : Character
{
    int level_ = 0;             //  !<  現在のレベル
    EnemyAI ai_;                //  !<  AIの挙動

    void Start ()
    {
        base.Start();
        life_ = 1;
        power_ = 1f;
        spd_ = new Vector2(0.05f, 5f);
        ai_ = GetComponent<EnemyAI>();
        logRegistKey_[(int)LogNum.Attack] = "Enemy Attaking : ";
    }

    void Update ()
    {
        ai_.Execute(this);
        base.Update();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsMoveToPick()
    {
        bool res = true;
        if (equipmentWeaponType_ != WeaponType.Punch)
            res = false;
        return res;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJumping_ = false;
        }
    }

}