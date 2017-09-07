using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected const string PrefabsPath = "Resources/Prefabs/";
    protected GameObject weaponPrefab_; //  !<  武器になるオブジェクトのプレハブ

    void Start ()
    {
	}
	
	void Update ()
    {
	}

    protected virtual void Attack(Charcter argCharcter)
    {
        argCharcter.IsAttacking = true;
        GameObject weapon = Instantiate(weaponPrefab_, transform.position, transform.rotation) as GameObject;
        
        weapon.transform.parent = this.transform;
        weapon.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        const float FistDestroyTime = 1f;
        Destroy(weapon, FistDestroyTime);
    }

}