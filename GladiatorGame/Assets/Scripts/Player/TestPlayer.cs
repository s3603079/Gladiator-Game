using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : Character
{
    float currentInvisibleTime_ = 0f;
    
	void Start ()
    {
        spd_ = new Vector2(5f, 5f);
        base.Start();
        logRegistKey_[(int)LogNum.Attack] = "Player Attaking : ";
        logRegistKey_[(int)LogNum.TakeDamage] = "Player TakeDamage : ";
    }

    void Update ()
    {
        DebugActions();
        base.Update();

        if (!isHitting_)
            return;

        currentInvisibleTime_ += Time.deltaTime;
        if(currentInvisibleTime_ > 1f)
        {// 被ダメージ状態から1秒たったら普通の状態
            currentInvisibleTime_ = 0f;
            isHitting_ = false;
            Logger.RemoveLog(logRegistKey_[(int)LogNum.TakeDamage]);
        }

    }
    
    void DebugActions()
    {
        if (isAttacking_)
            return;

        DebugMove();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            //  TODO    :   animation

            Attack();
        }
    }

    void DebugNoticeLineRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            equipmentWeapon_.transform.localEulerAngles = new Vector3(equipmentWeapon_.transform.localEulerAngles.x, equipmentWeapon_.transform.localEulerAngles.y, equipmentWeapon_.transform.localEulerAngles.z - 1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            equipmentWeapon_.transform.localEulerAngles = new Vector3(equipmentWeapon_.transform.localEulerAngles.x, equipmentWeapon_.transform.localEulerAngles.y, equipmentWeapon_.transform.localEulerAngles.z + 1);
        }
    }

    void DebugMove()
    {
        if (isAttacking_)
            return;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid2d_.velocity = new Vector2(spd_.x, rigid2d_.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid2d_.velocity = new Vector2(-spd_.x, rigid2d_.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping_)
        {
            isJumping_ = true;
            rigid2d_.velocity = new Vector2(rigid2d_.velocity.x, spd_.y);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //  TODO    :   add knock back
        if (isHitting_)
            return;

        string msg = null;
        switch (collision.tag)
        {// 他のオブジェクトとの当たりを考慮して面倒だけど一個ずつ処理分け

            case "Fist":
                msg = CharacterManager.Instance.Enemy.Power.ToString();
                Logger.Log(logRegistKey_[(int)LogNum.TakeDamage], "Enemy Punch for Player!! " + msg + " Damage!!");
                isHitting_ = true;
                break;
            case "Sword":
                msg = CharacterManager.Instance.Enemy.Power.ToString();
                Logger.Log(logRegistKey_[(int)LogNum.TakeDamage], "Enemy Sword for Player!! " + msg + " Damage!!");
                isHitting_ = true;
                break;

            default:
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJumping_ = false;
        }
    }
}
