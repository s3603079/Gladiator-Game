using UnityEngine;

public class BaseEnemy : Charctor
{
    int level_ = 0;

    void Start ()
    {
        base.Start();
        life_ = 1;
        power_ = 1f;
        spd_ = new Vector2(5f, 5f);
    }
	
	void Update ()
    {
        DebugActions();
        base.Update();
    }

    void FixedUpdate()
    {
        DebugMove();
    }
    void DebugActions()
    {
        if (isAttacking_)
            return;

        DebugNoticeLineRotate();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            weapon_.Attack(this);
            logNum_.Add(0, Logger.Log("Attaking : Punch"));
        }
    }

    void DebugNoticeLineRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            weapon_.transform.localEulerAngles = new Vector3(weapon_.transform.localEulerAngles.x, weapon_.transform.localEulerAngles.y, weapon_.transform.localEulerAngles.z - 1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            weapon_.transform.localEulerAngles = new Vector3(weapon_.transform.localEulerAngles.x, weapon_.transform.localEulerAngles.y, weapon_.transform.localEulerAngles.z + 1);
        }

    }

    void DebugMove()
    {
        if (isAttacking_)
            return;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigid2d_.velocity = new Vector2(rigid2d_.velocity.x, spd_.y);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigid2d_.velocity -= new Vector2(0f, -0.1f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid2d_.velocity = new Vector2(spd_.x, rigid2d_.velocity.y);
            transform.localScale = new Vector3(-direction_.x, transform.localScale.y, transform.localScale.z);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid2d_.velocity = new Vector2(-spd_.x, rigid2d_.velocity.y);
            transform.localScale = new Vector3(direction_.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
