using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualChatactor : MonoBehaviour {

    //体力
    private int _health;
    //最大体力
    public int _healthMax;
    //被ダメージ量
    public int _damage;

    [SerializeField]
    private KillCount _killCount;

    private int weaponType;

    // Use this for initialization
    void Start () {
        _health = _healthMax;
	}

    void Update()
    {
        if(!IsLiving())
        {
            _killCount.AddKillCount();//キルカウント＋１
        }

        if(Time.time%10==0)
        {
            weaponType++;
        }
    }

    public bool IsLiving()
    {
        if(_health<=0)
        { 
            //死を返す
            return false;
        }
        return true;//生存を返す
    }

    public int Life()
    {
        return _health;
    }

    public int Power()
    {
        return _damage;
    }

    public void Damage()
    {
        _health -= _damage;
        _health = Mathf.Clamp(_health, 0, _healthMax);
    }

    public int WeaponType()
    {
        
    }
}
