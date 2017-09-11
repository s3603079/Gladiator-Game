using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : Charctor
{
    float currentTime_ = 0f;
	void Start ()
    {
	}
	
	void Update ()
    {
        if (!isHitting_)
            return;

        currentTime_ += Time.deltaTime;
        if(currentTime_ > 1f)
        {// 攻撃から1秒たったら非攻撃状態
            currentTime_ = 0f;
            isHitting_ = false;
            base.RemoveLog(1);
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHitting_)
            return;

        if (collision.tag == "Fist")
        {
            string msg = CharctorManager.Instance.Enemy.Power.ToString();
            logNum_.Add(1, Logger.Log("Enemy punch for Player!! " + msg + " Damage!!"));
            isHitting_ = true;
        }
    }
}
