using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : SingletonMonoBehaviour<WeaponManager>
{
    Weapon activeWeapon_;   //  !<  フィールドに落ちている武器 
    const string PrefabsPath = "Prefabs/Weapons/";    //  !<  武器のプレハブのパス

    GameObject[] weaponGruop_ = new GameObject[(int)WeaponType.Max];
    Weapon[] weaponTypeGruop_ = new Weapon[(int)WeaponType.Max];

    public Weapon ActiveWeapon
    {
        get { return activeWeapon_; }
        set { activeWeapon_ = value; }
    }

    public void RemoveActiveWeapon(GameObject argDestroyWeapon)
    {
        Destroy(argDestroyWeapon);
        activeWeapon_ = null;
    }

    override protected void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        weaponGruop_[(int)WeaponType.Sword] = Resources.Load(PrefabsPath + "Sword") as GameObject;
        //  TDOO    :   未実装
        //weaponGruop_[(int)WeaponType.Shield] = Resources.Load(PrefabsPath + "Shield") as GameObject;
        //weaponGruop_[(int)WeaponType.Bow] = Resources.Load(PrefabsPath + "Bow") as GameObject;

        for (int lType = 0; lType < (int)WeaponType.Max; lType++)
        {
            if (!weaponGruop_[lType])
                continue;
            weaponTypeGruop_[lType] = weaponGruop_[lType].GetComponent<Weapon>();
        }
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
        GameObject weapon = weaponGruop_[(int)argWeaponType];
        Weapon weaponType = weaponTypeGruop_[(int)argWeaponType];

        Camera.main.pixelWidth;
        float testRandom = Random.Range(-5, 5);   //  !<  HACK  :   仮
        Vector3 pos = new Vector3(0, 5, 0);
        weapon = Instantiate(weapon, pos, Quaternion.identity);
    }
}
