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
            base.RemoveLog(1);
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
            logNum_.Add(2, Logger.Log("Player Attaking : Punch"));
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

        if (collision.tag == "Fist")
        {
            string msg = CharacterManager.Instance.Enemy.Power.ToString();
            logNum_.Add(1, Logger.Log("Enemy punch for Player!! " + msg + " Damage!!"));
            isHitting_ = true;
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
