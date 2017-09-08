using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    TestPlayer activePlayer_;   //  !<  生きているプレイヤー
    float targetDir_ = 0;       //  !<  ターゲットの方向
    Transform targetPos_;       //  !<  ターゲットの位置

    void Start()
    {
        activePlayer_ = CharacterManager.Instance.PlayerList[0];
        targetPos_ = activePlayer_.gameObject.transform;
        targetDir_ = Mathf.Atan2(targetPos_.position.y - transform.position.y, targetPos_.position.x - transform.position.x);
    }
	
    public void Execute(BaseEnemy argBaseEnemy)
    {
        //  攻撃中は行動しない
        if (argBaseEnemy.IsAttacking)
            return;

        Move(argBaseEnemy);
        Jump(argBaseEnemy);
        Attack(argBaseEnemy);

    }

    void Attack(BaseEnemy argBaseEnemy)
    {
        var targetDistance = Vector2.Distance(transform.position, targetPos_.position);
        if(targetDistance <= argBaseEnemy.EquipmentWeapon.AttackedReach)
        {
            //  TODO    :   animation

            argBaseEnemy.Attack();
            argBaseEnemy.LogNumTable.Add(0, Logger.Log("Enemy Attaking : Punch"));
        }
    }

    void Move(BaseEnemy argBaseEnemy)
    {
        if (WeaponManager.Instance.ActiveWeapon)
        {
            MoveToPick();
        }
        else
        {
            MoveToAttack(argBaseEnemy);
        }
    }

    void MoveToAttack(BaseEnemy argBaseEnemy)
    {
        //  移動方向の取得
        targetDir_ = Mathf.Atan2(
            targetPos_.position.y - transform.position.y,
            targetPos_.position.x - transform.position.x);

        //  移動座標の取得
        Vector2 target = transform.position;
        target.x += argBaseEnemy.Spd.x * Mathf.Cos(targetDir_);

        //  移動
        transform.position = target;

        //  画像の向きの変更
        transform.localScale = (targetPos_.position.x < transform.position.x) ?
            new Vector3(argBaseEnemy.Direction.x, transform.localScale.y, transform.localScale.z) :
            new Vector3(-argBaseEnemy.Direction.x, transform.localScale.y, transform.localScale.z);
    }

    void MoveToPick()
    {

    }

    void Jump(BaseEnemy argBaseEnemy)
    {
        if (!activePlayer_.IsJumping ||
            argBaseEnemy.IsJumping)
            return;

        argBaseEnemy.IsJumping = true;
        argBaseEnemy.RigitBody2D.velocity = new Vector2(argBaseEnemy.RigitBody2D.velocity.x, argBaseEnemy.Spd.y);
    }
}
