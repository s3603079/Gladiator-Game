using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : SingletonMonoBehaviour<WeaponManager>
{
    Weapon activeWeapon_;   //  !<  フィールドに落ちている武器 
    const string PrefabsPath = "Prefabs/Weapons/";    //  !<  武器のプレハブのパス

    public Weapon ActiveWeapon
    {
        get { return activeWeapon_; }
    }

    override protected void Awake()
    {
        base.Awake();
    }

	void Start ()
    {
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            DebugPopupWeapon(WeaponType.Sword);
        }
    }

    public void DebugPopupWeapon(WeaponType argWeaponType)
    {
        GameObject weapon = null;
        switch (argWeaponType)
        {
            case WeaponType.Sword:
                weapon = Resources.Load(PrefabsPath + "Sword") as GameObject;
                break;
            case WeaponType.Shield:
                weapon = Resources.Load(PrefabsPath + "Shield") as GameObject;
                break;
            case WeaponType.Bow:
                weapon = Resources.Load(PrefabsPath + "Bow") as GameObject;
                break;

        }
        
        if(!weapon.GetComponent<Weapon>())
        {
            Debug.LogError("Found Weapon Failed...");
        }
        float testRandom = Random.Range(-10, 10);   //  !<  仮
        Vector3 pos = new Vector3(testRandom, testRandom, testRandom);
        weapon = Instantiate(weapon, pos, Quaternion.identity);

        activeWeapon_ = weapon.GetComponent<Weapon>();
    }
}
