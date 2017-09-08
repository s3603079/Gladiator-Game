using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : Charcter
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
        {
            currentTime_ = 0f;
            isHitting_ = false;
            base.RemoveLog(1);
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fist")
        {
            if (!collision.gameObject.transform.parent.parent)
                return;

            string msg = collision.gameObject.transform.parent.parent.GetComponent<BaseEnemy>().Power.ToString();
            logNum_.Add(1, Logger.Log("Enemy punch for Player!! " + msg + " Damage!!"));
            isHitting_ = true;
        }
    }
}
