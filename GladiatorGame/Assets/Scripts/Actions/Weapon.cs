using UnityEngine;

public enum WeaponType
{
    Punch,
    Sword,
    Shield,
    Bow,

    Max,
}

public class Weapon : MonoBehaviour
{
    protected float weaponDestroyTime_;                         //  !<  武器の消滅時間
    protected float attackedReach_;                             //  !<  武器の届く距離
    protected WeaponType weakType_, strengthType_, thisType_;   //  !<  武器の種類と相性
    
    float currentDestroyTime_;                                  //  !<  武器の消滅するまでの時間
    Rigidbody2D rigid2D_;                                       //  !<  武器のリジットボディ

    public float AttackedReach
    {
        get { return attackedReach_; }
    }
    public WeaponType ThisWeaponType
    {
        get { return thisType_; }
    }


    protected virtual void Start ()
    {
        currentDestroyTime_ = weaponDestroyTime_;
        rigid2D_ = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update ()
    {
        if(--currentDestroyTime_ < 0)
        {
            currentDestroyTime_ = weaponDestroyTime_;
            gameObject.SetActive(false);
        }
	}
    public virtual void Attack(float InputValue)
    {
    }

        void OnTriggerEnter2D(Collider2D collision)
    {
        //  装備されていたら判定なし
        if (gameObject.transform.parent)
            return;

        if (!WeaponManager.Instance.ActiveWeapon && collision.gameObject.tag == "Ground")
        {// 接地処理
            rigid2D_.gravityScale = 0.0f;
            rigid2D_.velocity = new Vector2(0.0f, 0.0f);
            WeaponManager.Instance.ActiveWeapon = this;
        }

        //  キャラクターが取得したら
        var charcter = collision.gameObject.GetComponent<Character>();
        if (!charcter)
            return;

        charcter.ChangeWeapon(thisType_);
        WeaponManager.Instance.RemoveActiveWeapon(gameObject);
    }

}