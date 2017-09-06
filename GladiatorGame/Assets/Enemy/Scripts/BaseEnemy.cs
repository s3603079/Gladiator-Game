using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject fist_;

    Rigidbody2D rigid2d_;
    Vector2 pos_;
    Vector2 spd_ = new Vector2(5f, 5f);
    Vector2 direction_;
    float power_ = 1f;
    public float Power
    {
        get { return power_; }
    }
    int life_ = 1;
    int level_ = 0;
    const float AttackFrame_ = 60;
    float currentAttackFrame_ = AttackFrame_;
    bool isAttacking_ = false;
    int logNum_;

    void Start ()
    {
        rigid2d_ = GetComponent<Rigidbody2D>();
        direction_ = transform.localScale;
    }
	
	void Update ()
    {
        DebugActions();
        pos_ = transform.position;
        if(isAttacking_)
        {
            if(--currentAttackFrame_ < 0)
            {
                currentAttackFrame_ = AttackFrame_;
                isAttacking_ = false;
                Logger.RemoveLog(logNum_);
            }
        }
    }

    void FixedUpdate()
    {
        DebugMove();
    }

    void Punch()
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
        logNum_ = Logger.Log("Attaking : Punch");
    }

    void DebugActions()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Punch();
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
