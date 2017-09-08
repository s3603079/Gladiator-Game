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

    }

    void Update ()
    {
        ai_.Execute(this);
        base.Update();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJumping_ = false;
        }
    }

}