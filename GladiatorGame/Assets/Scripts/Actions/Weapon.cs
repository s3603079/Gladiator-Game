using UnityEngine;

public enum WeaponType
{
    Punch,
    Sword,
    Shield,
    Bow,
}

public class Weapon : MonoBehaviour
{
    protected float weaponDestroyTime_;                         //  !<  武器の消滅時間
    protected float attackedReach_;                             //  !<  武器の届く距離
    protected WeaponType weakType_, strengthType_, thisType_;   //  !<  武器の種類と相性
    
    float currentDestroyTime_;                                  //  !<  武器の消滅するまでの時間
    
    public float AttackedReach
    {
        get { return attackedReach_; }
    }

    protected void Start ()
    {
        currentDestroyTime_ = weaponDestroyTime_;
    }

    protected void Update ()
    {
        if(--currentDestroyTime_ < 0)
        {
            currentDestroyTime_ = weaponDestroyTime_;
            gameObject.SetActive(false);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.transform.parent)
            return;
        
        var charcter = collision.gameObject.GetComponent<Character>();
        if (!charcter)
            return;

        charcter.ChangeWeapon(thisType_);
        Destroy(gameObject);
    }
}